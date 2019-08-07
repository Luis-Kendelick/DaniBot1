using AdaptiveCards;
using Microsoft.Bot.Schema;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.Login
{
	public class AuthenticateByTextCardBuilder : ICardBuilder
	{
		public List<Attachment> Build()
		{
			return new List<Attachment>
			{
				new Attachment
				{
					ContentType = AdaptiveCard.ContentType,
					Content = new AdaptiveCard("1.0")
					{
						Body = new List<AdaptiveElement>
						{
							new AdaptiveTextBlock()
							{
								Text = "Digite as suas credencias",
								Size = AdaptiveTextSize.Large,
								Wrap = true
							},
							new AdaptiveTextBlock()
							{
								Text = "Usuário:",
								Size = AdaptiveTextSize.Default,
								Wrap = true
							},
							new AdaptiveTextInput()
							{
								Id = "User",
								Placeholder = "Por favor, insira seu usuário",
								Style = AdaptiveTextInputStyle.Text
							},
							new AdaptiveTextBlock()
							{
								Text = "Senha:",
								Size = AdaptiveTextSize.Default,
								Wrap = true
							},
							new AdaptiveTextInput()
							{
								Id = "Password",
								Placeholder = "Por favor, insira sua senha",
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
