using AdaptiveCards;
using Avanade.Azul.DaniBot.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.FAQ
{
	public class FAQMenuCardBuilder : ICardBuilder
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
								Text = "Aqui estão algumas perguntas frequentes que podem te ajudar:",
								Size = AdaptiveTextSize.Default,
								Wrap = true
							},
							new AdaptiveImage
							{
								Url = new Uri("https://static.wixstatic.com/media/ece054_afb801e3e96c425783b598f49a2a41d8~mv2.png/v1/fill/w_600,h_288,al_c,q_80,usm_0.66_1.00_0.01/best-magento-2_3-FAQ.webp"),
								Size = AdaptiveImageSize.Stretch
							}
						},
						Actions = new List<AdaptiveAction>
						{
							new AdaptiveSubmitAction
							{
								Title = "Quais as vantagens de fazer o check-in online?",
								Data = "CheckIn"
							},
							new AdaptiveSubmitAction
							{
								Title = "Como funciona o Tudo Azul?",
								Data = "TudoAzulFaq"
							},
							new AdaptiveSubmitAction
							{
								Title = "Quais a vantagens de utilizar Dani?",
								Data = "VantagensDani"
							}
						}
					}
				}
			};
		}
	}
}
