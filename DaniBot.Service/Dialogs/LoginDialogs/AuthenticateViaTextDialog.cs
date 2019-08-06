using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
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

		private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		private async Task<DialogTurnResult> SendLogin(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
