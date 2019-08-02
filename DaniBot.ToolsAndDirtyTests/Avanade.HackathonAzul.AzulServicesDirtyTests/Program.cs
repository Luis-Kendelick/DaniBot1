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
            //String username = "04490265409"; //thiagoburgo@gmail.com
            //String password = "Th1@g0bel0"; //r2ZtNu5ZnFdmkDv
            string domain = "ref";
            string username = "avanade.tbelo"; //thiagoburgo@gmail.com
            string password = "Th1@g0bel0"; //r2ZtNu5ZnFdmkDv

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
