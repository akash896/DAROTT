import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HoroscopeService {

  constructor(private http:HttpClient) { }

  addHoroscope(data: any):Observable<any> {
    let url = environment.PATH + '/horoscope/addHoroscope';
    return this.http.post(url, data);
  }

  updateHoroscope(data: any):Observable<any> {
    let url = environment.PATH + '/horoscope/updateHoroscope';
    return this.http.post(url, data);
  }


// /vote/getAllVotes?pageno=1&limit=2
getAllHoroscope(data: any):Observable<any> {
    let url = environment.PATH + `/horoscope/getAllHoroscope?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }

  getHoroscopeById(data: any):Observable<any> {
    let url = environment.PATH + `/horoscope/getHoroscopeById?id=${data.id}`;
    return this.http.get(url);
  }

  getHoroscopeByPeriodType(data: any):Observable<any> {
    let url = environment.PATH + `/horoscope/getHoroscopeByPeriodType?id=${data.id}`;
    return this.http.get(url);
  }

  deleteHoroscopeById(data: any):Observable<any> {
    let url = environment.PATH + `/horoscope/deleteHoroscopeById?id=${data.id}`;
    return this.http.get(url);
  }

}
