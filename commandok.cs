using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommandSystem;
using PlayerRoles;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using ScpSwapp;


namespace ScpSwapp
{



    [CommandHandler(typeof(ClientCommandHandler))]
    public class commandok173 : CommandSystem.ICommand
    {
        public string Command => "scpswap";  // A parancs neve
        public string[] Aliases => new[] { "swap173" };

        public Type CommandType => typeof(ClientCommandHandler);
        public string Description => "swaps the classes";


        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpswap scp(scpszam)";
                return false;
            }


            string role = arguments.At(0);



            if(role == "scp096" || role == "scp049" || role == "scp939" || role == "scp079" || role == "scp106")
            { 

            if (player.Role.Type == RoleTypeId.Scp173)
            {
                // Ha SCP szereplő, akkor végrehajtjuk a logikát
                response = "Parancs végrehajtva!";

                return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
            }
            else if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
            {
                response = "Nem vagy scp";
                return false;

            }
            else
            {
                response = "Nem sikeres";
                return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
            }
            }
            else { 

                response = "Magaddal nem cserélhetsz!";
                return false;
            }
        }
            
            
            



        }
    [CommandHandler(typeof(ClientCommandHandler))]
    public class commandok096 : CommandSystem.ICommand
    {
        public string Command => "scpswap";  // A parancs neve
        public string[] Aliases => new[] { "swap096" };
        public Type CommandType => typeof(ClientCommandHandler);

        public string Description => "swaps the classes";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpswap scp(scpszam)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp173" || role == "scp049" || role == "scp939" || role == "scp079" || role == "scp106")
            {

                if (player.Role.Type == RoleTypeId.Scp096)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    response = "Nem vagy scp";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "Magaddal nem cserélhetsz!";
                return false;
            }
        }


    }
    [CommandHandler(typeof(ClientCommandHandler))]
    public class commandok049 : CommandSystem.ICommand
    {
        public string Command => "scpswapscp049";  // A parancs neve
        public string[] Aliases => new[] { "swap049" };
        public Type CommandType => typeof(ClientCommandHandler);

        public string Description => "swaps the classes";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpswap scp(scpszam)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp096" || role == "scp173" || role == "scp939" || role == "scp079" || role == "scp106")
            {

                if (player.Role.Type == RoleTypeId.Scp049)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    response = "Nem vagy scp";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "Magaddal nem cserélhetsz!";
                return false;
            }
        }


    }
    [CommandHandler(typeof(ClientCommandHandler))]
    public class commandok079 : CommandSystem.ICommand
    {
        public string Command => "scpswapscp079";  // A parancs neve
        public string[] Aliases => new[] { "swap079" };
        public Type CommandType => typeof(ClientCommandHandler);

        public string Description => "swaps the classes";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpswap scp(scpszam)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp096" || role == "scp049" || role == "scp939" || role == "scp173" || role == "scp106")
            {

                if (player.Role.Type == RoleTypeId.Scp079)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    response = "Nem vagy scp";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "Magaddal nem cserélhetsz!";
                return false;
            }
        }


    }
    [CommandHandler(typeof(ClientCommandHandler))]
    public class commandok106 : CommandSystem.ICommand
    {
        public string Command => "scpswapscp106";  // A parancs neve
        public string[] Aliases => new[] { "swap106" };
        public Type CommandType => typeof(ClientCommandHandler);

        public string Description => "swaps the classes";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpswap scp(scpszam)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp096" || role == "scp049" || role == "scp939" || role == "scp079" || role == "scp173")
            {

                if (player.Role.Type == RoleTypeId.Scp106)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    response = "Nem vagy scp";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "Magaddal nem cserélhetsz!";
                return false;
            }
        }


    }
    [CommandHandler(typeof(ClientCommandHandler))]
    public class commandok939 : CommandSystem.ICommand
    {
        public string Command => "scpswapscp939";  // A parancs neve
        public string[] Aliases => new[] { "swap939" };
        public Type CommandType => typeof(ClientCommandHandler);

        public string Description => "swaps the classes";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpswap scp(scpszam)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp096" || role == "scp049" || role == "scp173" || role == "scp079" || role == "scp106")
            {

                if (player.Role.Type == RoleTypeId.Scp939)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    response = "Nem vagy scp";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "Magaddal nem cserélhetsz!";
                return false;
            }
        }


    }

    [CommandHandler(typeof(ClientCommandHandler))]

    public class Commandokleave : CommandSystem.ICommand
    {
        public string Command => "scpleave";  // A parancs neve
        public string[] Aliases => new[] { "newcommandsleave" };
        public string Description => "scpnewconsolecommands";
        public Type CommandType => typeof(ClientCommandHandler);

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (EventHandlers.isLeaveAllowed == false) // Ugyanaz, mint isLeaveAllowed == false
            {
                response = "Most nem lehet kilépni.";
                return false;
            }

            else if (EventHandlers.isLeaveAllowed == true)
            {
            
            if (player.Role.Type == RoleTypeId.Scp079 || player.Role.Type == RoleTypeId.Scp939 || player.Role.Type == RoleTypeId.Scp049 || player.Role.Type == RoleTypeId.Scp106 || player.Role.Type == RoleTypeId.Scp096 || player.Role.Type == RoleTypeId.Scp173)
            {
                response = "Parancs végrehajtva!";
                return true;
            }
            else
            {
                response = "Nem vagy SCP.";
                return false;
            }

            }else
            {
                response = "HIBA";
                return false;
            }


        }

    }


    [CommandHandler(typeof(ClientCommandHandler))]

    public class Commandokjoin173 : CommandSystem.ICommand
    {
        public string Command => "scpjoin";  // A parancs neve
        public string[] Aliases => new[] { "newcommands173" };
        public string Description => "scpnewconsolecommands";
        public Type CommandType => typeof(ClientCommandHandler);

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpjoin scp(scpszám)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp096" || role == "scp049" || role == "scp939" || role == "scp079" || role == "scp106" || role == "scp173")
            {

                if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.IsScp)
                {
                    response = "Használd inkább a scpswap scp(scpszam) parancsot";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "HIBA";
                return false;
            }

        }
    }
    [CommandHandler(typeof(ClientCommandHandler))]

    public class Commandokjoin096 : CommandSystem.ICommand
    {
        public string Command => "scpjoin";  // A parancs neve
        public string[] Aliases => new[] { "newcommands096" };
        public string Description => "scpnewconsolecommands";
        public Type CommandType => typeof(ClientCommandHandler);

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpjoin scp(scpszám)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp096" || role == "scp049" || role == "scp939" || role == "scp079" || role == "scp106" || role == "scp173")
            {

                if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.IsScp)
                {
                    response = "Használd inkább a scpswap scp(scpszam) parancsot";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "HIBA";
                return false;
            }

        }
    }

    [CommandHandler(typeof(ClientCommandHandler))]

    public class Commandokjoin049 : CommandSystem.ICommand
    {
        public string Command => "scpjoin";  // A parancs neve
        public string[] Aliases => new[] { "newcommands049" };
        public string Description => "scpnewconsolecommands";
        public Type CommandType => typeof(ClientCommandHandler);

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpjoin scp(scpszám)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp096" || role == "scp049" || role == "scp939" || role == "scp079" || role == "scp106" || role == "scp173")
            {

                if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.IsScp)
                {
                    response = "Használd inkább a scpswap scp(scpszam) parancsot";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "HIBA";
                return false;
            }


        }
    }
    [CommandHandler(typeof(ClientCommandHandler))]

    public class Commandokjoin106 : CommandSystem.ICommand
    {
        public string Command => "scpjoin";  // A parancs neve
        public string[] Aliases => new[] { "newcommands106" };
        public string Description => "scpnewconsolecommands";
        public Type CommandType => typeof(ClientCommandHandler);

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpjoin scp(scpszám)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp096" || role == "scp049" || role == "scp939" || role == "scp079" || role == "scp106" || role == "scp173")
            {

                if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.IsScp)
                {
                    response = "Használd inkább a scpswap scp(scpszam) parancsot";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "HIBA";
                return false;
            }


        }
    }
    [CommandHandler(typeof(ClientCommandHandler))]

    public class Commandokjoin079 : CommandSystem.ICommand
    {
        public string Command => "scpjoin";  // A parancs neve
        public string[] Aliases => new[] { "newcommands079" };
        public string Description => "scpnewconsolecommands";
        public Type CommandType => typeof(ClientCommandHandler);

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpjoin scp(scpszám)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp096" || role == "scp049" || role == "scp939" || role == "scp079" || role == "scp106" || role == "scp173")
            {

                if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.IsScp)
                {
                    response = "Használd inkább a scpswap scp(scpszam) parancsot";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "HIBA";
                return false;
            }


        }
    }



    [CommandHandler(typeof(ClientCommandHandler))]

    public class Commandokjoin939 : CommandSystem.ICommand
    {
        public string Command => "scpjoin";  // A parancs neve
        public string[] Aliases => new[] { "newcommands939" };
        public string Description => "scpnewconsolecommands";
        public Type CommandType => typeof(ClientCommandHandler);

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (arguments.Count < 1)
            {
                response = "Használat: scpjoin scp(scpszám)";
                return false;
            }


            string role = arguments.At(0);



            if (role == "scp096" || role == "scp049" || role == "scp939" || role == "scp079" || role == "scp106" || role == "scp173")
            {

                if (player.Role.Type == RoleTypeId.Scientist || player.Role.Type == RoleTypeId.FacilityGuard || player.Role.Type == RoleTypeId.ClassD)
                {
                    // Ha SCP szereplő, akkor végrehajtjuk a logikát
                    response = "Parancs végrehajtva!";

                    return true; // Visszatérünk true-val, hogy sikeres a végrehajtás
                }
                else if (player.IsScp)
                {
                    response = "Használd inkább a scpswap scp(scpszam) parancsot";
                    return false;

                }
                else
                {
                    response = "Nem sikeres";
                    return false; // Ez szükséges, hogy minden kódútvonalon visszaadjunk egy bool értéket.
                }
            }
            else
            {

                response = "HIBA";
                return false;
            }

        }
    }



}