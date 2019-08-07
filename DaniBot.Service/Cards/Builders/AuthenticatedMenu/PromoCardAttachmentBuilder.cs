using AdaptiveCards;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.AuthenticatedMenu
{
    public class PromoCardAttachmentBuilder : IAuthenticatedMenuAttachmentBuilder
    {
        private IList<PromoInformationModel> _PromoInformationModels;

        public PromoCardAttachmentBuilder(IList<PromoInformationModel> promoInformationModels)
        {
            _PromoInformationModels = promoInformationModels;
        }

        public Attachment Build()
        {
            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = new AdaptiveCard("1.0")
                {
                    Type = AdaptiveCard.TypeName,
                    Body = _PromoInformationModels
                        .Select(info => new AdaptiveContainer
                        {

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