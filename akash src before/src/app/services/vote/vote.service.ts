import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VoteService {

  constructor(private http:HttpClient) { }

  addVote(data: any):Observable<any> {
    let url = environment.PATH + '/vote/addVote';
    return this.http.post(url, data);
  }

  updateVote(data: any):Observable<any> {
    let url = environment.PATH + '/vote/updateVote';
    return this.http.post(url, data);
  }

// /vote/getAllVotes?pageno=1&limit=2
  getAllVotes(data: any):Observable<any> {
    let url = environment.PATH + `/vote/getAllVotes?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }

  getVoteById(data: any):Observable<any> {
    let url = environment.PATH + `/vote/getVoteById?id=${data.id}`;
    return this.http.get(url);
  }

  giveVote(data: any):Observable<any> {
    let url = environment.PATH + '/vote/giveVote';
    return this.http.post(url, data);
  }

  addLike(data: any):Observable<any> {
    let url = environment.PATH + `/vote/addLike?voteId=${data.voteId}`;
    return this.http.get(url);
  }

  addDislike(data: any):Observable<any> {
    let url = environment.PATH + `/vote/addDislike?voteId=${data.voteId}`;
    return this.http.get(url);
  }

  addShare(data: any):Observable<any> {
    let url = environment.PATH + `/vote/addShare?voteId=${data.voteId}`;
    return this.http.get(url);
  }

  getAllLikesOnVotes(data: any):Observable<any> {
    let url = environment.PATH + `/vote/getAllLikesOnVotes?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }
  getAllDislikesOnVotes(data: any):Observable<any> {
    let url = environment.PATH + `/vote/getAllDislikesOnVotes?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }
  getAllShareOnVotes(data: any):Observable<any> {
    let url = environment.PATH + `/vote/getAllShareOnVotes?pageno=${data.pageno}&limit=${data.limit}`;
    return this.http.get(url);
  }

  deleteVoteById(data: any):Observable<any> {
    let url = environment.PATH + `/vote/deleteVoteById?id=${data.id}`;
    return this.http.get(url);
  }

}
