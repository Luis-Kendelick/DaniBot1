namespace Avanade.HackathonAzul.DaniBot.Localization
{
	public partial struct Localization
	{
		public MainMessages MainDialog { get; set; }

		public struct MainMessages
		{
			public string Welcome { get; set; }
            public string LocalizarVoo { get; set; }
            public string RealizarCadastro { get; set; }
            public string FAQ { get; set; }
            public string ResetSenha { get; set; }
            public string Login { get; set; }
        }
	}
}
