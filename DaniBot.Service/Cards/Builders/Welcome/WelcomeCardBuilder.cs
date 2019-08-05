using AdaptiveCards;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards
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
                                Url = new Uri("http://adaptivecards.io/content/cats/1.png"),
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