// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Avanade.HackathonAzul.DaniBot.Constants;
using Avanade.HackathonAzul.DaniBot.Dialogs.LoginDialogs;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.Azul.DaniBot.Dialogs
{
    public class MainDialog : ComponentDialog
	{
		private readonly FlightBookingRecognizer _luisRecognizer;
		protected readonly ILogger Logger;

		private readonly string LocateFlightDialogId;
		private readonly string RegisterDialogId;
		private readonly string FAQDialogId;
		private readonly string AuthenticateDialogId;
		private readonly string ResetPasswordDialogId;

		public MainDialog(FlightBookingRecognizer luisRecognizer, ILogger<MainDialog> logger)
			: base(nameof(MainDialog))
		{
			_luisRecognizer = luisRecognizer;
			Logger = logger;

			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new RegisterDialog());
			AddDialog(new FAQDialog());
			AddDialog(new ResetPasswordDialog());
			AddDialog(new AuthenticateDialog());
			AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
			{
                IntroStepAsync,
                ActStepAsync,
				FinalStepAsync,
			}));

			RegisterDialogId = nameof(RegisterDialog);
			FAQDialogId = nameof(FAQDialog);
			ResetPasswordDialogId = nameof(ResetPasswordDialog);
			AuthenticateDialogId = nameof(AuthenticateDialog);
			InitialDialogId = nameof(WaterfallDialog);
		}

		private async Task<DialogTurnResult> IntroStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			await stepContext.Context.SendActivityAsyncFromAdaptiveCard(CardFactory.CreateWelcomeMenuCardBuilder(), cancellationToken);
			return new DialogTurnResult(DialogTurnStatus.Waiting);
		}

		private async Task<DialogTurnResult> ActStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
            switch (stepContext.Result.ToString())
			{
				case MainDialogConstants.LocalizaVoo:
					return await stepContext.BeginDialogAsync(LocateFlightDialogId, cancellationToken);
				case MainDialogConstants.RealizarCadastro:
					return await stepContext.BeginDialogAsync(RegisterDialogId, cancellationToken);
				case MainDialogConstants.FAQ:
					return await stepContext.BeginDialogAsync(FAQDialogId, cancellationToken);
				case MainDialogConstants.ResetSenha:
					return await stepContext.BeginDialogAsync(ResetPasswordDialogId, cancellationToken);
				case MainDialogConstants.Login:
					return await stepContext.BeginDialogAsync(AuthenticateDialogId, cancellationToken);
				default:
					var didntUnderstandMessageText = Resources.Messages.Global.SorryIDontUnderstand;
					var didntUnderstandMessage = MessageFactory.Text(didntUnderstandMessageText, didntUnderstandMessageText, InputHints.IgnoringInput);
					await stepContext.Context.SendActivityAsync(didntUnderstandMessage, cancellationToken);
					break;
			}

			return await stepContext.NextAsync(null, cancellationToken);
		}

		private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			var messageText = stepContext.Options?.ToString() ?? Resources.Messages.Global.AnythingElse;
			var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);
			await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
			return await stepContext.EndDialogAsync(cancellationToken);
		}

	}
}
