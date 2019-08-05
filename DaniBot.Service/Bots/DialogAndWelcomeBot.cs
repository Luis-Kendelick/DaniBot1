// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AdaptiveCards;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.Azul.DaniBot.Bots
{
	public class DialogAndWelcomeBot<T> : DialogBot<T>
		where T : Dialog
	{
		public DialogAndWelcomeBot(ConversationState conversationState, UserState userState, T dialog, ILogger<DialogBot<T>> logger)
			: base(conversationState, userState, dialog, logger)
		{
		}

		protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
		{
			foreach (var member in membersAdded)
			{
				// Greet anyone that was not the target (recipient) of this message.
				// To learn more about Adaptive Cards, see https://aka.ms/msbot-adaptivecards for more details.
				if (member.Id != turnContext.Activity.Recipient.Id)
				{
					var welcomeCard = CreateAdaptiveCardAttachment();
					var response = CreateResponse(turnContext.Activity.Create(, welcomeCard);
					await turnContext.SendActivityAsync(response, cancellationToken);
					await Dialog.RunAsync(turnContext, ConversationState.CreateProperty<DialogState>("DialogState"), cancellationToken);
				}
			}
		}

		// Create an attachment message response.
		private Activity CreateResponse(IActivity activity, Attachment attachment)
		{
			var response = ((Activity)activity).CreateReply();
			response.Attachments = new List<Attachment>() { attachment };
			return response;
		}

		// Load attachment from file.
		private Attachment CreateAdaptiveCardAttachment()
		{
			AdaptiveCard card = new AdaptiveCard("1.0");

			card.Body.Add(new AdaptiveTextBlock()
			{
				Text = "Olá, eu sou Dani e irei te auxiliar nesse atendimento. Por favor, selecione uma das opções abaixo ou digite o que você gostaria de consultar:",
				Size = AdaptiveTextSize.Default,
				Wrap = true
			});

			card.Body.Add(new AdaptiveImage()
			{
				Url = new Uri("http://adaptivecards.io/content/cats/1.png")
			});

			card.Actions.Add(new AdaptiveSubmitAction()
			{
				Title = "Localizar voo",
				Data = "localizarVoo"
			});

			card.Actions.Add(new AdaptiveSubmitAction()
			{
				Title = "Realizar cadastro",
				Data = "cadastro"
			});

			card.Actions.Add(new AdaptiveSubmitAction()
			{
				Title = "FAQ",
				Data = "faq"
			});

			card.Actions.Add(new AdaptiveSubmitAction()
			{
				Title = "Reset de senha",
				Data = "resetSenha"
			});

			card.Actions.Add(new AdaptiveSubmitAction()
			{
				Title = "Login",
				Data = "login"
			});

			return new Attachment()
			{
				ContentType = AdaptiveCard.ContentType,
				Content = card,
			};
		}
	}
}
