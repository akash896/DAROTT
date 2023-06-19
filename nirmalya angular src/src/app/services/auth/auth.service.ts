import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthDataService } from './auth-data.service';
import { environment, PageList } from './../../environments/environment';
@Injectable({
    providedIn: 'root'
})
export class AuthService {
    loggedIn = false;
    active = false;
    admin = 0;
    name = "";
    phoneno = "";
    emailid = "";

    constructor(
        private authDataService: AuthDataService
    ) { }
    check(isadmin: Number) {
        this.authDataService.check(isadmin).subscribe (
            res=> {
                this.loggedIn = res.isSuccess;
                this.active = res.isSuccess ? res.data.active : false;
                this.admin = res.isSuccess ? res.data.admin : 0;
                this.phoneno = res.isSuccess ? res.data.phoneno : "";
                this.emailid = res.isSuccess ? res.data.emailid : "";
            }
        );
    }
    login(id: string, password: string): Observable<any> {
        return new Observable(observer => {
            this.authDataService.login(id, password).subscribe (
                res=> {
                    // window.localStorage.setItem(environment.SESSION_ID, res.data[environment.SESSION_ID]);
                    // window.localStorage.setItem(environment.SESSION_PASS, res.data[environment.SESSION_PASS]);
                    this.loggedIn = res.isSuccess;
                    this.active = res.isSuccess ? res.data.active : false;
                    this.admin = res.isSuccess ? res.data.admin : 0;
                    this.phoneno = res.isSuccess ? res.data.phoneno : "";
                    this.emailid = res.isSuccess ? res.data.emailid : "";
                    observer.next(res);
                    observer.complete();
                }
            );
        });
    }
    logout(): Observable<any> {
        return new Observable(observer => {
            this.authDataService.logout().subscribe (
                res=> {
                    if (res.isSuccess) {
                        this.loggedIn = false;
                        this.active = false;
                        this.admin = 0;
                        this.name = "";
                        this.phoneno = "";
                        this.emailid = "";
                    }
                    observer.next(res);
                    observer.complete();
                }
            );
        });
    }
}
