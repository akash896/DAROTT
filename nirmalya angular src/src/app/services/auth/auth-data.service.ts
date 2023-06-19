import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';
@Injectable({
    providedIn: 'root'
})
export class AuthDataService {
    constructor(private http:HttpClient) { }
    // check if logged in
    check(isadmin: Number):Observable<any> {
        let url = environment.PATH + `user/checklogin?admin=${isadmin}`;
        var data: any = {  };
        data["admin"] = isadmin;
        // data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
        // data[environment.SESSION_PASS] = window.localStorage.getItem(environment.SESSION_PASS);
        return this.http.post(url, data , { withCredentials: true });
    }
    login(id: string, password: string):Observable<any> {
        let data:any = {
            id: id.toString(),
            password: password.toString()
        }
        // data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
        // data[environment.SESSION_PASS] = window.localStorage.getItem(environment.SESSION_PASS);
        // let options = new RequestOptions({ headers: headers, withCredentials: true });
        let url = environment.PATH + 'user/login';
        return this.http.post(url, data , { withCredentials: true } );
    }
    logout():Observable<any> {
        let data: any = {  };
        // data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
        // data[environment.SESSION_PASS] = window.localStorage.getItem(environment.SESSION_PASS);
        let url = environment.PATH + 'user/logout';
        return this.http.post(url, data , { withCredentials: true });
    }
    getUserData():Observable<any> {
        let data: any = {  };
        // data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
        // data[environment.SESSION_PASS] = window.localStorage.getItem(environment.SESSION_PASS);
        let url = environment.PATH + 'user/get';
        return this.http.post(url, data , { withCredentials: true });
    }
    // create(data):Observable<any> {
    //     data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
    //     data[environment.SESSION_USERID] = window.localStorage.getItem(environment.SESSION_USERID);
    //     let url = environment.PATH + 'users/create';
    //     return this.http.post(url, data);
    // }
    // update(data):Observable<any> {
    //     data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
    //     data[environment.SESSION_USERID] = window.localStorage.getItem(environment.SESSION_USERID);
    //     let url = environment.PATH + 'users/update';
    //     return this.http.post(url, data);
    // }
    // getUsers(data):Observable<any> {
    //     data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
    //     data[environment.SESSION_USERID] = window.localStorage.getItem(environment.SESSION_USERID);
    //     let url = environment.PATH + 'users/getusers';
    //     return this.http.post(url, data);
    // }
    // getUsersCount(data):Observable<any> {
    //     data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
    //     data[environment.SESSION_USERID] = window.localStorage.getItem(environment.SESSION_USERID);
    //     let url = environment.PATH + 'users/getuserscount';
    //     return this.http.post(url, data);
    // }
    // deactivate(data):Observable<any> {
    //     data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
    //     data[environment.SESSION_USERID] = window.localStorage.getItem(environment.SESSION_USERID);
    //     let url = environment.PATH + 'users/deactivate';
    //     return this.http.post(url, data);
    // }
    // activate(data):Observable<any> {
    //     data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
    //     data[environment.SESSION_USERID] = window.localStorage.getItem(environment.SESSION_USERID);
    //     let url = environment.PATH + 'users/activate';
    //     return this.http.post(url, data);
    // }
    // deleteUser(data):Observable<any> {
    //     data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
    //     data[environment.SESSION_USERID] = window.localStorage.getItem(environment.SESSION_USERID);
    //     let url = environment.PATH + 'users/deleteuser';
    //     return this.http.post(url, data);
    // }
    // setSalary(data):Observable<any> {
    //     data[environment.SESSION_ID] = window.localStorage.getItem(environment.SESSION_ID);
    //     data[environment.SESSION_USERID] = window.localStorage.getItem(environment.SESSION_USERID);
    //     let url = environment.PATH + 'users/setsalary';
    //     return this.http.post(url, data);
    // }
}
