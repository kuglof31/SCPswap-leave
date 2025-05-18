using Exiled.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Exiled.API.Features;
using System.Timers;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using Exiled.Events.EventArgs.Server;
using Exiled.API.Features.Doors;





namespace ScpSwapp
{
    public class EventHandlers
    {

        private static readonly HashSet<string> allowedCommands = new HashSet<string>
    {
        "scpleave",
        "scpswap scp173",
        "scpswap scp096" ,
        "scpswap scp049" ,
        "scpswap scp079" , 
        "scpswap scp939" , 
        "scpswap scp106" ,
        "scpjoin scp173" , 
        "scpjoin scp096" , 
        "scpjoin scp106" , 
        "scpjoin scp939" , 
        "scpjoin scp079" ,
        "scpjoin scp049"
    };






        private static int swap106to173 = 0;
        private static int swap106to079 = 0;
        private static int swap106to049 = 0;
        private static int swap106to939 = 0;
        private static int swap106to096 = 0;

        // 173 küldi
        private static int swap173to106 = 0;
        private static int swap173to079 = 0;
        private static int swap173to049 = 0;
        private static int swap173to939 = 0;
        private static int swap173to096 = 0;

        // 079 küldi
        private static int swap079to106 = 0;
        private static int swap079to173 = 0;
        private static int swap079to049 = 0;
        private static int swap079to939 = 0;
        private static int swap079to096 = 0;

        // 049 küldi
        private static int swap049to106 = 0;
        private static int swap049to173 = 0;
        private static int swap049to079 = 0;
        private static int swap049to939 = 0;
        private static int swap049to096 = 0;

        // 939 küldi
        private static int swap939to106 = 0;
        private static int swap939to173 = 0;
        private static int swap939to079 = 0;
        private static int swap939to049 = 0;
        private static int swap939to096 = 0;

        // 096 küldi
        private static int swap096to106 = 0;
        private static int swap096to173 = 0;
        private static int swap096to079 = 0;
        private static int swap096to049 = 0;
        private static int swap096to939 = 0;    

        public static int hasznalat096 = 0; //ezek azt jelzik hogy lehet-e az scpkre jelentkezni
        public static int hasznalat173 = 0; 
        public static int hasznalat049 = 0; 
        public static int hasznalat079 = 0; 
        public static int hasznalat939 = 0; 
        public static int hasznalat106 = 0; 


        public static int lehetoseg173 = 0; //ezek azért hogy ne legyen "túljelentkezés" az scpk-re
        public static int lehetoseg096 = 0;
        public static int lehetoseg049 = 0;
        public static int lehetoseg079 = 0;
        public static int lehetoseg106 = 0;
        public static int lehetoseg939 = 0;

        

        

        public static bool isLeaveAllowed; // Jelzi, hogy a leave parancs még érvényes-e
        private static System.Timers.Timer leaveTimer;
        public static void OnRoundStarted()
        {
            isLeaveAllowed = true;


            leaveTimer = new System.Timers.Timer(40000); // 40000 ms = 40 másodperc
            leaveTimer.Elapsed += OnLeaveTimeout; // Időzítő eseménykezelő
            leaveTimer.AutoReset = false; // Csak egyszer fusson le
            leaveTimer.Start();

            foreach (var player in Player.List)
            {
                if (player.IsScp)
                {
                    player.Broadcast(18, "<b><color=orange>Tudtad azt, hogyha</color> <color=purple>SCP-t</color> <color=orange>akarsz cserélni, akkor\n</color> <color=red>.scpswap scp(száma)</color>,<color=yellow>ha meg kilépnél, akkor</color> <color=red>.scpleave</color></b>", Broadcast.BroadcastFlags.Normal, true);
                    
                   
                }
            }

        }

        private static void OnLeaveTimeout(object sender, ElapsedEventArgs e)
        {
            // Az idő lejárt, a leave parancs már nem engedélyezett
            isLeaveAllowed = false;

            // Az SCP-k értesítése, hogy az idő lejárt
            foreach (var player in Player.List)
            {
                if (player.IsScp)
                {
                    player.Broadcast(7, "<b><color=orange>Az idő lejárt, már</color> <color=red>NEM</color> <color=orange>hagyhatod el az SCP szerepet!</color></b>", Broadcast.BroadcastFlags.Normal, true);
                }
            }

            if (leaveTimer != null)
            {
                     leaveTimer.Stop();
                     leaveTimer.Dispose();
                     leaveTimer = null; // Null-ra állítjuk, hogy ne legyen érvénytelen referencia
            }           
        }


