using AdaptiveCards;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders
{
    public class WelcomeCardBuilder : ICardBuilder
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
                                Text = "Olá, eu sou Dani e irei te auxiliar nesse atendimento. Por favor, selecione uma das opções abaixo ou digite o que você gostaria de consultar:",
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
                                Title = "Localizar vôo",
                                Data = "LocalizarVoo"
                            },
                            new AdaptiveSubmitAction
                            {
                                Title = "Realizar cadastro",
                                Data = "RealizarCadastro"
                            },
                            new AdaptiveSubmitAction
                            {
                                Title = "FAQ",
                                Data = "ConsultarFAQ"
                            },
                            new AdaptiveSubmitAction
                            {
                                Title = "Reset de senha",
                                Data = "ResetSenha"
                            },
                            new AdaptiveSubmitAction
                            {
                                Title = "Login",
                                Data = "Login"
                            }
                        }
                    }
                }
            };
        }
    }
}