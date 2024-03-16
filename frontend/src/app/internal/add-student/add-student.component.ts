import { Component } from '@angular/core';
import { StreamsService } from '../streams.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.scss'],
})
export class AddStudentComponent {
  streams: any[] = [];

  constructor(private streamService: StreamsService) {}

  ngOnInit(): void {
    this.streamService.getStreams().subscribe({
      next: (res: any) => {
        this.streams = res;
        console.log('res>> ', this.streams);
      },
      error: (err) => {
        console.log('error>>> ', err);
      },
    });
  }
}
