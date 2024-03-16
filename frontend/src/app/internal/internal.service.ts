import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from 'interface';

@Injectable({
  providedIn: 'root',
})
export class InternalService {
  constructor(private http: HttpClient) {}

  url: string = '/api/';

  getStreams() {
    return this.http.get(this.url + 'stream');
  }

  registerStudent(data: Student) {
    return this.http.post(this.url + 'students', data);
  }
}
