import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewHoroscopeComponent } from './viewHoroscope.component';

const routes: Routes = [
  { path: '', component: ViewHoroscopeComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ViewHoroscopeRoutingModule { }
