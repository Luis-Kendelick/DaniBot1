using Avanade.HackathonAzul.DaniBot.Cards.Builders.AuthenticatedMenu;
using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.Azul.DaniBot.Dialogs
{
    public class AuthenticatedMenuDialog : ComponentDialog
	{
		#region MOQ
		private FlightStatusAttachmentBuilder _FlightStatusMoq = new FlightStatusAttachmentBuilder(
				new List<FlightInformationModel>
				{
					new FlightInformationModel
					{
						DepartureAirport = "SAO",
						ArrivalAirport = "REC",
						DepartureCity = "Sao Paulo",
						ArrivalCity = "Recife",
						DepartureDate = new DateTime(2019, 8, 7, 22, 30, 0),
						ArrivalDate = new DateTime(2019, 8, 8, 3, 45, 0),
						Number = "FH4JJ1",
						Status = FlightStatus.OnTime
	},
					new FlightInformationModel
					{
						DepartureAirport = "REC",
						ArrivalAirport = "SAO",
						DepartureCity = "Recife",
						ArrivalCity = "Sao Paulo",
						DepartureDate = new DateTime(2019, 9, 7, 21, 30, 0),
						ArrivalDate = new DateTime(2019, 9, 8, 2, 30, 0),
						Number = "FH4JJ2",
						Status = FlightStatus.OnTime
},
					new FlightInformationModel
					{
						DepartureAirport = "SAO",
						ArrivalAirport = "REC",
						DepartureCity = "Sao Paulo",
						ArrivalCity = "Recife",
						DepartureDate = new DateTime(2019, 10, 7, 20, 30, 0),
						ArrivalDate = new DateTime(2019, 10, 8, 1, 15, 0),
						Number = "FH4JJ3",
						Status = FlightStatus.OnTime
					}
				});

		private TudoAzulAttachmentBuilder _TudoAzulMoq = new TudoAzulAttachmentBuilder(
				new TodoAzulSummaryModel
				{
					CardNumber = "1234 5678 9012 3456",
					Balance = 4500
				});

		private PromoCardAttachmentBuilder _Promos = new PromoCardAttachmentBuilder(
				new List<PromoInformationModel>
				{
					new PromoInformationModel
					{
						Title = "PROMO 1",
						Content = "VEJA BEM COMO ESSA PROMOÇÃO É INTERESSANTE",
						HyperLinkUrl = "https://www.google.com/search?q=promo%C3%A7%C3%B5es%20azul",
						ImageUrl = "https://cdnv2.moovin.com.br/lojasplasutil/imagens/produtos/original/produto-teste-d6363200ff6d085db9adf4f244a841d3.png"
					},
					new PromoInformationModel
					{
						Title = "PROMO 2",
						Content = "VEJA BEM COMO ESSA PROMOÇÃO É MUITO MAIS INTERESSANTE",
						HyperLinkUrl = "https://www.google.com/search?q=promo%C3%A7%C3%B5es%20azul",
						ImageUrl = "https://cdnv2.moovin.com.br/lojasplasutil/imagens/produtos/original/produto-teste-d6363200ff6d085db9adf4f244a841d3.png"
					},
					new PromoInformationModel
					{
						Title = "PROMO 3",
						Content = "VEJA BEM COMO ESSA PROMOÇÃO É AINDA MAIS INTERESSANTE",
						HyperLinkUrl = "https://www.google.com/search?q=promo%C3%A7%C3%B5es%20azul",
						ImageUrl = "https://cdnv2.moovin.com.br/lojasplasutil/imagens/produtos/original/produto-teste-d6363200ff6d085db9adf4f244a841d3.png"
					}
				});
		#endregion

		public AuthenticatedMenuDialog()
			: base(nameof(AuthenticatedMenuDialog))
		{
			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
			{
				IntroStep,
				ActionStep
			}));

			InitialDialogId = nameof(WaterfallDialog);
		}

		private async Task<DialogTurnResult> IntroStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
            var authenticatedMenuAttachmentBuilders = new List<IAuthenticatedMenuAttachmentBuilder>();

            authenticatedMenuAttachmentBuilders.Add(_FlightStatusMoq);

            authenticatedMenuAttachmentBuilders.Add(_Promos);

            authenticatedMenuAttachmentBuilders.Add(_TudoAzulMoq);

            await stepContext.Context.SendActivityAsyncFromAdaptiveCard(CardFactory.CreateAuthenticatedMenuCardBuilder(authenticatedMenuAttachmentBuilders), cancellationToken, isCarousel: true);
			return new DialogTurnResult(DialogTurnStatus.Waiting);
		}

		private async Task<DialogTurnResult> ActionStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			return await stepContext.EndDialogAsync(cancellationToken);
		}
	}
}