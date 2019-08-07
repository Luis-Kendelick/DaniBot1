// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.HackathonAzul.DaniBot.Dialogs.LoginDialogs
{
	public class AuthenticateDialog : ComponentDialog
	{
		private readonly string AuthenticateViaTextId;

		public AuthenticateDialog()
			: base(nameof(AuthenticateDialog))
		{
			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new AuthenticateViaTextDialog());
			AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
			{
				IntroStep,
				ActionSteps
			}));

			AuthenticateViaTextId = nameof(AuthenticateViaTextDialog);
			InitialDialogId = nameof(WaterfallDialog);
		}

		private async Task<DialogTurnResult> IntroStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			await stepContext.Context.SendActivityAsyncFromAdaptiveCard(CardFactory.CreateLoginCardBuilder(), cancellationToken);
			return new DialogTurnResult(DialogTurnStatus.Waiting);
		}

		private async Task<DialogTurnResult> ActionSteps(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			switch (stepContext.Result.ToString())
			{
				case "UserPassword":
					return await stepContext.BeginDialogAsync(AuthenticateViaTextId, cancellationToken);
				case "Voice":
					return await stepContext.EndDialogAsync(cancellationToken);
				case "Face":
					return await stepContext.EndDialogAsync(cancellationToken);
				case "Fingprint":
					return await stepContext.EndDialogAsync(cancellationToken);
				default:
					var didntUnderstandMessageText = "Desculpe, não entendi!";
					var didntUnderstandMessage = MessageFactory.Text(didntUnderstandMessageText, didntUnderstandMessageText, InputHints.IgnoringInput);
					await stepContext.Context.SendActivityAsync(didntUnderstandMessage, cancellationToken);
					return await stepContext.EndDialogAsync(cancellationToken);
			}
			
		}
	}
}