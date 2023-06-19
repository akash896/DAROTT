import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private http:HttpClient) { }

  addEventPage(data: any):Observable<any> {
    let url = environment.PATH + '/event/addEventPage';
    return this.http.post(url, data);
  }

  updateEventPage(data: any):Observable<any> {
    let url = environment.PATH + '/event/updateEventPage';
    return this.http.post(url, data);
  }


// /vote/getAllVotes?pageno=1&limit=2
getAllEventPage(data: any):Observable<any> {
    let url = environment.PATH + `/event/getAllEventPage?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }

  getEventPageById(data: any):Observable<any> {
    let url = environment.PATH + `/event/getEventPageById?id=${data.id}`;
    return this.http.get(url);
  }

  getEventPageByType(data: any):Observable<any> {
    let url = environment.PATH + `/event/getEventPageByType?id=${data.id}`;
    return this.http.get(url);
  }

  deleteEventPageById(data: any):Observable<any> {
    let url = environment.PATH + `/event/deleteEventPageById?id=${data.id}`;
    return this.http.get(url);
  }

}
