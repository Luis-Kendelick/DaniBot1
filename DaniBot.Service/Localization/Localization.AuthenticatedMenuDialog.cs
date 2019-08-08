using System;

namespace Avanade.HackathonAzul.DaniBot.Localization
{
    public partial struct Localization
    {
        public AuthenticatedMenuMessages AuthenticatedMenuDialog { get; set; }

        public partial struct AuthenticatedMenuMessages
        {
            public TudoAzulMessages TudoAzulCardMessages { get; set; }

            public struct TudoAzulMessages
            {
                public string YourBalanceIs { get; set; }
                public string Statements { get; set; }
                public string RedeemPoints { get; internal set; }
            }
        }
    }
}