import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';

@Injectable({
    providedIn: 'root',
})
export class MoviesService {
    constructor(private http: HttpClient) { }
    add( data : any ):Observable<any> {
        let url = environment.PATH + `movies/moviesAddModify`;
        return this.http.post( url , data , { withCredentials: true } ) ;
    }
    getGenres():Observable<any> {
        let url = environment.PATH + `movies/getGenres`;
        return this.http.get( url ) ;
    }
    getCrewCategories():Observable<any> {
        let url = environment.PATH + `movies/getCrewCategories`;
        return this.http.get( url ) ;
    }
}
