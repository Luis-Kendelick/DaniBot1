﻿using AdaptiveCards;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders
{
    public class WelcomeMenuCardBuilder : ICardBuilder
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
                                Text = Resources.Messages.MainDialog.Welcome,
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
                                Title = Resources.Messages.MainDialog.LocalizarVoo,
                                Data = "LocalizarVoo"
                            },
                            new AdaptiveSubmitAction
                            {
                                Title = Resources.Messages.MainDialog.RealizarCadastro,
                                Data = "RealizarCadastro"
                            },
                            new AdaptiveSubmitAction
                            {
                                Title = Resources.Messages.MainDialog.FAQ,
                                Data = "ConsultarFAQ"
                            },
                            new AdaptiveSubmitAction
                            {
                                Title = Resources.Messages.MainDialog.ResetSenha,
                                Data = "ResetSenha"
                            },
                            new AdaptiveSubmitAction
                            {
                                Title = Resources.Messages.MainDialog.Login,
                                Data = "Login"
                            }
                        }
                    }
                }
            };
        }
    }
}