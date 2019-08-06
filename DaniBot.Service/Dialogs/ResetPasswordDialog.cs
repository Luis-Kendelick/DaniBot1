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

namespace Avanade.Azul.DaniBot.Dialogs
{
	public class ResetPasswordDialog : ComponentDialog
	{
		public ResetPasswordDialog()
			: base(nameof(ResetPasswordDialog))
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
			await stepContext.Context.SendActivityAsync("Acesse o nosso [site](https://tudoazul.voeazul.com.br/web/azul/forgot-password?viewMode=forgot_password) para realizar o seu reset de senha. Em breve poderei resetá-la para você!");
			return await stepContext.EndDialogAsync(cancellationToken);
		}
	}
}