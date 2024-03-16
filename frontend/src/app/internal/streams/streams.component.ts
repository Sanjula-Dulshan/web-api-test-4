import { Component, OnInit } from '@angular/core';
import { InternalService } from '../internal.service';

@Component({
  selector: 'app-streams',
  templateUrl: './streams.component.html',
  styleUrls: ['./streams.component.scss'],
})
export class StreamsComponent implements OnInit {
  streams: any[] = [];

  constructor(private internalService: InternalService) {}

  ngOnInit(): void {
    this.internalService.getStreams().subscribe({
      next: (res: any) => {
        this.streams = res;
        console.log('res>> ', res);
      },
      error: (err) => {
        console.log('error>>>', err);
      },
    });
  }
}
