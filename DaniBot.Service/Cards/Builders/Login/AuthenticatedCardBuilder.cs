using AdaptiveCards;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;

namespace Avanade.HackathonAzul.DaniBot.Cards.Builders.Login
{
	public class AuthenticatedCardBuilder : ICardBuilder
	{
		public List<Attachment> Build()
		{
			return new List<Attachment>
			{
				GetPromoCard(),
				GetTudoAzulCard(),
				GetFlightStatus()
			};
		}

		private Attachment GetFlightStatus()
		{
			throw new NotImplementedException();
		}

		private Attachment GetTudoAzulCard()
		{
			throw new NotImplementedException();
		}

		private Attachment GetPromoCard()
		{
			throw new NotImplementedException();
		}
	}
}
