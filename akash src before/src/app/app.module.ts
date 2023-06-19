import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { ne_NP } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import ne from '@angular/common/locales/ne';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { IconsProviderModule } from './icons-provider.module';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';

registerLocaleData(ne);

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule, BrowserAnimationsModule, AppRoutingModule, IconsProviderModule, NzLayoutModule, NzMenuModule
  ],
  providers: [
    { provide: NZ_I18N, useValue: ne_NP }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
