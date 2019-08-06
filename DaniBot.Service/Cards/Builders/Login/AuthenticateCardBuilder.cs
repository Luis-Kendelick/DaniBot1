using AdaptiveCards;
using Microsoft.Bot.Schema;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.Login
{
	public class AuthenticateCardBuilder : ICardBuilder
	{
		public List<Attachment> Build()
		{
			return new List<Attachment>
			{
				new Attachment
				{
					ContentType = AdaptiveCard.ContentType,
					Content = new AdaptiveCard("1.1")
					{
						Body = new List<AdaptiveElement>
						{
							new AdaptiveTextBlock()
							{
								Text = "Você tem as seguintes opções de autenticação, escolha apenas uma:",
								Size = AdaptiveTextSize.Default,
								Wrap = true
							}
						},
						Actions = new List<AdaptiveAction>
						{
							new AdaptiveSubmitAction
							{
								Title = "Digitar usuário e senha",
								Data = "UserPassword"
							},
							new AdaptiveSubmitAction
							{
								Title = "Voz",
								Data = "Voice"
							},
							new AdaptiveSubmitAction
							{
								Title = "Reconhecimento facial",
								Data = "Face"
							},
							new AdaptiveSubmitAction
							{
								Title = "Digital",
								Data = "Fingprint"
							}
						}
					}
				}
			};
		}
	}
}
