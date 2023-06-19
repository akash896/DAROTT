import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    username: string = "";
    password: string = "";
    constructor(private message: NzMessageService, public router: Router, private authService: AuthService) { }

    ngOnInit() {
    }

    login() {
        if (this.username.trim() == "" || this.password.trim() == "") {
            this.message.create("error", `username or password is empty`);
        } else {
            this.authService.login(this.username.trim(), this.password.trim()).subscribe(res => {;
                this.router.navigate(['movies-upload'])
                console.log(res);
            });
        }
    }
}