        private static Player volt173; //változó amiben tárolni fogjuk az scp-ket
        private static Player volt096; 
        private static Player volt049; 
        private static Player volt106; 
        private static Player volt079; 
        private static Player volt939; 


        public static void OnSendingValidCommand(SendingValidCommandEventArgs ev)
        {

            if (isLeaveAllowed == true) // ha még nem telt le a 40s
            {
                if (allowedCommands.Contains(ev.Query))
                {
                   
                    if(ev.Query == "scpleave")
                    { 

                if (ev.Player.Role.Type == RoleTypeId.Scp173 && hasznalat173 < 1)
                {
                       
                        ev.Player.SendConsoleMessage("Az üzenet sikeresen elküldve", "green");
                           
                           
                        hasznalat173++;

                    volt173 = ev.Player;

                    ev.Player.Broadcast(10, "<b><color=purple>Az üzenet sikeresen elküldve!</color></b>", shouldClearPrevious: true);

                    foreach (Player player in Player.List)
                    {
                        if (player.Role.Type == RoleTypeId.ClassD || player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard)
                        {
                            player.Broadcast(10, $"<b><color=#FF00FF>{ev.Player.Nickname}</color> <color=orange>el akarja hagyni az SCP szerepét! \nÍrd be a</color> <color=red>.scpjoin scp173</color> <color=yellow>parancsot, hogy átvedd a helyét!</b>");
                        }

                    }
                }
                else if (ev.Player.Role.Type == RoleTypeId.Scp096 && hasznalat096 < 1)
                {
                        ev.Player.SendConsoleMessage("Az üzenet sikeresen elküldve", "green");

                            hasznalat096++;

                    volt096 = ev.Player; // elmentjük itt

                    ev.Player.Broadcast(10, "<b><color=purple>Az üzenet sikeresen elküldve!</color></b>", shouldClearPrevious: true);

                    foreach (Player player in Player.List)
                    {
                        if (player.Role.Type == RoleTypeId.ClassD || player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard)
                        {
                            player.Broadcast(10, $"<b><color=#FF00FF>{ev.Player.Nickname}</color> <color=orange>el akarja hagyni az SCP szerepét! \n Írd be a</color> <color=red>.scpjoin scp096</color> <color=yellow>parancsot, hogy átvedd a helyét!</b>");
                        }
                    }
                }
                else if (ev.Player.Role.Type == RoleTypeId.Scp939 && hasznalat939 < 1)
                {
                        ev.Player.SendConsoleMessage("Az üzenet sikeresen elküldve", "green");

                            hasznalat939++;

                    volt939 = ev.Player; // elmentjük itt is 

                    ev.Player.Broadcast(10,"<b><color=purple>Az üzenet sikeresen elküldve!</color></b>" , shouldClearPrevious: true);

                    foreach (Player player in Player.List)
                    {
                        if (player.Role.Type == RoleTypeId.ClassD || player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard)
                        {
                            player.Broadcast(10, $"<b><color=#FF00FF>{ev.Player.Nickname}</color> <color=orange>el akarja hagyni az SCP szerepét! \n Írd be a</color> <color=red>.scpjoin scp939</color> <color=yellow>parancsot, hogy átvedd a helyét!</b>");
                        }
                    }
                }
                else if (ev.Player.Role.Type == RoleTypeId.Scp106 && hasznalat106 < 1)
                {
                        ev.Player.SendConsoleMessage("Az üzenet sikeresen elküldve", "green");

                            hasznalat106++;

                    volt106 = ev.Player;// itt is

                    ev.Player.Broadcast(10,"<b><color=purple>Az üzenet sikeresen elküldve!</color></b>", shouldClearPrevious: true);

                    foreach (Player player in Player.List)
                    {
                        if (player.Role.Type == RoleTypeId.ClassD || player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard)
                        {
                            player.Broadcast(10, $"<b><color=#FF00FF>{ev.Player.Nickname}</color> <color=orange>el akarja hagyni az SCP szerepét! \n Írd be a</color> <color=red>.scpjoin scp106</color> <color=yellow>parancsot, hogy átvedd a helyét!</b>");
                        }
                    }
                }
                else if (ev.Player.Role.Type == RoleTypeId.Scp049 && hasznalat049 < 1)
                {

                        ev.Player.SendConsoleMessage("Az üzenet sikeresen elküldve", "green");

                            hasznalat049++;

                    volt049 = ev.Player;

                    ev.Player.Broadcast(10,"<b><color=purple>Az üzenet sikeresen elküldve!</color></b>", shouldClearPrevious: true);

                    foreach (Player player in Player.List)
                    {
                        if (player.Role.Type == RoleTypeId.ClassD || player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard)
                        {
                            player.Broadcast(10, $"<b><color=#FF00FF>{ev.Player.Nickname}</color> <color=orange>el akarja hagyni az SCP szerepét! \n Írd be a</color> <color=red>.scpjoin scp049</color> <color=yellow>parancsot, hogy átvedd a helyét!</b>");
                        }
                    }

                }
                else if (ev.Player.Role.Type == RoleTypeId.Scp079 && hasznalat079 < 1)
                {
                        ev.Player.SendConsoleMessage("Az üzenet sikeresen elküldve", "green");

                            hasznalat079++;

                    volt079 = ev.Player;

                    ev.Player.Broadcast(10,"<b><color=purple>Az üzenet sikeresen elüldve!</color></b>", shouldClearPrevious: true);

                    foreach (Player player in Player.List)
                    {
                        if (player.Role.Type == RoleTypeId.ClassD || player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard)
                        {
                            player.Broadcast(10, $"<b><color=#FF00FF>{ev.Player.Nickname}</color> <color=orange>el akarja hagyni az SCP szerepét! \n Írd be a</color> <color=red>.scpjoin scp079</color> <color=yellow>parancsot, hogy átvedd a helyét!</b>");
                        }
                    }
                }
                }
                }

                if (ev.Player.Role.Type == RoleTypeId.ClassD && ev.Query == "scpjoin scp173" && hasznalat173 == 1 && lehetoseg173 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp173);
                    volt173.Role.Set(RoleTypeId.ClassD); // Visszaállítja az eredeti szerepet

                    lehetoseg173++;
                }
                else if (ev.Player.Role.Type == RoleTypeId.ClassD && ev.Query == "scpjoin scp096" && hasznalat096 == 1 && lehetoseg096 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp096);
                    volt096.Role.Set(RoleTypeId.ClassD);

                    lehetoseg096++;
                }
                else if (ev.Player.Role.Type == RoleTypeId.ClassD && ev.Query == "scpjoin scp106" && hasznalat106 == 1 && lehetoseg106 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp106);
                    volt106.Role.Set(RoleTypeId.ClassD  );

