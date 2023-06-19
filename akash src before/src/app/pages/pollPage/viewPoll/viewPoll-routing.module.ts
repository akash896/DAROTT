import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewPollComponent } from './viewPoll.component';

const routes: Routes = [
  { path: '', component: ViewPollComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ViewPollRoutingModule { }
