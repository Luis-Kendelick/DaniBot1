import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import * as WebChat from 'botframework-webchat';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {

  @ViewChild('botWindow') botWindowElement: ElementRef;

  constructor() { }

  async ngOnInit() {

    const styleSet = WebChat.createStyleSet();

    // styleSet.activities = {
    //   ...styleSet.activities,
    //   background: `url('assets/azul_brasil_logo.png') space`
    // };


    const directLine = WebChat.createDirectLine({
      secret: '2J-XNWNfX58.eSV42zJwEytyTCEjaU5tR3qCB125u0NYe7C7pfP_TmA',
      webSocket: false
    });

    const userID = `${Date.now()}`;
    const webSpeechPonyfillFactory = await WebChat.createCognitiveServicesSpeechServicesPonyfillFactory({
      region: 'westus2',
      subscriptionKey: '8baf7e610bc640eaa32905b01dacc06d'
    });

    
    WebChat.renderWebChat({
      directLine,
      userID,
      // locale: 'pt-BR',
      sendTypingIndicator: true,
      styleSet,
      webSpeechPonyfillFactory
    },
      this.botWindowElement.nativeElement
    );

    directLine
      .postActivity({
        from: { id: userID, name: 'Thiago Burgo' },
        name: 'requestWelcomeDialog',
        type: 'event',
        value: 'token'
      })
      .subscribe(
        id => console.log(`Posted activity, assigned ID ${id}`),
        error => console.log(`Error posting activity ${error}`)
      );
  }

}
