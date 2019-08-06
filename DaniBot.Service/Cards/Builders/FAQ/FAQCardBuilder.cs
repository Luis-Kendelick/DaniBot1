using AdaptiveCards;
using Avanade.Azul.DaniBot.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders
{
	public class FAQCardBuilder : ICardBuilder
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
								Url = new Uri("http://www.equinautic.com.br/media/catalog/product/cache/1/image/400x400/9df78eab33525d08d6e5fb8d27136e95/i/m/image_1336.jpg"),
								Size = AdaptiveImageSize.Stretch
							}
						},
						Actions = new List<AdaptiveAction>
						{
							new AdaptiveSubmitAction
							{
								Title = "Quais as vantagens de fazer o check-in online?",
								Data = "checkin"
							},
							new AdaptiveSubmitAction
							{
								Title = "Qual a diferença entre marcar assentos e fazer check-in?",
								Data = "diferencaassentoscheckin"
							},
							new AdaptiveSubmitAction
							{
								Title = "Como funciona o Tudo Azul?",
								Data = "tudoazulfaq"
							},
							new AdaptiveSubmitAction
							{
								Title = "Quais a vantagens de utilizar Dani?",
								Data = "vantagensDani"
							}
						}
					}
				}
			};
		}
	}
}
