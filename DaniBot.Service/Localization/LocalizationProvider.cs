using Avanade.HackathonAzul.DaniBot.Localization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace System
{
	public class LocalizationProvider
	{
		public enum ECultureType
		{
			pt_BR,
		}

		private static LocalizationProvider _Instance;
		private Dictionary<ECultureType, Localization> _LocalizationByLanguage;
		private ECultureType? _CurrentLanguage;
		private readonly static ECultureType _DEFAULT_LANGUAGE = ECultureType.pt_BR;
		private readonly static string _BASE_CONFIG_FILE_PATH = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Resources\Localization\messages.";

		private LocalizationProvider()
		{
		}

		public Localization GetLocalization()
		{
			return _LocalizationByLanguage[_GetCurrentLanguage()];
		}

		private ECultureType _GetCurrentLanguage()
		{
			return _CurrentLanguage ?? _DEFAULT_LANGUAGE;
		}

		public void SetLocalization(ECultureType cultureType)
		{
			_CurrentLanguage = cultureType;
		}
		public void Reset()
		{
			_CurrentLanguage = null;
		}

		public static LocalizationProvider Instance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new LocalizationProvider();
					_Read();
				}

				return _Instance;
			}
		}

		private static void _Read()
		{
			_Instance._LocalizationByLanguage = new Dictionary<ECultureType, Localization>();
			foreach (ECultureType cultureType in Enum.GetValues(typeof(ECultureType)))
				_Instance._LocalizationByLanguage.Add(cultureType, _ReadLocalization(cultureType));
		}

		private static Localization _ReadLocalization(ECultureType cultureType)
		{
			Localization localization;

			string path = _BASE_CONFIG_FILE_PATH + cultureType.ToString().ToLower().Replace("_", "-") + ".json";
			using (StreamReader reader = new StreamReader(path))
			{
				var json = reader.ReadToEnd();
				localization = JsonConvert.DeserializeObject<Localization>(json);
			}

			return localization;
		}
	}
}
