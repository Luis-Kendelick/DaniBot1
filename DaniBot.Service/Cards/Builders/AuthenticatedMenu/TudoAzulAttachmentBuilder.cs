using AdaptiveCards;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Schema;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.AuthenticatedMenu
{
    public class TudoAzulAttachmentBuilder : IAuthenticatedMenuAttachmentBuilder
    {
        private TodoAzulSummaryModel _TodoAzulSummaryModel;

        public TudoAzulAttachmentBuilder(TodoAzulSummaryModel todoAzulSummaryModel)
        {
            _TodoAzulSummaryModel = todoAzulSummaryModel;
        }

        public Attachment Build()
        {
            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = new AdaptiveCard("1.0")
                {
                    Type = AdaptiveCard.TypeName,
                    Body = new List<AdaptiveElement>
                    {
                        new AdaptiveTextBlock()
                        {
                            Text = _TodoAzulSummaryModel.CardNumber,
                            Size = AdaptiveTextSize.Default,
                            Wrap = true
                        },
                        new AdaptiveTextBlock()
                        {
                            Text = string.Format(Resources.Messages.AuthenticatedMenuDialog.TudoAzulCardMessages.YourBalanceIs, _TodoAzulSummaryModel.Balance),
                            Size = AdaptiveTextSize.Default,
                            Wrap = true
                        }
                    },
                    Actions = new List<AdaptiveAction>
                    {
                        new AdaptiveSubmitAction
                        {
                            Title = Resources.Messages.AuthenticatedMenuDialog.TudoAzulCardMessages.Statements,
                            Data = "Extrato"
                        },
                        new AdaptiveSubmitAction
                        {
                            Title = Resources.Messages.AuthenticatedMenuDialog.TudoAzulCardMessages.RedeemPoints,
                            Data = "Resgatar"
                        }
                    }
                }
            };
        }
    }
}