import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/welcome' },
  { path: 'welcome', loadChildren: () => import('./pages/welcome/welcome.module').then(m => m.WelcomeModule) },
  { path: 'horoscope', loadChildren: () => import('./pages/horoscopePage/horoscope/horoscope.module').then(m => m.HoroscopeModule) },
  { path: 'viewHoroscope', loadChildren: () => import('./pages/horoscopePage/viewHoroscope/viewHoroscope.module').then(m => m.ViewHoroscopeModule) },

  { path: 'voting', loadChildren: () => import('./pages/votePage/voting/voting.module').then(m => m.VotingModule) },
  { path: 'viewVoting', loadChildren: () => import('./pages/votePage/viewVoting/viewVoting.module').then(m => m.ViewVotingModule) },
  { path: 'votingSummary', loadChildren: () => import('./pages/votePage/votingSummary/votingSummary.module').then(m => m.VotingSummaryModule) },

  { path: 'poll', loadChildren: () => import('./pages/pollPage/poll/poll.module').then(m => m.PollModule) },
  { path: 'viewPoll', loadChildren: () => import('./pages/pollPage/viewPoll/viewPoll.module').then(m => m.ViewPollModule) },
  { path: 'pollSummary', loadChildren: () => import('./pages/pollPage/pollSummary/pollSummary.module').then(m => m.PollSummaryModule) },

  { path: 'event', loadChildren: () => import('./pages/eventPage/event/event.module').then(m => m.EventModule) },
  { path: 'viewEvent', loadChildren: () => import('./pages/eventPage/viewEvent/viewEvent.module').then(m => m.ViewEventModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
