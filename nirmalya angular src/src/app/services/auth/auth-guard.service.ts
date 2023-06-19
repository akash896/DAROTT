import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthDataService } from './auth-data.service';
import { AuthService } from './auth.service';
import { environment, PageList } from './../../environments/environment';
@Injectable({
    providedIn: 'root'
})
export class AuthGuardService implements CanActivate {
    active = false;
    admin = 0;
    name = "";
    phoneno = "";
    emailid = "";

    constructor(
        public authService: AuthService,
        public router: Router,
        private authDataService: AuthDataService
    ) {
        //this.authService.check();
    }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
        let admin = 0;
        for (var i = 0; i < PageList.length; i++) {
            for (var j = 0; j < PageList[i].list.length; j++) {
                if (state.url.indexOf(PageList[i].list[j].url.split("/").splice(-1)[0]) > 0) {
                    admin = PageList[i].list[j].admin;
                }
            }
        }
        return new Observable(observer => {
            console.log(admin, state.url)
            if (admin == 0) {
                observer.next(true);
                observer.complete();
                return;
            }
            console.log('************going', route.url, state.url);
            this.authDataService.check(admin).subscribe(
                res => {
                    if (res.isSuccess) {
                        console.log('************going ok', res);
                        observer.next(true);
                        observer.complete();
                        this.getData();
                    } else {
                        console.log('************going else');
                        this.router.navigate(['login']);
                        observer.next(false);
                        observer.complete();
                    }
                }
            );
        });
    }
    getData() {
        this.authDataService.getUserData().subscribe(res => {
            if (!res.err) {
                this.phoneno = res.phoneno;
                this.emailid = res.emailid;
                this.admin = res.admin;
                this.active = res.active;
                this.name = res.name;
            }
        });
    }
    logout() {
        this.authDataService.logout().subscribe(res => {
            if (!res.err) {
                this.phoneno = "";
                this.emailid = "";
                this.admin = 0;
                this.active = false;
                this.name = "";
                window.localStorage.setItem(environment.SESSION_ID, "null");
                window.localStorage.setItem(environment.SESSION_PASS, "null");
                this.router.navigate(['login']);
            }
        });
    }
}
