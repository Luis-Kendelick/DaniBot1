using Microsoft.Bot.Schema;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders
{
    public interface ICardBuilder
    {
        List<Attachment> Build();
    }
}