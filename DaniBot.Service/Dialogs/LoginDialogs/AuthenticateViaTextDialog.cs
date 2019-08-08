using Avanade.Azul.DaniBot.Dialogs;
using Avanade.HackathonAzul.DaniBot.Cards.Factory;
using Avanade.HackathonAzul.DaniBot.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.HackathonAzul.DaniBot.Dialogs.LoginDialogs
{
	public class AuthenticateViaTextDialog : ComponentDialog
	{
		private UserModel _UserModel = new UserModel()
		{
			User = "userTest",
			Password = "senha123"
		};

		private readonly string AuthenticatedMenuDialogId;

		public AuthenticateViaTextDialog()
			: base(nameof(AuthenticateViaTextDialog))
		{
			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new AuthenticatedMenuDialog());
			AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
			{
				WaitUserInputs,
				SendLogin,
				FinalStepAsync,
			}));

			AuthenticatedMenuDialogId = nameof(AuthenticatedMenuDialog);
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

			if (userModel.User == _UserModel.User && userModel.Password == _UserModel.Password)
				return await stepContext.BeginDialogAsync(AuthenticatedMenuDialogId, cancellationToken);
			else
			{
				Activity userPasswordWrongMessage = MessageFactory.Text(Resources.Messages.Error.WrongUserAndPassword, Resources.Messages.Error.WrongUserAndPassword, InputHints.IgnoringInput);
				await stepContext.Context.SendActivityAsync(userPasswordWrongMessage, cancellationToken);
				return await stepContext.ReplaceDialogAsync(InitialDialogId, options: null, cancellationToken: cancellationToken);
			}
		}

		private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
		{
			return await stepContext.EndDialogAsync(cancellationToken);
		}
	}
}
