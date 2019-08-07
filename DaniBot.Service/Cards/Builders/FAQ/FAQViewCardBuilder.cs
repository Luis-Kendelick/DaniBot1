using AdaptiveCards;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.FAQ
{
    public class FAQViewCardBuilder : ICardBuilder
    {
        private readonly FAQViewModel _FAQViewModel;

        public FAQViewCardBuilder(FAQViewModel fAQViewModel)
        {
            _FAQViewModel = fAQViewModel;
        }

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
                                Text = _FAQViewModel.Title,
                                Size = AdaptiveTextSize.Large,
                                Wrap = true
                            },
                            new AdaptiveImage
                            {
                                Url = new Uri(_FAQViewModel.Image),
                                Size = AdaptiveImageSize.Stretch
                            },
                            new AdaptiveTextBlock()
                            {
                                Text = _FAQViewModel.Content,
                                Size = AdaptiveTextSize.Medium,
                                Weight = AdaptiveTextWeight.Lighter,
                                Wrap = true
                            }
                        }
                    }
                }
            };
        }
    }
}