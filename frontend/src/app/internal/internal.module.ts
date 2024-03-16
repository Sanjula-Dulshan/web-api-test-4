import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InternalRoutingModule } from './internal-routing.module';
import { StreamsComponent } from './streams/streams.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [StreamsComponent, AddStudentComponent],
  imports: [CommonModule, InternalRoutingModule, ReactiveFormsModule],
})
export class InternalModule {}
