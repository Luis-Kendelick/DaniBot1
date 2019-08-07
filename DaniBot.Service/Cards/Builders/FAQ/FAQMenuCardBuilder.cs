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
					Content = new AdaptiveCard(Resources.Messages.Global.AdaptiveCardVersion)
					{
						Body = new List<AdaptiveElement>
						{
							new AdaptiveTextBlock()
							{
								Text = Resources.Messages.FAQDialog.Title,
								Size = AdaptiveTextSize.Default,
								Wrap = true
							},
							new AdaptiveImage
							{
								Url = new Uri(Resources.Messages.FAQDialog.URL),
								Size = AdaptiveImageSize.Stretch
							}
						},
						Actions = new List<AdaptiveAction>
						{
							new AdaptiveSubmitAction
							{
								Title = Resources.Messages.FAQDialog.CheckInTitle,
								Data = Resources.Messages.FAQDialog.CheckIn
							},
							new AdaptiveSubmitAction
							{
								Title = Resources.Messages.FAQDialog.TudoAzulTitle,
								Data = Resources.Messages.FAQDialog.TudoAzul
							},
							new AdaptiveSubmitAction
							{
								Title = Resources.Messages.FAQDialog.DaniTitle,
								Data = Resources.Messages.FAQDialog.Dani
							}
						}
					}
				}
			};
		}
	}
}
