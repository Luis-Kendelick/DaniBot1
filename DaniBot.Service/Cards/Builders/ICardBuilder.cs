using Microsoft.Bot.Schema;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards
{
    public interface ICardBuilder
    {
        List<Attachment> Build();
    }
}