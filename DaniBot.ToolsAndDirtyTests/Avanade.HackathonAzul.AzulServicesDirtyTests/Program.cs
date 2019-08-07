using Azul.TudoAzul;
using Navitaire.PersonManagement;
using Navitaire.SessionManagement;
using System;
using Nito.AsyncEx;
using System.Threading.Tasks;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Business;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Business.Navitaire;
using Azul.TudoAzul.Partnership.Transactions.Infrastructure.Service.Comarch.Services;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Response.Booking;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.SeatMap.Response;
using System.Collections.Generic;
using System.Linq;
using Avanade.HackathonAzul.AzulServicesDirtyTests.Model.Navitaire.Booking.Response;
using Azul.TudoAzul.Comarch;

namespace Avanade.HackathonAzul.AzulServicesDirtyTests
{
    /// <summary>
    /// CONTEXTO: ESTAMOS CRIANDO UM CHATBOT PARA UM HACKATHON NA AZUL E O CLIENTE SUGERIU
    /// ALGUNS SERVIÇOS SIMPLES QUE QUERIAM INTEGRAR COM O CHATBOT, NÃO PRECISMOS NOS LIMITAR A TAIS 
    /// SUGESTOES E AS INTEGRAÇÕES PODEM SER FEITAS DE MANEIRA A SEGUIR O CAMINHO FELIZ, UMA VEZ
    /// QUE VAI SERVIR COM UMA ESPÉCIE DE PROVA DE CONCEITO
    /// ===========================================================================
    /// AQUI TEM A DESCRIÇÃO ORIGINAL DAS SUGESTÕES DE INTEGRAÇÃO DA AZUL (EMAIL DO CLIENTE)
    /// ===========================================================================
    /// Abaixo os cenários solicitados pelo Christian e Victor para considerarmos no evento:
    /// Tudo Azul:
    /// 	- Cadastro (cliente envia CPF, perguntamos CEP, num residencia,complemento) email
    /// 	- Reset de Senha TA (perg CPF/Dt nasc...manda para email cadastrado)
    /// 	- Opt-in na PROMO (personalizado ao cliente ativo no chat)...cliente informa CPF, listamos as 
    /// campanhas ativas e pergunta em qual ele quer se cadastrar....efetua cadastro) e reforca cliente qe tem q transferir os pts
    /// 	- Solicitação de Retroclaim, validação positiva usando CPF
    /// 	- Extrato Tudo Azul (mesmo da nova APP), validação positiva usando CPF/Dt nascimoneento/
    ///  
    /// Serviços Navitaire
    /// 	- Marcação de assento (pergunta LOC, localiza voos, envia mapa de assento, cliente envia assento, marcamos)....se tiver que pagar manda uma URL com link para meio de pagto)
    /// 	- Posso levar Bags? (pergunta LOC, localiza voo, informa qtas tem direito, pergunta se quer comprar...se sim, envia link de pagto)
    /// 	- Flight Status: pergunta numero do voo, origem....devolve horario previsto e departure gate
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            //ISessionManager sessionManager = new SessionManagerClient();
            //LogonRequest logonRequest = new LogonRequest();
            //string domain = "SYS";
            //string username = "WebAnonymous";
            //string password = "^heWebP@ss";

            //logonRequest.logonRequestData = new LogonRequestData
            //{
            //    DomainCode = domain,
            //    AgentName = username,
            //    Password = password
            //};

            //LogonResponse logonResponse
            //    = sessionManager.LogonAsync(logonRequest).Result;

            //if (logonResponse != null &&
            //    logonResponse.Signature != null &&
            //    logonResponse.Signature != string.Empty)
            //{
            //    Console.WriteLine("Completed Logon");
            //}

            //string _signature = logonResponse.Signature;
            //Console.WriteLine($"Hello World: {_signature}");

            //AsyncContext.Run(CadastrarNoTudoAzul);
            //AsyncContext.Run(ResetarSenhaCliente);
            //AsyncContext.Run(ListarProximosVoosDeCliente);
            //AsyncContext.Run(ListarDetalhesDeUmVoo);
            //AsyncContext.Run(RealizarCheckin);
            //AsyncContext.Run(ConsultarAssentosDisponiveisEmUmVoo);
            //AsyncContext.Run(ComprarAssentoParaClienteEmUmVoo);
            //AsyncContext.Run(ComprarBagagemParaClienteEmUmVoo);
            //AsyncContext.Run(ConsultarPontuacaoTudoAzulCliente);
            //AsyncContext.Run(ConsultarExtratoPontuacaoTudoAzulCliente);
            //AsyncContext.Run(SolicitarPontosRetroclaimTudoAzulCliente);
            //AsyncContext.Run(ConsultarPromosDisponiveisCliente);
            //AsyncContext.Run(AderirPromo);


