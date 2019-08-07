// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avanade.HackathonAzul.DaniBot.Cards.Builders.AuthenticatedMenu;
using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.Azul.DaniBot.Dialogs
{
	public class AuthenticatedMenuDialog : ComponentDialog
	{
		public AuthenticatedMenuDialog()
			: base(nameof(FAQDialog))
		{
			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
			{
				IntroStep
			}));

			InitialDialogId = nameof(WaterfallDialog);
		}

		private async Task<DialogTurnResult> IntroStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
            var authenticatedMenuAttachmentBuilders = new List<IAuthenticatedMenuAttachmentBuilder>();

            authenticatedMenuAttachmentBuilders.Add(new FlightStatusAttachmentBuilder(null));

            authenticatedMenuAttachmentBuilders.Add(new PromoCardAttachmentBuilder(null));

            authenticatedMenuAttachmentBuilders.Add(new TudoAzulAttachmentBuilder(null));

            await stepContext.Context.SendActivityAsyncFromAdaptiveCard(CardFactory.CreateAuthenticatedMenuCardBuilder(authenticatedMenuAttachmentBuilders), cancellationToken);
			return new DialogTurnResult(DialogTurnStatus.Waiting);
		}
	}
}