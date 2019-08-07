using Microsoft.Bot.Schema;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.AuthenticatedMenu
{
    public class AuthenticatedMenuCardBuilder : ICardBuilder
    {
        private IList<IAuthenticatedMenuAttachmentBuilder> _AuthenticatedMenuAttachmentBuilders;

        public AuthenticatedMenuCardBuilder(IList<IAuthenticatedMenuAttachmentBuilder> authenticatedMenuAttachmentBuilders)
        {
            _AuthenticatedMenuAttachmentBuilders = authenticatedMenuAttachmentBuilders;
        }


        public List<Attachment> Build()
        {
            var attachments = new List<Attachment>();

            foreach (var authenticatedMenuAttachmentBuilder in _AuthenticatedMenuAttachmentBuilders)
            {
                attachments.Add(authenticatedMenuAttachmentBuilder.Build());
            }

            return attachments;
        }
    }
}