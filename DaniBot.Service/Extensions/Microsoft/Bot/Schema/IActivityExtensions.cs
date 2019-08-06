using AdaptiveCards;
using Avanade.HackathonAzul.DaniBot.Cards;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;

namespace Microsoft.Bot.Schema
{
	public static class IActivityExtensions
	{
		public static Activity CreateFrom(this IActivity activity, ICardBuilder cardBuilder)
		{
			Activity response = ((Activity)activity).CreateReply();

			response.Attachments = cardBuilder.Build();

			return response;
		}

		public static Activity CreateFAQAdaptiveCardActitvity(this WaterfallStepContext stepContext, string titleFAQ, string FAQText, string urlImage)
		{
			var adaptiveCardAttachment = new Attachment()
			{
				ContentType = AdaptiveCard.ContentType,
				Content = new AdaptiveCard("1.1")
				{
					Body = new List<AdaptiveElement>
					{
						new AdaptiveTextBlock()
						{
							Text = titleFAQ,
							Size = AdaptiveTextSize.Large,
							Wrap = true
						},
						new AdaptiveImage
						{
							Url = new Uri(urlImage),
							Size = AdaptiveImageSize.Stretch
						},
						new AdaptiveTextBlock()
						{
							Text = FAQText,
							Size = AdaptiveTextSize.Medium,
							Weight = AdaptiveTextWeight.Lighter,
							Wrap = true
						}
					}
				}
			};

			var response = stepContext.Context.Activity.CreateReply();
			response.Attachments = new List<Attachment>() { adaptiveCardAttachment };

			return response;
		}


	}
}