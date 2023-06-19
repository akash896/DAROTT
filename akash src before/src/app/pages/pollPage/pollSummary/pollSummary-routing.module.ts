import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PollSummaryComponent } from './pollSummary.component';

const routes: Routes = [
  { path: '', component: PollSummaryComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PollSummaryRoutingModule { }
