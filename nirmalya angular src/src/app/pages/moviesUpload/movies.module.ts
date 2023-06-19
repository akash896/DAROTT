import { NgModule } from '@angular/core';

import { MoviesRoutingModule } from './movies-routing.module';

import { MoviesComponent } from './movies.component';
// import { NzButtonModule } from 'ng-zorro-antd/button';
// import { NzInputModule } from 'ng-zorro-antd/input';
// import { NzFormModule  } from 'ng-zorro-antd/form';
// import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { modules } from '../../commonHelper'


@NgModule({
  // imports: [MoviesRoutingModule, NzButtonModule, NzFormModule, FormsModule, ReactiveFormsModule, NzInputModule ],
  imports: [MoviesRoutingModule, ...modules],
  declarations: [MoviesComponent],
  exports: [MoviesComponent]
})
export class MoviesModule { }
