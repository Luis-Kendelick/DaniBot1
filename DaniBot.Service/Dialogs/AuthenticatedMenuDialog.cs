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
		public AuthenticatedMenuDialog()
			: base(nameof(AuthenticatedMenuDialog))
		{
			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
			{
				IntroStep
			}));

			InitialDialogId = nameof(WaterfallDialog);
		}

		private async Task<DialogTurnResult> IntroStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
            var authenticatedMenuAttachmentBuilders = new List<IAuthenticatedMenuAttachmentBuilder>();

            authenticatedMenuAttachmentBuilders.Add(new FlightStatusAttachmentBuilder(
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
                        DepartureAirport = "SAO",
                        ArrivalAirport = "REC",
                        DepartureCity = "Sao Paulo",
                        ArrivalCity = "Recife",
                        DepartureDate = new DateTime(2019, 9, 7, 21, 30, 0),
                        ArrivalDate = new DateTime(2019, 9, 8, 2, 30, 0),
                        Number = "FH4JJ1",
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
                        Number = "FH4JJ1",
                        Status = FlightStatus.OnTime
                    }
                }));

            authenticatedMenuAttachmentBuilders.Add(new PromoCardAttachmentBuilder(
                new List<PromoInformationModel>
                {
                    new PromoInformationModel
                    {
                        
                    },
                    new PromoInformationModel
                    {

                    },
                    new PromoInformationModel
                    {

                    }
                }));

            authenticatedMenuAttachmentBuilders.Add(new TudoAzulAttachmentBuilder(
                new TodoAzulSummaryModel
                {
                    CardNumber = "1234 5678 9012 3456",
                    Balance = 4500
                }));

            await stepContext.Context.SendActivityAsyncFromAdaptiveCard(CardFactory.CreateAuthenticatedMenuCardBuilder(authenticatedMenuAttachmentBuilders), cancellationToken, isCarousel: true);
			return new DialogTurnResult(DialogTurnStatus.Waiting);
		}
	}
}