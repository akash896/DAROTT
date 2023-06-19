import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VotingSummaryComponent } from './votingSummary.component';

const routes: Routes = [
  { path: '', component: VotingSummaryComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VotingSummaryRoutingModule { }
