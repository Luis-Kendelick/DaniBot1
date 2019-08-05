using Avanade.HackathonAzul.DaniBot.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Bot.Schema
{
    public static class IActivityExtensions
    {
        public static Activity CreateFrom(this IActivity activity, ICardFactory cardFactory)
        {
            Activity response = ((Activity)activity).CreateReply();
            response.Attachments = cardFactory.BuildAttachments();
            return response;
        }
    }
}
