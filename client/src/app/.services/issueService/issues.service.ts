import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BoardTask } from '../../.classes/board-task';

@Injectable({
  providedIn: 'root'
})
export class IssuesService {

  constructor(private http: HttpClient) { }

  getAllIssues() : Observable<BoardTask[]> {
    return this.http.get<BoardTask[]>("./issues/getall");
  }
}
