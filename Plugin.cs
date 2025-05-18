using Exiled.API.Features;
using Exiled.Permissions.Commands.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Permissions.Commands;
using CommandSystem.Commands.RemoteAdmin;


namespace ScpSwapp
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "NOVA";

        public override string Name => "SCPLEAVE";


        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted += EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Player.SendingValidCommand += EventHandlers.OnSendingValidCommand;
            Exiled.Events.Handlers.Server.RoundEnded += EventHandlers.OnRoundEnded;


            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Player.SendingValidCommand -= EventHandlers.OnSendingValidCommand;
            Exiled.Events.Handlers.Server.RoundEnded -= EventHandlers.OnRoundEnded;
            base.OnDisabled();
        }

    }
}
