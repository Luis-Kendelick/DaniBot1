using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.HackathonAzul.DaniBot.Cards
{
    public interface ICardFactory
    {
        List<Attachment> BuildAttachments();
    }
}
