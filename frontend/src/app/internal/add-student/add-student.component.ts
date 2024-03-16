import { Component } from '@angular/core';
import { InternalService } from '../internal.service';
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

  constructor(
    private internalService: InternalService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.studentForm = this.fb.group({
      firstName: ['', Validators.required],
      secondName: [''],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      stream: ['', Validators.required],
      gender: ['', Validators.required],
    });

    this.internalService.getStreams().subscribe({
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

      this.internalService.registerStudent(newStudent).subscribe({
        next: (res: any) => {
          alert('Student Registered with ID: ' + res.result);
        },
        error: (err) => {
          console.log('error>> ', err);
        },
      });
    } else {
      console.log('form is invalid');
    }
  }
}
