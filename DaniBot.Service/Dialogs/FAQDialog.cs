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
					await stepContext.Context.SendActivityAsync(IActivityExtensions.CreateFAQAdaptiveCardActitvity(stepContext, titleFAQ: "Quais as vantagens de fazer o check-in online?", FAQText: "Para começar, a praticidade: você pode fazer seu check-in de qualquer lugar onde estiver, até 2 dias antes do vôo, com toda calma. Além disso, você economiza tempo, pois não precisa enfrentar nenhum tipo de fila no aeroporto para o check-in. E começa sua viagem muito mais tranquilo: mesmo que ocorra algum imprevisto como um engarrafamento ou pneu furado, com o check-in on-line feito, é só apresentar-se a tempo para o embarque e sua viagem está garantida.", urlImage: "https://www.jornaldeturismo.tur.br/images/stories/2016/dez2016/check_in_azul.jpeg"), cancellationToken);
					break;
				case "TudoAzulFaq":
					await stepContext.Context.SendActivityAsync(IActivityExtensions.CreateFAQAdaptiveCardActitvity(stepContext, titleFAQ: "Como funciona o Tudo Azul?", FAQText: "O Programa de Vantagens TudoAzul é simples e fácil. Com ele, a cada R$ 1,00* gasto na compra de uma passagem, você ganha até 2 pontos na sua conta TudoAzul. A partir de 5.000 pontos você já pode viajar resgatando um trecho da Azul com seus pontos. O TudoAzul não tem limitação de assentos e nem de dia. \n* Válido para tarifas regulares das viagens realizadas, não incluindo taxas de embarque.", urlImage: "https://www.turningleftforless.com.br/wp-content/uploads/2019/01/tudoazul-37ldqbthhph2rhau05x5oq1-770x437.png"), cancellationToken);
					break;
				case "VantagensDani":
					await stepContext.Context.SendActivityAsync(IActivityExtensions.CreateFAQAdaptiveCardActitvity(stepContext, titleFAQ: "Quais a vantagens de utilizar Dani?", FAQText: "Dani é o novo assistente virtual da Azul no qual você pode realizar seu Check-in online, consultar o extrato de pontos do Tudo Azul, regastar seus pontos e ainda consultar as melhores promoções para o seu perfil. \nVocê também pode tirar dúvidas com um fluxo de conversa personalizado para atender os suas necessidades da melhor forma.\nAinda tem mais, se você está viajando pela primeira vez com a nossa companhia e gostaria de consultar os detalhes do seu vôo, não se preocupe, Dani irá te ajudar a se cadastrar na nossa ferramenta e você terá a opção de realizar o login através de um comando de voz.\nPrático, rápido e com uma inteligência aritificial integrada que irá deixar o seu atendimento muito mais prazeroso.", urlImage: "https://southcentralus1-mediap.svc.ms/transform/thumbnail?provider=spo&inputFormat=jpg&cs=fFNQTw&docid=https%3A%2F%2Favanade.sharepoint.com%3A443%2F_api%2Fv2.0%2Fdrives%2Fb!5j10HBdHkUecpHZWx0mKRtplaoEKTjJKqfykS8SBAtJfO7OuYV9bQYBDbDDKTHLl%2Fitems%2F01LRD2ZECWTVFFEJRDMRH3RNFPJQUIM4PG%3Fversion%3DPublished&access_token=eyJ0eXAiOiJKV1QiLCJhbGciOiJub25lIn0.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTBmZjEtY2UwMC0wMDAwMDAwMDAwMDAvYXZhbmFkZS5zaGFyZXBvaW50LmNvbUBjZjM2MTQxYy1kZGQ3LTQ1YTctYjA3My0xMTFmNjZkMGIzMGMiLCJpc3MiOiIwMDAwMDAwMy0wMDAwLTBmZjEtY2UwMC0wMDAwMDAwMDAwMDAiLCJuYmYiOiIxNTY1MDUzNDQzIiwiZXhwIjoiMTU2NTA3NTA0MyIsImVuZHBvaW50dXJsIjoiMkhnemMvcE5aUUYyMTNlcTJDQ3BVS28zV2JDTlN6Zk05NDdmNlBsdnNNWT0iLCJlbmRwb2ludHVybExlbmd0aCI6IjExNCIsImlzbG9vcGJhY2siOiJUcnVlIiwiY2lkIjoiTVRNMllXWTNPV1V0TXpBME1TMDVNREF3TFRFek5EVXRZbVpoWW1FeFpqUTRNVEkyIiwidmVyIjoiaGFzaGVkcHJvb2Z0b2tlbiIsInNpdGVpZCI6Ik1XTTNORE5rWlRZdE5EY3hOeTAwTnpreExUbGpZVFF0TnpZMU5tTTNORGs0WVRRMiIsInNpZ25pbl9zdGF0ZSI6IltcImttc2lcIl0iLCJuYW1laWQiOiIwIy5mfG1lbWJlcnNoaXB8YS5hLm1lZGVpcm9zLmNpbnRyYUBhdmFuYWRlLmNvbSIsIm5paSI6Im1pY3Jvc29mdC5zaGFyZXBvaW50IiwiaXN1c2VyIjoidHJ1ZSIsImNhY2hla2V5IjoiMGguZnxtZW1iZXJzaGlwfDEwMDMwMDAwYWViMGM2YTNAbGl2ZS5jb20iLCJ0dCI6IjAiLCJ1c2VQZXJzaXN0ZW50Q29va2llIjoiMyJ9.UUt0dktsRUdWSGcxeUtZaGpidVZXQ2NGaDhZSW5zdFpBRXZraHBnMCtJRT0&encodeFailures=1&srcWidth=&srcHeight=&width=250&height=250&action=Access"), cancellationToken);
					break;
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