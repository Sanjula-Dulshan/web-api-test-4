import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class StreamsService {
  constructor(private http: HttpClient) {}

  url: string = '/api/Stream';

  getStreams() {
    return this.http.get(this.url);
  }
}
