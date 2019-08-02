using System;
using Azul.PontualidadeANAC;
using Azul.TudoAzul;
using Navitaire.SessionManagement;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceListarHistoricoAnacClient
            //    anacClient = new ServiceListarHistoricoAnacClient();
            //CLMServiceClient clmClient = new CLMServiceClient();

            ISessionManager sessionManager = new SessionManagerClient();
            LogonRequest logonRequest = new LogonRequest();
            string domain = "???";
            string username = "??????????????????";
            string password = "??????????????????";

            logonRequest.logonRequestData = new LogonRequestData
            {
                DomainCode = domain,
                AgentName = username,
                Password = password
            };

            LogonResponse logonResponse 
                = sessionManager.LogonAsync(logonRequest).Result;

            if (logonResponse != null && 
                logonResponse.Signature != null && 
                logonResponse.Signature != string.Empty) {
                Console.WriteLine("Completed Logon");
            }
            string _signature = logonResponse.Signature;
            Console.WriteLine($"Hello World: {_signature}");
        }
    }
}
