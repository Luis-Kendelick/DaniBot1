// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Microsoft.Recognizers.Text.DataTypes.TimexExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.Azul.DaniBot.Dialogs
{
	public class MainDialog : ComponentDialog
	{
		private readonly FlightBookingRecognizer _luisRecognizer;
		protected readonly ILogger Logger;
		private readonly string FAQDialogId;

		public MainDialog(FlightBookingRecognizer luisRecognizer, ILogger<MainDialog> logger)
			: base(nameof(MainDialog))
		{
			_luisRecognizer = luisRecognizer;
			Logger = logger;

			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new FAQDialog());
			AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
			{
                IntroStepAsync,
                ActStepAsync,
				FinalStepAsync,
			}));

			FAQDialogId = nameof(FAQDialog);
			InitialDialogId = nameof(WaterfallDialog);
		}

		private async Task<DialogTurnResult> IntroStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			await stepContext.Context.SendAdaptiveCardsActivityAsyncFrom(CardFactory.CreateWelcomeCardBuilder(), cancellationToken);
			return new DialogTurnResult(DialogTurnStatus.Waiting);
		}

		private async Task<DialogTurnResult> ActStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			switch (stepContext.Result.ToString())
			{
				case "LocalizarVoo":
					//return await stepContext.BeginDialogAsync(nameof(LocateFlightDialog), cancellationToken);
				case "RealizarCadastro":
					//return await stepContext.BeginDialogAsync(nameof(RegisterDialog), cancellationToken);
				case "ConsultarFAQ":
					return await stepContext.BeginDialogAsync(FAQDialogId, cancellationToken);
				case "ResetSenha":
					//return await stepContext.BeginDialogAsync(nameof(ResetPasswordDialog), cancellationToken);
				case "Login":
					//return await stepContext.BeginDialogAsync(nameof(AuthenticateDialog), cancellationToken);
				default:
					var didntUnderstandMessageText = "Desculpe, não entendi!";
					var didntUnderstandMessage = MessageFactory.Text(didntUnderstandMessageText, didntUnderstandMessageText, InputHints.IgnoringInput);
					await stepContext.Context.SendActivityAsync(didntUnderstandMessage, cancellationToken);
					break;
			}

			return await stepContext.NextAsync(null, cancellationToken);
		}

		private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			var messageText = stepContext.Options?.ToString() ?? "Em que mais posso te ajudar?";
			var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);
			return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
		}

	}
}
