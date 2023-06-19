import { NgModule } from '@angular/core';

import { LoginRoutingModule } from './login-routing.module';

import { LoginComponent } from './login.component';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { modules } from '../../commonHelper'


@NgModule({
  imports: [LoginRoutingModule, NzButtonModule, ...modules],
  declarations: [LoginComponent],
  exports: [LoginComponent]
})
export class LoginModule { }
