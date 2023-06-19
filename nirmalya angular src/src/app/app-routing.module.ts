import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from './services/auth/auth-guard.service';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/movies-upload' },
  { path: 'login', loadChildren: () => import('./pages/login/login.module').then(m => m.LoginModule) },
  { path: 'movies-upload', canActivate: [AuthGuardService], loadChildren: () => import('./pages/moviesUpload/movies.module').then(m => m.MoviesModule) },
  { path: 'movies', canActivate: [AuthGuardService], loadChildren: () => import('./pages/moviesList/movies-list.module').then(m => m.MoviesListModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
