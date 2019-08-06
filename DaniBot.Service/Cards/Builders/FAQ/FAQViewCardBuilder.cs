using AdaptiveCards;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.FAQ
{
    public class FAQViewCardBuilder : ICardBuilder
    {
        private readonly FAQModel _fAQModel;

        public FAQViewCardBuilder(FAQModel fAQModel)
        {
            _fAQModel = fAQModel;
        }

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
                                Text = _fAQModel.Title,
                                Size = AdaptiveTextSize.Large,
                                Wrap = true
                            },
                            new AdaptiveImage
                            {
                                Url = new Uri(_fAQModel.Image),
                                Size = AdaptiveImageSize.Stretch
                            },
                            new AdaptiveTextBlock()
                            {
                                Text = _fAQModel.Content,
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