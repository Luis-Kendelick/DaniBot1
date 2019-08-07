using Azul.TudoAzul;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azul.TudoAzul.Comarch.Interfaces
{
    /// <summary>
    /// Comarch Service Interface.
    /// </summary>
    public interface IComarchService
    {
        //TODO: porque esse método não está sendo utilizado, remover.
        /// <summary>
        /// Gets the transactions asynchronous.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="identifierId">The identifier identifier.</param>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <returns></returns>
        Task<getTransactionsResponse1> GetTransactionsAsync(long accountId, long customerId, long identifierId, DateTime dateFrom, DateTime dateTo);

        /// <summary>
        /// Adds the points asynchronous.
        /// </summary>
        /// <param name="identifierNo">The identifier no.</param>
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
        Task<processNonAirTransactionResponse1> AddPointsAsync(
            string identifierNo,
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
        );

        Task<reverseTransactionResponse1> CancelTransactionAsync(
            long transactionId, 
            string partner, 
            string partnerTransactionNumber, 
            string comment, 
            string loginPartner, 
            string passwordPartner
        );


    }
}