            Task.WaitAll(new Task[]
            {
                CadastrarNoTudoAzul(),
                ResetarSenhaCliente(),
                ListarProximosVoosDeCliente(),
                ListarDetalhesDeUmVoo(),
                RealizarCheckin(),
                ConsultarAssentosDisponiveisEmUmVoo(),
                ComprarAssentoParaClienteEmUmVoo(),
                ComprarBagagemParaClienteEmUmVoo(),
                ConsultarPontuacaoTudoAzulCliente(),
                ConsultarExtratoPontuacaoTudoAzulCliente(),
                SolicitarPontosRetroclaimTudoAzulCliente(),
                ConsultarPromosDisponiveisCliente(),
                AderirPromo()
            });
        }

        /// <summary>
        /// Método para realizar o cadastro (com o mínimo possível de dados) no programa de pontos tudo azul
        /// TODO: Renato;
        /// </summary>
        static async Task CadastrarNoTudoAzul()
        {
            extWSAddressView customerAdress = new extWSAddressView();
            customerAdress.additionalInfo = null;
            customerAdress.apartmentNumber = null;
            customerAdress.city = "Jaboatao dos Guararapes";
            customerAdress.country = "BR";
            customerAdress.email = "JOHNJOHN@GMAIL.COM";
            customerAdress.fax = null;
            customerAdress.house = "3256";
            customerAdress.mobile = "81998906521";
            customerAdress.name = "H";
            customerAdress.neighbourhood = "Piedade";
            customerAdress.phone = null;
            customerAdress.postalCode = "54410010";
            customerAdress.region = "PE";
            customerAdress.street = "Bernardo Vieira de Melo";
            customerAdress.streetPrefix = null;

            extWSRegistrationFormView customer = new extWSRegistrationFormView();
            customer.accountId = 0;
            customer.accountIdSpecified = false;
            customer.address = customerAdress;
            customer.applicationDateSpecified = false;
            customer.birthDate = DateTime.Parse("01/12/1987 00:00:00");
            customer.birthDateSpecified = true;
            customer.enrollmentCode = "QSAPPADR";
            customer.firstName = "JONH";
            customer.gender = "M";
            customer.identifierIdSpecified = false;
            customer.identifierNo = "59662838260";       //CHANGE IT BY GENERATING A RANDOM CPF
            customer.identifierType = "FFP";
            customer.lastName = "JOHN";
            customer.nationality = "BR";
            customer.omitValidation = true;
            customer.ownCpf = true;
            customer.ownCpfSpecified = true;
            customer.title = "MR";
            customer.travelDocumentID = "59662838260";  //SAME AS identifierNo
            customer.travelDocumentType = "1";

            customer.password = "Azul@2019"; //NOT MANDATORY, CAN BE COMMENTED

            var response = await new ComarchService().EnrollCustomerExtAsync(customer);

            Console.WriteLine("New Customer ID: " + response.@return);

        }

        /// <summary>
        /// Resetar senha do modo mais simples possível
        /// TODO: Renato;
        /// </summary>
        static async Task ResetarSenhaCliente()
        {
            long customerId = 1431756660;

            wsChangePasswordData changePasswordData = new wsChangePasswordData();
            changePasswordData.oldPassword = "Azul@2019";
            changePasswordData.newPassword = "Azul@2021";

            var response = await new ComarchService().ChangePasswordAsync(customerId, changePasswordData);

            Console.WriteLine("", response);
        }

        /// <summary>
        /// Listas os próximos voos de um cliente (CPF), que foram comprados diretamente por eles ou comprados por
        /// terceiros mas registrados para o cliente (CPF)
        /// </summary>
        static async Task ListarProximosVoosDeCliente()
        {
            //Obtendo o token necessário para consumir o serviço da Navitaire.
            string token = await (new LoginBusiness()).LogonAndGetTokenNavitaire();

            ///Função realiza uma consulta com base no número do programa de milhagem da azul, 
            ///que pode ser o CPF, no caso de usuário mais recentes ou no caso de usuários antigos um número com no mínimo 10 dígitos.
            ///Essa função trás reservas canceladas, por esse motivo, estamos realizando um filtro, 
            ///para que o retorno que não possua os dados de origem e destino sejam removidos do retorno.
            await (new BookingBusiness(token)).GetBookingsByCustomerNumber("45234770869");
        }

        /// <summary>
        ///  Listas detalhes de um voo especifico. Será usado em complemento a listagem de voos (ListarProximosVoosDeCliente)
        ///  Para este caso iremos trabalhar apenas com reservas AD ( reservas emitidas pela Azul) , 
        ///  diminuindo a dificuldade no manuseio da reserva caso seja necessário. Na Azul temos varias forma de emitir reserva, 
        ///  porém cada uma delas possui particularidades, dificultando o desenvolvimento de que não está habituado.  
        /// </summary>
        static async Task ListarDetalhesDeUmVoo()
        {
            ///Obtendo o token necessário para consumir o serviço da Navitaire.
            string token = await (new LoginBusiness()).LogonAndGetTokenNavitaire();

            ///Está função é responsavel por incluir na sessão o booking(reserva) que será retornada na consulta caso seja encontrada. 
            BookingResponse booking = await (new BookingBusiness(token)).ReatriveBooking("G7VIVI");
        }


        /// <summary>
        ///  Fluxo feliz de Checkin
        ///  TODO: Renato;
        /// </summary>
        static async Task RealizarCheckin()
        {
        }

        /// <summary>
        ///  Consultar assentos disponíveis. (O objetivo final é permitir que o cliente compre um assento especial)
        ///  Neste caso estamos usando uma reserva nacional, com apenas um passageiro. 
        ///  O motivo disto é facilitar o manuseio da reserva, já que em reservas nacionais eu 
        ///  tenho grupo de assento específicos para determinados tipos de tarifas.
        ///  Exemplo a tarifa Business que tem direito a um assento de luxo.Outro ponto que determinou fazermos desta forma, 
        ///  foi o fato que em voos internacionais temos o skysofa. Assento personalizado da Azul, que possui uma série de regras, 
        ///  que dificulta o desenvolvimento.
        ///  
        /// No novo serviço da navitaire, não está sendo disponibilizado informações referentes ao as características do  assento, 
        /// no caso não são informados as seguintes características do assento:
        /// * O Assento é na janela;
        /// * O Assento é na saida de emergencia;
        /// * O Assento é reclinável;
        /// * O assento é parcialmente reclinável;
        /// </summary>
        static async Task ConsultarAssentosDisponiveisEmUmVoo()
        {
            ///Obtendo o token necessário para consumir o serviço da Navitaire.
            string token = await (new LoginBusiness()).LogonAndGetTokenNavitaire();

            BookingBusiness bookingBusiness = new BookingBusiness(token);
            SeatBusiness seatBusiness = new SeatBusiness(token);

            ///Para que possamos fazer qualquer alteração de uma reserva, se faz necessário estamos com ela em sessão.
            ///por esse motivo realizamos usamos a função ReatriveBooking. Desta forma inserindo em sessão o booking que iremos trabalhar.
            BookingResponse booking = await bookingBusiness.ReatriveBooking("G7VIVI");

            ///Para facilitar o desenvolvimento, estamos sempre usando a chave do primeiro seguinto, da primeira jornada.
            List<SeatMapResponse> seatMapResponseList = await seatBusiness.GetSeatMapAvailabilityBySegmentKey(booking.Journeys[0].Segments[0].SegmentKey);

            ///Função retorna os assentos disponíveis, usando como base os atributos Type e Assignable, do objeto unit. 
            ///O objeto unit representa uma unidade de espaço dentro a aeronave, ou seja posso ter unit, que representam 
            ///espaços em brancos ou por exemplo o banheiro de uma determinada aeronave. 
            ///Para trazermos apenas unidades que representam assento, estamos verificando sei o campo Type, 
            ///está sendo preenchido com o valor “NormalSeat”. Alem de verificar se o valor do objeto Assignable está como true, 
            ///indicando que o assento está disponível para marcação. 
            ///Outro filtro que tive que incluir, pois a Navitaire estava me levantando erro é quando o assento está disponível para marcação, 
            ///porém ele está em espera, por esse motivo, colocamos um filtro no campo Availability, trazendo apenas assentos com o valor 
            ///deste campo igual a open (disponível).
            List<Unit> units = seatBusiness.GetAvailabilitySeat(seatMapResponseList);
        }

        /// <summary>
        ///  Reservar assento para um cliente em um voo e indicar um link do site onde ele possa pagar o assento
        ///  depois de deixar o booking negativo
        ///  Nesta função, irei repetir algumas chamadas do método ConsultarAssentosDisponiveisEmUmVoo, 
        ///  pois a marcação de assento segue o mesmo princípio da exibição do mapa de assento. 
        ///  Outro ponto é que para que eu possa marcar um assento, se faz necessário o unityKey, 
        ///  que é retornado justamente na função que traz o mapa de assento. Com relação a marcação de assentos, 
        ///  estamos usando apenas um fluxo feliz, ou seja o passageiro que iremos utilizar não possui assento, 
        ///  caso contrário teríamos que  remover o assento, para após marcar um novo. 
        ///  Outro ponto é que o usuário não pode realizar mudança de assento, para um assento de valor inferior ao já registrado na reserva. 
        ///  Pois hoje a Azul não trabalha com reembolso do valor do assento. 
        /// </summary>
        static async Task ComprarAssentoParaClienteEmUmVoo()
        {
            ///Obtendo o token necessário para consumir o serviço da Navitaire.
            string token = await (new LoginBusiness()).LogonAndGetTokenNavitaire();

            BookingBusiness bookingBusiness = new BookingBusiness(token);
            SeatBusiness seatBusiness = new SeatBusiness(token);

            ///Para que possamos fazer qualquer alteração de uma reserva, se faz necessário estamos com ela em sessão.
            ///por esse motivo realizamos usamos a função ReatriveBooking. Desta forma inserindo em sessão o booking que iremos trabalhar.
            BookingResponse booking = await bookingBusiness.ReatriveBooking("G7VIVI");

            ///Para facilitar o desenvolvimento, estamos sempre usando a chave do primeiro seguinto, da primeira jornada.
            List<SeatMapResponse> seatMapResponseList = await seatBusiness.GetSeatMapAvailabilityBySegmentKey(booking.Journeys[0].Segments[0].SegmentKey);

            ///Caso o tenhamos assento para o primeiro segmento, realizamos a remoção, assim prosseguindo com o fluxo de marcação.
            if (seatBusiness.ThereIsSeatReservedFirstPassenger(booking))
            {
                Seat seat = booking.Journeys[0]?.Segments[0]?.PassengersSegment[0].Value?.Seats[0];
                await seatBusiness.UnassignPassengerSegmentSeat(seat.PassengerKey, seat.UnitKey);
            }

            ///Função retorna os assentos disponíveis, usando como base os atributos Type e Assignable, do objeto unit. 
            ///O objeto unit representa uma unidade de espaço dentro a aeronave, ou seja posso ter unit, que representam 
            ///espaços em brancos ou por exemplo o banheiro de uma determinada aeronave. 
            ///Para trazermos apenas unidades que representam assento, estamos verificando sei o campo Type, 
            ///está sendo preenchido com o valor “NormalSeat”. Alem de verificar se o valor do objeto Assignable está como true, 
            ///indicando que o assento está disponível para marcação. 
            ///Outro filtro que tive que incluir, pois a Navitaire estava me levantando erro é quando o assento está disponível para marcação, 
            ///porém ele está em espera, por esse motivo, colocamos um filtro no campo Availability, trazendo apenas assentos com o valor 
            ///deste campo igual a open (disponível).
            List<Unit> units = seatBusiness.GetAvailabilitySeat(seatMapResponseList);

            ///Está função realiza a marcação de assento, usando como base o booking em sessão, a key do passageiro informado e a 
            ///key do assento que será atrelado ao usuário.Caso o assento tenha valor a pagar será incluído uma fee(taxa) referente 
            ///ao valor do assento.
            await seatBusiness.AssingnmentSeat(booking.Passengers[0].Key, units[0].UnitKey);

            ///Está função é responsavel por salvar as alterações feitas no booking em sessão. 
            ///Ela tem como o booking, porém estou apenas retornando informações referente ao valor pago, valor a pagar.
            BookingCommitResponse bookingCommitResult = await bookingBusiness.CommitBooking();
        }


        /// <summary>
        ///  Fazer compra de bagagem e link para realizar o pagamento
        /// </summary>
        static async Task ComprarBagagemParaClienteEmUmVoo()
        {
        }


        /// <summary>
        ///  Consultar pontuação no tudo azul para um cliente
        ///  TODO: Renato;
        /// </summary>
        static async Task ConsultarPontuacaoTudoAzulCliente()
        {
            var response = await new ComarchService().GetBalanceAsync(13875); //Customer ID on Comarch.

            Console.WriteLine("Total Points: " + response.@return.totalPointBalance);

        }

        /// <summary>
        ///  Consultar Extrado de pontuação no tudo azul para um cliente
        /// </summary>
        static async Task ConsultarExtratoPontuacaoTudoAzulCliente()
        {
        }

        /// <summary>
        ///  Solicitar pontuação para cliente. Retroclaim
        ///  TODO: Renato;
        /// </summary>
        static async Task SolicitarPontosRetroclaimTudoAzulCliente()
        {
        }

        /// <summary>
        ///  Consultar PROMOS disponíveis para o cliente fazer adesão posteriormente
        /// TODO: Renato;
        /// </summary>
        static async Task ConsultarPromosDisponiveisCliente()
        {
        }

        /// <summary>
        ///  Aderir a PROMO disponível para o cliente
        ///  TODO: Renato;
        /// </summary>
        static async Task AderirPromo()
        {

        }

    }
}
