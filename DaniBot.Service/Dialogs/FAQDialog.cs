// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Avanade.HackathonAzul.DaniBot.Constants;
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
			await stepContext.Context.SendActivityAsyncFromAdaptiveCard(CardFactory.CreateFAQMenuCardBuilder(), cancellationToken);
			return new DialogTurnResult(DialogTurnStatus.Waiting);
		}

		private async Task<DialogTurnResult> ActionSteps(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			switch (stepContext.Result.ToString())
			{
				case FAQDialogConstants.CheckIn:
                    await stepContext.Context.SendActivityAsyncFromAdaptiveCard(
                        CardFactory.CreateFAQViewCardBuilder(
                            new FAQViewModel
                            {
                                Title =  Resources.Messages.FAQDialog.CheckInTitle,
                                Content = Resources.Messages.FAQView.ContentCheckIn,
                                Image = Resources.Messages.FAQView.UrlCheckIn
							}),
                        cancellationToken);

                    break;

				case FAQDialogConstants.TudoAzul:
                    await stepContext.Context.SendActivityAsyncFromAdaptiveCard(
                        CardFactory.CreateFAQViewCardBuilder(
                            new FAQViewModel
                            {
                                Title = Resources.Messages.FAQDialog.TudoAzulTitle,
								Content = Resources.Messages.FAQView.ContentTudoAzul,
								Image = Resources.Messages.FAQView.UrlTudoAzul
							}),
                        cancellationToken);
					break;

				case FAQDialogConstants.Dani:
                    await stepContext.Context.SendActivityAsyncFromAdaptiveCard(
                        CardFactory.CreateFAQViewCardBuilder(
                            new FAQViewModel
                            {
                                Title = Resources.Messages.FAQDialog.DaniTitle,
								Content = Resources.Messages.FAQView.ContentDani,
								Image = Resources.Messages.FAQView.UrlDani
							}),
                        cancellationToken);
					break;

				default:
					var didntUnderstandMessageText = Resources.Messages.Global.SorryIDontUnderstand;

                    Activity didntUnderstandMessage = MessageFactory.Text(didntUnderstandMessageText, didntUnderstandMessageText, InputHints.IgnoringInput);
					await stepContext.Context.SendActivityAsync(didntUnderstandMessage, cancellationToken);
					break;
			}

			return await stepContext.EndDialogAsync(cancellationToken);
		}
	}
}