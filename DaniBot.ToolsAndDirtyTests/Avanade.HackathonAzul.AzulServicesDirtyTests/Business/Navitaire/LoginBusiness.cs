using Avanade.HackathonAzul.AzulServicesDirtyTests.Integration.Navitaire;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Login.Request;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Login.Response;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests.Business.Navitaire
{
    public class LoginBusiness
    {
        private static string _userName = "mobileadruser";
        private static string _password = "aZUL1AndE";
        private static string _domain = "EXT";
        private static string _location = "Web";
        private static string _channelType = "Web";
        private static string _uri = "/api/nsk/v1/token";

        private NavitaireRestIntegration _integration;

        public LoginBusiness()
        {
            _integration = new NavitaireRestIntegration();
        }

        public async Task<string> LogonAndGetTokenNavitaire(string userName = null, string password = null)
        {
            string result = default(string);
            LogonRequest request = GetRequestLogon(userName, password);

            string responseJson = await _integration.RequestAsync(HttpMethod.Post, _uri, request);
            LogonResponse responseObject = JsonConvert.DeserializeObject<LogonResponse>(responseJson);

            if (!string.IsNullOrEmpty(responseObject?.Data?.Token)) { result = responseObject.Data.Token; }
            return result;
        }

        public LogonRequest GetRequestLogon(string userName = null, string passWord = null)
        {
            return new LogonRequest()
            {
                credentials = new CredentialsLogonRequest()
                {
                    UserName = string.IsNullOrWhiteSpace(userName) ? _userName : userName,
                    Password = string.IsNullOrWhiteSpace(passWord) ? _password : userName,
                    Domain = _domain,
                    Location = _location,
                    ChannelType = _channelType,
                    AlternateIdentifier = string.Empty
                },
                applicationName = string.Empty
            };
        }

    }
}


