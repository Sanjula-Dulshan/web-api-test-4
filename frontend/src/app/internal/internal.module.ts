import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InternalRoutingModule } from './internal-routing.module';
import { StreamsComponent } from './streams/streams.component';
import { AddStudentComponent } from './add-student/add-student.component';

@NgModule({
  declarations: [StreamsComponent, AddStudentComponent],
  imports: [CommonModule, InternalRoutingModule],
})
export class InternalModule {}
