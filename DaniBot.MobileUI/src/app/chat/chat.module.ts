import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';

import { ChatComponent } from './chat.component';

@NgModule({
  imports: [
    CommonModule,
    IonicModule
  ],
  declarations: [ChatComponent],
  exports:[
      ChatComponent
  ]
})
export class ChatComponentModule {}