                    lehetoseg106++;
                }
                else if (ev.Player.Role.Type == RoleTypeId.ClassD && ev.Query == "scpjoin scp049" && hasznalat049 == 1 && lehetoseg049 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp049);
                    volt049.Role.Set(RoleTypeId.ClassD);

                    lehetoseg049++;
                }
                else if (ev.Player.Role.Type == RoleTypeId.ClassD && ev.Query == "scpjoin scp079" && hasznalat079 == 1 && lehetoseg079 < 1)
                {

                    ev.Player.Role.Set(RoleTypeId.Scp079);
                    volt079.Role.Set(RoleTypeId.ClassD);

                    lehetoseg079++;
                }   
                else if (ev.Player.Role.Type == RoleTypeId.ClassD && ev.Query == "scpjoin scp939" && hasznalat939 == 1 && lehetoseg939 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp939);
                    volt939.Role.Set(RoleTypeId.ClassD);

                    lehetoseg939++;
                }
                else if(ev.Player.Role.Type == RoleTypeId.Scientist && ev.Query == "scpjoin scp173" && hasznalat173 == 1 && lehetoseg173 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp173);
                    volt173.Role.Set(RoleTypeId.ClassD);
                    lehetoseg173++;
                }
                else if(ev.Player.Role.Type == RoleTypeId.Scientist && ev.Query == "scpjoin scp096" && hasznalat096 == 1 && lehetoseg096 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp096);
                    volt096.Role.Set(RoleTypeId.Scientist);

                    lehetoseg096++;

                }
                else if(ev.Player.Role.Type == RoleTypeId.Scientist && ev.Query == "scpjoin scp106" && hasznalat106 == 1 && lehetoseg106 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp106);
                    volt106.Role.Set(RoleTypeId.Scientist);

                    lehetoseg106++;


                }
                else if(ev.Player.Role.Type == RoleTypeId.Scientist && ev.Query == "scpjoin scp049" && hasznalat049 == 1 && lehetoseg049 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp049);
                    volt049.Role.Set(RoleTypeId.Scientist);

                    lehetoseg049++;


                }
                else if(ev.Player.Role.Type == RoleTypeId.Scientist && ev.Query == "scpjoin scp079" && hasznalat079 == 1 && lehetoseg079 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp079);
                    volt079.Role.Set(RoleTypeId.Scientist);

                    lehetoseg079++;


                }
                else if(ev.Player.Role.Type == RoleTypeId.Scientist && ev.Query == "scpjoin scp939" && hasznalat939 == 1 && lehetoseg939 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp939);
                    volt939.Role.Set(RoleTypeId.Scientist);

                    lehetoseg939++;



                }
                else if(ev.Player.Role.Type == RoleTypeId.FacilityGuard && ev.Query == "scpjoin scp173" && hasznalat173 == 1 && lehetoseg173 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp173);
                    volt173.Role.Set(RoleTypeId.FacilityGuard);
                    lehetoseg173++;


                }
                else if(ev.Player.Role.Type == RoleTypeId.FacilityGuard && ev.Query == "scpjoin scp096" && hasznalat096 == 1 && lehetoseg096 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp096);
                    volt096.Role.Set(RoleTypeId.FacilityGuard);

                    lehetoseg096++;


                }
                else if(ev.Player.Role.Type == RoleTypeId.FacilityGuard && ev.Query == "scpjoin scp106" && hasznalat106 == 1 && lehetoseg106 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp106);
                    volt106.Role.Set(RoleTypeId.Scientist);

                    lehetoseg106++;


                }
                else if(ev.Player.Role.Type == RoleTypeId.FacilityGuard && ev.Query == "scpjoin scp049" && hasznalat049 == 1 && lehetoseg049 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp049);
                    volt049.Role.Set(RoleTypeId.FacilityGuard);

                    lehetoseg049++;


                }
                else if(ev.Player.Role.Type == RoleTypeId.FacilityGuard && ev.Query == "scpjoin scp079" && hasznalat079 == 1 && lehetoseg079 < 1)
                {

                    ev.Player.Role.Set(RoleTypeId.Scp079);
                    volt079.Role.Set(RoleTypeId.FacilityGuard);

                    lehetoseg079++;


                }
                else if(ev.Player.Role.Type == RoleTypeId.FacilityGuard && ev.Query == "scpjoin scp939" && hasznalat939 == 1 && lehetoseg939 < 1)
                {
                    ev.Player.Role.Set(RoleTypeId.Scp939);
                    volt939.Role.Set(RoleTypeId.FacilityGuard);

                    lehetoseg939++;


                }
            }

            if (ev.Player.Role.Type == RoleTypeId.Scp173 && ev.Player.Health > 4200)
            {
                if (ev.Query == "scpswap scp096" && swap173to096 < 1)
                {

                    swap173to096++;
                    volt173 = ev.Player;


                    if (swap096to173 == 1)
                    { 
                    
                        volt096.Role.Set(RoleTypeId.Scp173);
                        volt173.Role.Set(RoleTypeId.Scp096);
                    
                    }

                }
                else if (ev.Query == "scpswap scp939" && swap173to939 < 1)
                {
                    swap173to939++;
                    volt173 = ev.Player;


                    if (swap939to173 == 1)
                    { 
                   
                    
                        

                        volt173.Role.Set(RoleTypeId.Scp939);
                        volt939.Role.Set(RoleTypeId.Scp173);
                 
                    }

                }
                else if (ev.Query == "scpswap scp049" && swap173to049 < 1)
                {
                    swap173to049++;
                    volt173 = ev.Player;

                    if (swap049to173 == 1)
                    {                         
                        volt173.Role.Set(RoleTypeId.Scp049);
                        volt049.Role.Set(RoleTypeId.Scp173);                    
                    }

                }
                else if (ev.Query == "scpswap scp079" && swap173to079 < 1)
                {
                    swap173to079++;
                    volt173 = ev.Player;

                    if (swap079to173 == 1)
                    {
                                                                
                        volt173.Role.Set(RoleTypeId.Scp079);
                        volt079.Role.Set(RoleTypeId.Scp173);

                    }

                    

                }
                else if (ev.Query == "scpswap scp106" && swap173to106 < 1)
                {
                    swap173to106++;
                    volt173 = ev.Player;

                    if (swap106to173 == 1)
                    { 
                                                                
                        volt173.Role.Set(RoleTypeId.Scp106);
                        volt106.Role.Set(RoleTypeId.Scp173);                    
                    }

                }
            }
            else if (ev.Player.Role.Type == RoleTypeId.Scp096 && ev.Player.Health > 2200)
            {


                if (ev.Query == "scpswap scp173" && swap096to173 < 1)
                {
                    swap096to173++;
                    volt096 = ev.Player;

                    if (swap173to096 == 1)
                    { 
                        
                        volt096.Role.Set(RoleTypeId.Scp173);
                        volt173.Role.Set(RoleTypeId.Scp096);
                    
                    }
                }
                else if (ev.Query == "scpswap scp939" && swap096to939 < 1)
                {
                    swap096to939++;
                    volt096 = ev.Player;

                    if (swap939to096 == 1)
                    {
                                                                                  
                        volt096.Role.Set(RoleTypeId.Scp939);
                        volt939.Role.Set(RoleTypeId.Scp096);                                       

                    }

                }
                else if (ev.Query == "scpswap scp049" && swap096to049 < 1)
                {
                    swap096to049++;
                    volt096 = ev.Player;

                    if (swap049to096 == 1)
                    { 
                                                                
                        volt049.Role.Set(RoleTypeId.Scp096);
                        volt096.Role.Set(RoleTypeId.Scp049);                    
                    }

                }
                else if (ev.Query == "scpswap scp079" && swap096to079 < 1)
                {
                    swap096to079++;
                    volt096 = ev.Player;

                    if (swap079to096 == 1)
                    { 

                    
                    
                        

                        volt096.Role.Set(RoleTypeId.Scp079);
                        volt079.Role.Set(RoleTypeId.Scp096);

                    }
                    

                }
                else if (ev.Query == "scpswap scp106" && swap096to106 < 1)
                {
                    swap096to106++;
                    volt096 = ev.Player;
                    if (swap106to096 == 1)
                    { 

                    
                        

                        volt096.Role.Set(RoleTypeId.Scp106);
                        volt106.Role.Set(RoleTypeId.Scp096);
                    
                   
                    }

                }
            }
            else if (ev.Player.Role.Type == RoleTypeId.Scp939 && ev.Player.Health > 2500)
            {
                if (ev.Query == "scpswap scp173" && swap939to173 < 1)
                {
                    swap939to173++;
                    volt939 = ev.Player;


                    if (swap173to939 == 1)
                    { 

                   
                        

                        volt939.Role.Set(RoleTypeId.Scp173);
                        volt173.Role.Set(RoleTypeId.Scp939);

                    
                   
                    }
                }
                else if (ev.Query == "scpswap scp096" && swap939to096 < 1)
                {
                    swap939to096++;
                    volt939 = ev.Player;
                    if (swap096to939 == 1)
                    { 

                   
                        

                        volt939.Role.Set(RoleTypeId.Scp096);
                        volt096.Role.Set(RoleTypeId.Scp939);


                    
                   
                    }

                }
                else if (ev.Query == "scpswap scp049" && swap939to049 < 1)
                {
                    swap939to049++;
                    volt939 = ev.Player;
                    if(swap049to939 == 1)
                    { 

                  
                        

                        volt939.Role.Set(RoleTypeId.Scp049);
                        volt049.Role.Set(RoleTypeId.Scp939);

  

                    }
                }
                else if (ev.Query == "scpswap scp079" && swap939to079 < 1)
                {
                    swap939to079++;
                    volt939 = ev.Player;
                    if(swap079to939 == 1)
                    { 

                   
                        
                        volt939.Role.Set(RoleTypeId.Scp079);
                        volt079.Role.Set(RoleTypeId.Scp939);

                  

                    }
                }
                else if (ev.Query == "scpswap scp106" && swap939to106 < 1)
                {
                    swap939to106++;
                    volt939 = ev.Player;
                    if (swap106to939 == 1)
                    { 

                   
                        
                        volt939.Role.Set(RoleTypeId.Scp106);
                        volt106.Role.Set(RoleTypeId.Scp939);

                   
                    }

                }
            }
            else if (ev.Player.Role.Type == RoleTypeId.Scp106 && ev.Player.Health > 2100)
            {
                if (ev.Query == "scpswap scp173" && swap106to173 < 1)
                {
                    swap106to173++;
                    volt106 = ev.Player;

                    if (swap173to106 == 1)
                    {

                                                              

                        volt106.Role.Set(RoleTypeId.Scp173);
                        volt173.Role.Set(RoleTypeId.Scp106);
                   
                    }
                }
                else if (ev.Query == "scpswap scp096" && swap106to096 < 1)
                {
                    swap106to096++;
                    volt106 = ev.Player;
                    if (swap096to106 == 1)
                    { 

                    
                         // Beállítjuk a 106-ot, ha még nincs beállítva
                        volt106.Role.Set(RoleTypeId.Scp096);
                        volt096.Role.Set(RoleTypeId.Scp106);
                   
                    }
                }
                else if (ev.Query == "scpswap scp939" && swap106to939 < 1)
                {
                    swap106to939++;
                    volt106 = ev.Player;
                    if (swap939to106 == 1)
                    { 

                   
                        // Beállítjuk a 106-ot, ha még nincs beállítva
                        volt106.Role.Set(RoleTypeId.Scp939);
                        volt939.Role.Set (RoleTypeId.Scp106);
                   
                    }
                }
                else if (ev.Query == "scpswap scp049" && swap106to049 < 1)
                {
                    swap106to049++;
                    volt106 = ev.Player;

                    if (swap049to106 == 1)
                    { 

                    
                         // Beállítjuk a 106-ot, ha még nincs beállítva
                        volt106.Role.Set(RoleTypeId.Scp049);
                        volt049.Role.Set(RoleTypeId.Scp106);
                   
                    }
                }
                else if (ev.Query == "scpswap scp079" && swap106to079 < 1)
                {
                    swap106to079++;
                    volt106 = ev.Player;

                    if (swap079to106 == 1)
                    { 
                   
                        // Beállítjuk a 106-ot, ha még nincs beállítva

                        volt106.Role.Set(RoleTypeId.Scp079);
                        volt079.Role.Set(RoleTypeId.Scp106);
                   
                    }
                }
            }
            else if (ev.Player.Role.Type == RoleTypeId.Scp049 && ev.Player.Health > 1800)
            {
                if (ev.Query == "scpswap scp049" && swap049to173 < 1)
                {
                    swap049to173++;
                    volt049 = ev.Player;

                    if (swap173to049 == 1)
                    { 

                    
                         // Beállítjuk a 049-et, ha még nincs beállítva

                        volt049.Role.Set(RoleTypeId.Scp173);
                        volt173.Role.Set(RoleTypeId.Scp049);
                   
                    }
                }
                else if (ev.Query == "scpswap scp096" && swap049to096 < 1)
                {
                    swap049to096++;
                    volt049 = ev.Player;

                    if (swap096to049 == 1)
                    { 

                  
                         // Beállítjuk a 049-et, ha még nincs beállítva

                        volt049.Role.Set(RoleTypeId.Scp096);
                        volt096.Role.Set(RoleTypeId.Scp049);
                   
                    }
                }
                else if (ev.Query == "swapscp scp939" && swap049to939 < 1)
                {
                    swap049to939++;
                    volt049 = ev.Player;

                    if (swap939to049 == 1)
                    { 

                   
                        // Beállítjuk a 049-et, ha még nincs beállítva

                        volt049.Role.Set(RoleTypeId.Scp939);
                        volt939.Role.Set(RoleTypeId.Scp049);
                   
                    }
                }
                else if (ev.Query == "scpswap scp106" && swap049to106 < 1)
                {
                    swap049to106++;
                    volt049 = ev.Player;

                    if (swap106to049 == 1)
                    { 
                   
                        // Beállítjuk a 049-et, ha még nincs beállítva

                        volt049.Role.Set(RoleTypeId.Scp106);
                        volt106.Role.Set(RoleTypeId.Scp049);
                    }
                    
                    
                }
                else if (ev.Query == "scpswap scp079" && swap049to079 < 1)
                {
                    swap049to079++;
                    volt049 = ev.Player;

                    if (swap079to049 == 1)
                    { 
                   
                         // Beállítjuk a 049-et, ha még nincs beállítva

                        volt049.Role.Set(RoleTypeId.Scp079);
                        volt079.Role.Set(RoleTypeId.Scp049);
                   
                    }
                }
            }
            else if (ev.Player.Role.Type == RoleTypeId.Scp079)
            {
                if (ev.Query == "scpswap scp173" && swap079to173 < 1)
                {
                    swap079to173++;
                    volt079 = ev.Player;
                    if (swap173to079 == 1)
                    { 

                   
                         // Beállítjuk a 079-et, ha még nincs beállítva
                        volt079.Role.Set(RoleTypeId.Scp173);
                        volt173.Role.Set(RoleTypeId.Scp079);
                   
                    }
                }
                else if (ev.Query == "scpswap scp096" && swap079to096 < 1)
                {
                    swap079to096++;
                    volt079 = ev.Player;

                    if (swap096to079 == 1)
                    { 

                    
                         // Beállítjuk a 079-et, ha még nincs beállítva
                        volt079.Role.Set(RoleTypeId.Scp096);
                        volt096.Role.Set(RoleTypeId.Scp079);
                   
                    }
                }
                else if (ev.Query == "scpswap scp939" && swap079to939 < 1)
                {
                    swap079to939++;
                    volt079 = ev.Player;

                    if (swap939to079 == 1)
                    { 

                         // Beállítjuk a 079-et, ha még nincs beállítva
                        volt079.Role.Set(RoleTypeId.Scp939);
                        volt939.Role.Set(RoleTypeId.Scp079);
                   
                    }
                }
                else if (ev.Query == "scpswap scp106" && swap079to106 < 1)
                {
                    swap079to106++;
                    volt079 = ev.Player;

                    if (swap106to079 == 1)
                    { 

                   
                         // Beállítjuk a 079-et, ha még nincs beállítva

                        volt079.Role.Set(RoleTypeId.Scp106);
                        volt106.Role.Set(RoleTypeId.Scp079);
                  
                    }
                }
                else if (ev.Query == "scpswap scp049" && swap079to049 < 1)
                {
                    swap079to049++;
                    volt079 = ev.Player;

                    if (swap049to079 == 1)
                    { 

                   
                         // Beállítjuk a 079-et, ha még nincs beállítva
                        volt079.Role.Set(RoleTypeId.Scp049);
                        volt049.Role.Set(RoleTypeId.Scp079);
                   
                    }
                }
            }
        }

        public static void OnRoundEnded(RoundEndedEventArgs ev)
        {
            hasznalat049 = 0;
            hasznalat079 = 0;
            hasznalat096 = 0;
            hasznalat106 = 0;
            hasznalat173 = 0;
            hasznalat939 = 0;
            
            lehetoseg049 = 0;
            lehetoseg079 = 0;
            lehetoseg096 = 0;
            lehetoseg106 = 0;
            lehetoseg173 = 0;
            lehetoseg939 = 0;

            volt049 = null;
            volt079 = null;
            volt096 = null;
            volt106 = null;
            volt173 = null;
            volt939 = null;

            isLeaveAllowed = false; // Reset leave state

            swap106to173 = 0;
            swap106to079 = 0;
            swap106to049 = 0;
            swap106to939 = 0;
            swap106to096 = 0;

            swap173to106 = 0;
            swap173to079 = 0;
            swap173to049 = 0;
            swap173to939 = 0;
            swap173to096 = 0;

            swap079to106 = 0;
            swap079to173 = 0;
            swap079to049 = 0;
            swap079to939 = 0;
            swap079to096 = 0;
            swap049to106 = 0;
            swap049to173 = 0;
            swap049to079 = 0;
            swap049to939 = 0;
            swap049to096 = 0;
            swap939to106 = 0;
            swap939to173 = 0;
            swap939to079 = 0;
            swap939to049 = 0;
            swap939to096 = 0;
            swap096to106 = 0;
            swap096to173 = 0;
            swap096to079 = 0;
            swap096to049 = 0;
            swap096to939 = 0;
        }
    }
}