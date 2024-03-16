import { Component } from '@angular/core';
import { StreamsService } from '../streams.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Student } from 'interface';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.scss'],
})
export class AddStudentComponent {
  studentForm!: FormGroup;
  streams: any[] = [];

  constructor(private streamService: StreamsService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.studentForm = this.fb.group({
      firstName: ['', Validators.required],
      secondName: [''],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      stream: ['', Validators.required],
      gender: ['', Validators.required],
    });

    this.streamService.getStreams().subscribe({
      next: (res: any) => {
        this.streams = res;
      },
      error: (err) => {
        console.log('error>>> ', err);
      },
    });
  }

  onSubmit(): void {
    if (this.studentForm.valid) {
      const newStudent: Student = this.studentForm.value;
      console.log('newStudent>> ', newStudent);
    } else {
      console.log('form is invalid');
    }
  }
}
