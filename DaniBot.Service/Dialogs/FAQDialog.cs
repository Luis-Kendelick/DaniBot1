// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;

namespace Avanade.Azul.DaniBot.Dialogs
{
	public class FAQDialog : ComponentDialog
	{
		public FAQDialog()
			: base(nameof(FAQDialog))
		{
			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
			{
				IntroStep,
				ActionSteps
			}));

			InitialDialogId = nameof(WaterfallDialog);
		}

		private async Task<DialogTurnResult> IntroStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			await stepContext.Context.SendAdaptiveCardsActivityAsyncFrom(CardFactory.CreateFAQCardBuilder(), cancellationToken);
			return new DialogTurnResult(DialogTurnStatus.Waiting);
		}

		private Task<DialogTurnResult> ActionSteps(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
