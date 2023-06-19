import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewVotingComponent } from './viewVoting.component';

const routes: Routes = [
  { path: '', component: ViewVotingComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ViewVotingRoutingModule { }
