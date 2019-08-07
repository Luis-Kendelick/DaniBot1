using AdaptiveCards;
using Avanade.HackathonAzul.DaniBot.Constants;
using Avanade.HackathonAzul.DaniBot.Models.Enums;
using Microsoft.Bot.Schema;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.TudoAzul
{
	public class RetroClaimBuilder : ICardBuilder
	{
		public List<Attachment> Build()
		{
			return new List<Attachment>()
			{
				new Attachment()
				{
					ContentType = AdaptiveCard.ContentType,
					Content = new AdaptiveCard(GlobalConstants.ADAPTIVE_CARD_VERSION)
					{
						Body = new List<AdaptiveElement>
						{
							new AdaptiveTextBlock()
							{
								Text = Resources.Messages.RetroClaim.Title,
								Size = AdaptiveTextSize.Large,
								Wrap = true
							},
							new AdaptiveTextBlock()
							{
								Text = Resources.Messages.RetroClaim.Company,
							},
							new AdaptiveChoiceSetInput()
							{
								Style = AdaptiveChoiceInputStyle.Compact,
								Value = "4",
								Choices = new List<AdaptiveChoice>(){
									new AdaptiveChoice()
									{
										Title = Resources.Messages.RetroClaimComapnys.Azul,
										Value = ERetroClaim.Azul.ToString()
									},
									new AdaptiveChoice()
									{
										Title = Resources.Messages.RetroClaimComapnys.Tap,
										Value = ERetroClaim.TAP.ToString()
									},
									new AdaptiveChoice()
									{
										Title = Resources.Messages.RetroClaimComapnys.United,
										Value = ERetroClaim.United.ToString()
									},
									new AdaptiveChoice()
									{
										Title = Resources.Messages.RetroClaimComapnys.CopaAirlines,
										Value = ERetroClaim.CopaAirlines.ToString()
									}
								}
								
							},
							new AdaptiveTextBlock()
							{
								Text = Resources.Messages.RetroClaimReservation.ReservationCode,
								Wrap = true
							},
							new AdaptiveTextInput()
							{
								Id =  Resources.Messages.RetroClaimReservation.ReservationCodeId,
								Placeholder = Resources.Messages.RetroClaimReservation.ReservationCodePlaceHold,
								Style = AdaptiveTextInputStyle.Text
							},
							new AdaptiveTextBlock()
							{
								Text = Resources.Messages.RetroClaim.DepartureDate,
								Wrap = true
							},
							new AdaptiveDateInput()
							{
								Id = Resources.Messages.RetroClaim.DepartureDateId
							},
							new AdaptiveTextBlock()
							{
								Text = Resources.Messages.RetroClaimFlight.FlightNumber,
								Wrap = true
							},
							new AdaptiveTextInput()
							{
								Id = Resources.Messages.RetroClaimFlight.FlightNumberId,
								Placeholder = Resources.Messages.RetroClaimFlight.FlightNumberPlaceHold,
								Style = AdaptiveTextInputStyle.Text
							},
							new AdaptiveTextBlock()
							{
								Text = Resources.Messages.RetroClaimCity.OriginCity,
								Wrap = true
							},
							new AdaptiveTextInput()
							{
								Id = Resources.Messages.RetroClaimCity.OriginCityId,
								Placeholder = Resources.Messages.RetroClaimCity.OriginCityPlaceHold,
								Style = AdaptiveTextInputStyle.Text
							}
						},
						Actions = new List<AdaptiveAction>
						{
							new AdaptiveSubmitAction
							{
								Title = "Enviar"
							}
						}
					}
				}
			};
		}
	}
}
