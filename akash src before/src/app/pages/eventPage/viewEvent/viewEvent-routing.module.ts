import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewEventComponent } from './viewEvent.component';

const routes: Routes = [
  { path: '', component: ViewEventComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ViewEventRoutingModule { }
