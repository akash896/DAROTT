import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PollService {

  constructor(private http:HttpClient) { }

  addPoll(data: any):Observable<any> {
    let url = environment.PATH + '/poll/addPoll';
    return this.http.post(url, data);
  }

  updatePoll(data: any):Observable<any> {
    let url = environment.PATH + '/poll/updatePoll';
    return this.http.post(url, data);
  }

  givePoll(data: any):Observable<any> {
    let url = environment.PATH + '/poll/givePoll';
    return this.http.post(url, data);
  }

// /vote/getAllVotes?pageno=1&limit=2
GetAllPoll(data: any):Observable<any> {
    let url = environment.PATH + `/poll/GetAllPoll?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }

  getPollById(data: any):Observable<any> {
    let url = environment.PATH + `/poll/getPollById?id=${data.id}`;
    return this.http.get(url);
  }



  addLike(data: any):Observable<any> {
    let url = environment.PATH + `/poll/addLike?pollId=${data.pollId}`;
    return this.http.get(url);
  }

  addDislike(data: any):Observable<any> {
    let url = environment.PATH + `/poll/addDislike?pollId=${data.pollId}`;
    return this.http.get(url);
  }

  addShare(data: any):Observable<any> {
    let url = environment.PATH + `/poll/addShare?pollId=${data.pollId}`;
    return this.http.get(url);
  }

  addComment(data: any):Observable<any> {
    let url = environment.PATH + '/poll/addComment';
    return this.http.post(url, data);
  }

  getAllLikesOnPolls(data: any):Observable<any> {
    let url = environment.PATH + `/poll/getAllLikesOnPolls?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }
  getAllDislikesOnVotes(data: any):Observable<any> {
    let url = environment.PATH + `/poll/getAllDislikesOnVotes?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }
  getAllDislikesOnPolls(data: any):Observable<any> {
    let url = environment.PATH + `/poll/getAllDislikesOnPolls?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }

  getAllShareOnPolls(data: any):Observable<any> {
    let url = environment.PATH + `/poll/getAllShareOnPolls?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }

  getAllCommentOnPolls(data: any):Observable<any> {
    let url = environment.PATH + `/poll/getAllCommentOnPolls?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }

  deletePollById(data: any):Observable<any> {
    let url = environment.PATH + `/poll/deletePollById?id=${data.id}`;
    return this.http.get(url);
  }

}
