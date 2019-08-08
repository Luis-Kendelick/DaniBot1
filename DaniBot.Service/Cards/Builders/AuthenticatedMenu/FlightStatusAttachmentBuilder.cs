using AdaptiveCards;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.AuthenticatedMenu
{
    public class FlightStatusAttachmentBuilder : IAuthenticatedMenuAttachmentBuilder
    {
        private IList<FlightInformationModel> _FlightInformationModels;

        public FlightStatusAttachmentBuilder(IList<FlightInformationModel> flightInformationModels)
        {
            _FlightInformationModels = flightInformationModels;
        }

        public Attachment Build()
        {
            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = new AdaptiveCard("1.0")
                {
                    Type = AdaptiveCard.TypeName,
                    Body = _FlightInformationModels
                        .Select(info => new AdaptiveContainer
                        {
                            Items = new List<AdaptiveElement>
                            {
                                new AdaptiveColumnSet
                                {
                                    Columns = new List<AdaptiveColumn>
                                    {
                                        new AdaptiveColumn
                                        {
                                            Items = new List<AdaptiveElement>
                                            {
                                                new AdaptiveTextBlock
                                                {
                                                    Text = info.DepartureDate.ToShortDateString(),
                                                    Color = AdaptiveTextColor.Attention,
                                                    Weight = AdaptiveTextWeight.Bolder,
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Left
                                                },
                                                new AdaptiveTextBlock
                                                {
                                                    Text = info.DepartureDate.ToShortTimeString(),
                                                    Color = AdaptiveTextColor.Attention,
                                                    Weight = AdaptiveTextWeight.Bolder,
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Left
                                                },
                                                new AdaptiveTextBlock
                                                {
                                                    Text = info.DepartureAirport,
                                                    Size = AdaptiveTextSize.Small,
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Left
                                                },
                                                new AdaptiveTextBlock
                                                {
                                                    Text = info.DepartureAirport,
                                                    Color = AdaptiveTextColor.Accent,
                                                    Size = AdaptiveTextSize.Large,
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Left
                                                }
                                            }
                                        },
                                        new AdaptiveColumn
                                        {
                                            Items = new List<AdaptiveElement>
                                            {
                                                new AdaptiveTextBlock
                                                {
                                                    Text = "Localizador",
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Center
                                                },
                                                new AdaptiveTextBlock
                                                {
                                                    Text = info.Number,
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Center
                                                },
                                                new AdaptiveImage
                                                {
                                                    Url = new Uri("http://adaptivecards.io/content/airplane.png"),
                                                    Size = AdaptiveImageSize.Small,
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Center,
                                                    Spacing = AdaptiveSpacing.Medium
                                                }
                                            }
                                        },
                                        new AdaptiveColumn
                                        {
                                            Items = new List<AdaptiveElement>
                                            {
                                                new AdaptiveTextBlock
                                                {
                                                    Text = info.ArrivalDate.ToShortDateString(),
                                                    Color = AdaptiveTextColor.Attention,
                                                    Weight = AdaptiveTextWeight.Bolder,
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Right
                                                },
                                                new AdaptiveTextBlock
                                                {
                                                    Text = info.ArrivalDate.ToShortTimeString(),
                                                    Color = AdaptiveTextColor.Attention,
                                                    Weight = AdaptiveTextWeight.Bolder,
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Right
                                                },
                                                new AdaptiveTextBlock
                                                {
                                                    Text = info.ArrivalAirport,
                                                    Size = AdaptiveTextSize.Small,
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Right
                                                },
                                                new AdaptiveTextBlock
                                                {
                                                    Text = info.ArrivalAirport,
                                                    Color = AdaptiveTextColor.Accent,
                                                    Size = AdaptiveTextSize.Large,
                                                    HorizontalAlignment = AdaptiveHorizontalAlignment.Right
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            SelectAction = new AdaptiveSubmitAction
                            {
                                Id = info.Number
                            }
                        })
                        .Cast<AdaptiveElement>()
                        .ToList()
                    ,
                    Actions = new List<AdaptiveAction>
                    {

                    }
                }
            };
        }
    }
}