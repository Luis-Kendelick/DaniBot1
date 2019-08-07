using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.HackathonAzul.DaniBot.Dialogs.LoginDialogs
{
	public class AuthenticateViaTextDialog : ComponentDialog
	{
		public AuthenticateViaTextDialog()
			: base(nameof(AuthenticateViaTextDialog))
		{
			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
			{
				WaitUserInputs,
				SendLogin,
				FinalStepAsync,
			}));

			InitialDialogId = nameof(WaterfallDialog);
		}

		private async Task<DialogTurnResult> WaitUserInputs(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			await stepContext.Context.SendActivityAsyncFromAdaptiveCard(CardFactory.CreateAuthenticateByTextCardBuilder(), cancellationToken);
			return new DialogTurnResult(DialogTurnStatus.Waiting);
		}

		private async Task<DialogTurnResult> SendLogin(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			UserModel userModel = JsonConvert.DeserializeObject<UserModel>(stepContext.Context.Activity.Value.ToString());
			return await stepContext.EndDialogAsync(cancellationToken);
		}

		private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			return await stepContext.EndDialogAsync(cancellationToken);
		}
	}
}
