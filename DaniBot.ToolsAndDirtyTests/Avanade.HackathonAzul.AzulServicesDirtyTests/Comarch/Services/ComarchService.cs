using Azul.Framework.ServiceClient.Configuration;
using Azul.Framework.ServiceClient.Wcf;
using Azul.TudoAzul.Comarch.Interfaces;
using Azul.TudoAzul;
using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;
using System.Threading.Tasks;


namespace Azul.TudoAzul.Comarch
{
    /// <summary>Comarch Transactions Service Client Class.</summary>
    /// <seealso cref="Azul.Framework.ServiceClient.Wcf.BaseWcfServiceClient" />
    /// <seealso cref="Azul.TudoAzul.Partnership.Transactions.Infrastructure.Service.Comarch.Interfaces.IComarchService" />
    [ExcludeFromCodeCoverage]
    public class ComarchService : BaseWcfServiceClient, IComarchService
    {

  
        private static readonly object LockObject = new object();
        private static CLMServiceClient _comarchService;

        private readonly string _clientUsername;
        private readonly string _clientPassword;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComarchService"/> class.
        /// </summary>
        public ComarchService() : base("ComarchService")
        {

            if (ServiceSettings != null)
            {
                _clientUsername = ServiceSettings.Parameters.GetServiceParameter<string>("ClientUsername");
                _clientPassword = ServiceSettings.Parameters.GetServiceParameter<string>("ClientPassword");

                if (_comarchService == null)
                {
                    InitializeService();
                }

                if (_comarchService != null && (_comarchService.State == CommunicationState.Faulted || _comarchService.State == CommunicationState.Closed))
                {
                    lock (LockObject)
                    {
                        _comarchService = null;
                    }
                    InitializeService();
                }
            }
        }

        /// <summary>
        /// Initializes the service.
        /// </summary>
        private void InitializeService()
        {
            lock (LockObject)
            {
                if (_comarchService == null)
                {
                    _comarchService = new CLMServiceClient();
                    _comarchService.Endpoint.Address = new EndpointAddress(ServiceSettings.Address);
                    _comarchService.Endpoint.Binding.ReceiveTimeout = TimeSpan.FromSeconds(ServiceSettings.Timeout);
                    ((BasicHttpBinding)_comarchService.Endpoint.Binding).Security.Mode = GetBasicHttpSecurityMode();

                    var maxReceivedMessageSize = ServiceSettings.Parameters.GetServiceParameter<int>("MaxReceivedMessageSize");
                    ((BasicHttpBinding)_comarchService.Endpoint.Binding).MaxReceivedMessageSize = maxReceivedMessageSize > 0 ? maxReceivedMessageSize : int.MaxValue;

                    var maxBufferPoolSize = ServiceSettings.Parameters.GetServiceParameter<int>("MaxBufferPoolSize");
                    ((BasicHttpBinding)_comarchService.Endpoint.Binding).MaxBufferPoolSize = maxBufferPoolSize > 0 ? maxBufferPoolSize : int.MaxValue;

                    var maxBufferSize = ServiceSettings.Parameters.GetServiceParameter<int>("MaxBufferSize");
                    ((BasicHttpBinding)_comarchService.Endpoint.Binding).MaxBufferSize = maxBufferSize > 0 ? maxBufferSize : int.MaxValue;
                }
            }
        }

        /// <summary>
        /// Search customer data based on Id (Identifier Id).
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="identifierId">The identifier identifier.</param>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <returns></returns>
        //TODO: Arrumar contrato de saida, não pode retornar o objeto do proxy wcf. Realizar mapper para um objeto de response.
        public async Task<getTransactionsResponse1> GetTransactionsAsync(long accountId, long customerId, long identifierId, DateTime dateFrom, DateTime dateTo)
        {
            var userContext = new extUserContextView { clientLogin = _clientUsername, clientPass = _clientPassword, channel = "U", langCode = "pt" };

            getTransactionsResponse1 response = null;

            await Resilience.HandleAsync(async () =>
            {
                const int pageNr = 1;
                const int pageSize = 10;
                response = await _comarchService.getTransactionsAsync(userContext, accountId, customerId, identifierId, null, null, dateFrom, dateTo, null, pageNr, pageSize);

            }, "ComarchGetTransactions");

            return response?.@return == null ? null : response;
        }

        /// <summary>
        /// Adds the points asynchronous.
        /// </summary>
        /// <param name="identifierNumber">The identifier number.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="partner">The partner.</param>
        /// <param name="inputPoints">The input points.</param>
        /// <param name="comment">The comment.</param>
        /// <param name="partnerTransactionNumber">The partner transaction number.</param>
        /// <param name="transactionDate">The transaction date.</param>
        /// <param name="loginPartner">The login partner.</param>
        /// <param name="passwordPartner">The password partner.</param>
        /// <param name="promotionCode">The promotion code.</param>
        /// <returns></returns>
        public async Task<processNonAirTransactionResponse1> AddPointsAsync(
            string identifierNumber,
            string firstName,
            string lastName,
            string partner,
            long inputPoints,
            string comment,
            string partnerTransactionNumber,
            DateTime transactionDate,
            string loginPartner,
            string passwordPartner,
            string promotionCode
        )
        {
            var userContext = new extUserContextView { clientLogin = loginPartner, clientPass = passwordPartner, channel = "V", langCode = "pt" };

            processNonAirTransactionResponse1 response = null;

            await Resilience.HandleAsync(async () =>
            {
                //TODO: Usar AutoMapper para mapeamento de objetos.
                var transactionData = new wsNonAirTransactionRequest
                {
                    identifierNo = identifierNumber,
                    firstName = firstName,
                    lastName = lastName,
                    partner = partner,
                    inputPoints = inputPoints,
                    comment = comment,
                    partnerTransactionNo = partnerTransactionNumber,
                    date = transactionDate,
                    promotionCode = promotionCode
                };

                response = await _comarchService.processNonAirTransactionAsync(userContext, false, transactionData);

            }, "ComarchAddPoints");

            if (response?.@return == null)
            {
                return null;
            }

            return response;
        }

