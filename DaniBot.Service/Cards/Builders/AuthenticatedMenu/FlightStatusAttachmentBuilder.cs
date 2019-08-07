using AdaptiveCards;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Schema;
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