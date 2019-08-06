// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System.Threading;
using System.Threading.Tasks;

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

		private async Task<DialogTurnResult> ActionSteps(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			switch (stepContext.Result.ToString())
			{
				case "CheckIn":
				case "DiferencaAssentosCheckin":
				case "TudoAzulFaq":
				case "VantagensDani":
				default:
					var didntUnderstandMessageText = "Desculpe, não entendi!";
					var didntUnderstandMessage = MessageFactory.Text(didntUnderstandMessageText, didntUnderstandMessageText, InputHints.IgnoringInput);
					await stepContext.Context.SendActivityAsync(didntUnderstandMessage, cancellationToken);
					break;
			}

			return await stepContext.NextAsync(null, cancellationToken);
		}
	}
}