import { Component } from '@angular/core';
import { PageList } from './environments/environment';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthDataService } from './services/auth/auth-data.service';
import { AuthService } from './services/auth/auth.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    isCollapsed = false;
    pageList = PageList;
    pageGroup: any[  ] = [  ]
    constructor(public authService: AuthService, public router: Router, private authDataService: AuthDataService) {
        router.events.subscribe(e => {
            let te: any = e;
            if (e.constructor.name ==  'NavigationEnd') {
                this.pageGroup = this.getPageGroup(te.url);
            }
            // console.log(e, e.constructor.name);
        });
    }
    ngOnInit() {
        this.authDataService.check(1).subscribe(
            res => {
                if (res.isSuccess) {
                    console.log('************going ok', res);
                } else {
                    console.log('************going else');
                    // this.router.navigate(['login']);
                }
            }
        );
    }
    getPageGroup(url: string) {
        let pageGroup: any[  ] = [  ];
        for (var i = 0; i < PageList.length; i++) {
            for (var j = 0; j < PageList[i].list.length; j++) {
                if (url.indexOf(PageList[i].list[j].url.split("/").splice(-1)[0]) > 0) {
                    pageGroup = PageList[i].list[j].group;
                }
            }
        }
        console.log(url, pageGroup);
        return pageGroup;
    }
}
