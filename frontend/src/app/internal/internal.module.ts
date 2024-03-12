import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InternalRoutingModule } from './internal-routing.module';
import { StreamsComponent } from './streams/streams.component';

@NgModule({
  declarations: [StreamsComponent],
  imports: [CommonModule, InternalRoutingModule],
})
export class InternalModule {}
