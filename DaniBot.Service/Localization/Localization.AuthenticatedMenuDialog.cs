namespace Avanade.HackathonAzul.DaniBot.Localization
{
    public partial struct Localization
    {
        public AuthenticatedMenuMessages AuthenticatedMenuDialog { get; set; }

        public partial struct AuthenticatedMenuMessages
        {
            public string Statements { get; set; }

            public PromoMessages PromoCardMessages { get; set; }

            public struct PromoMessages
            {
                public string YourBalanceIs { get; set; }
            }
        }
    }
}