        public async Task<reverseTransactionResponse1> CancelTransactionAsync(
            long transactionId, string partner, string partnerTransactionNumber, string comment, string loginPartner, string passwordPartner
        )
        {
            var userContext = new extUserContextView { clientLogin = loginPartner, clientPass = passwordPartner, channel = "W", langCode = "pt" };

            reverseTransactionResponse1 response = null;
            var useLoan = false;

            await Resilience.HandleAsync(async () =>
            {
                response = await _comarchService.reverseTransactionAsync(userContext, transactionId, partner, partnerTransactionNumber, comment, useLoan);

            }, "ComarchCancelTransaction");

            if (response?.@return == null)
            {
                return null;
            }
            return response;
        }

 
  
        /// <summary>
        /// Debit the points asynchronous.
        /// </summary>
        /// <param name="identifierNumber">The identifier number.</param>
        /// <param name="prn">The prn number.</param>
        /// <param name="origin">The origin.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="Points">The points fro debit.</param>
        /// <param name="comment">The comment.</param>
        /// <param name="partnerTransactionNumber">The partner transaction number.</param>
        /// <param name="transactionDate">The transaction date.</param>
        /// <param name="loginPartner">The login partner.</param>
        /// <param name="passwordPartner">The password partner.</param>
        /// <returns></returns>
        public async Task<processDirectAirRedemptionResponse1> RedemptionPointsAsync(
            string identifierNumber,
            string prn,
            string origin,
            string destination,
            long inputPoints,
            string comment,
            string partnerTransactionNumber,
            DateTime departureDate
        )
        {

            var userContext = new extUserContextView { clientLogin = _clientUsername, clientPass = _clientPassword, langCode = "pt" };

            processDirectAirRedemptionResponse1 response = null;

            await Resilience.HandleAsync(async () =>
            {
                var transactionData = new extWSDirectAirRedemptionView
                {
                    identifierNo = identifierNumber,
                    partnerTransactionNo = partnerTransactionNumber,
                    departureDate = departureDate,
                    pnrNo = prn,
                    origin = origin,
                    destination = destination,
                    points = inputPoints,
                    comment = comment,
                    pointsSpecified = true

                };
                response = await _comarchService.processDirectAirRedemptionAsync(userContext, false, true, transactionData);

            }, "ComarchRedemptionPoints");

            if (response?.@return == null)
            {
                return null;
            }

            return response;
        }

        public async Task<getCustomerExtResponse1> GetCustomerByIdAsync(string customerNumber)
        {
            var userContext = new extUserContextView { clientLogin = _clientUsername, clientPass = _clientPassword, channel = "U", langCode = "pt" };

            getCustomerExtResponse1 response = null;

            await Resilience.HandleAsync(async () =>
            {
                response = await _comarchService.getCustomerExtAsync(userContext, 0, null, customerNumber);

            }, "ComarchGetCustomerExt");

            if (response?.@return == null)
            {
                throw new Exception();
            }

            return response;
        }

        public async Task<getBalanceResponse1> GetBalanceAsync(long customerId)
        {
            var userContext = new extUserContextView { clientLogin = _clientUsername, clientPass = _clientPassword, channel = "U", langCode = "pt" };

            getBalanceResponse1 response = null;

            await Resilience.HandleAsync(async () =>
            {
                response = await _comarchService.getBalanceAsync(userContext, customerId);

            }, "ComarchGetBalanceAsync");

            if (response?.@return == null)
            {
                throw new Exception();
            }

            return response;
        }

        public async Task<enrollCustomerExtResponse1> EnrollCustomerExtAsync(extWSRegistrationFormView customer)
        {
            var userContext = new extUserContextView { clientLogin = _clientUsername, clientPass = _clientPassword, channel = "U", langCode = "pt" };

            enrollCustomerExtResponse1 response = null;

            await Resilience.HandleAsync(async () =>
            {
                response = await _comarchService.enrollCustomerExtAsync(userContext, customer);

            }, "ComarchEnrollCustomerExtAsync");

            if (response?.@return == null)
            {
                throw new Exception();
            }

            return response;
        }

        public async Task<changePasswordResponse1> ChangePasswordAsync(long customerId, wsChangePasswordData changedPasswordData)
        {
            var userContext = new extUserContextView { clientLogin = _clientUsername, clientPass = _clientPassword, channel = "U", langCode = "pt" };

            changePasswordResponse1 response = null;

            await Resilience.HandleAsync(async () =>
            {
                response = await _comarchService.changePasswordAsync(userContext, customerId, changedPasswordData);

            }, "ComarchEnrollCustomerExtAsync");

            if (response == null)
            {
                throw new Exception();
            }

            return response;
        }

    }
}