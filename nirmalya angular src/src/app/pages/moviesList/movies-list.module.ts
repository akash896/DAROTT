import { NgModule } from '@angular/core';

import { MoviesListRoutingModule } from './movies-list-routing.module';

import { MoviesListComponent } from './movies-list.component';
// import { NzButtonModule } from 'ng-zorro-antd/button';
// import { NzInputModule } from 'ng-zorro-antd/input';
// import { NzFormModule  } from 'ng-zorro-antd/form';
// import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { modules } from '../../commonHelper'


@NgModule({
  // imports: [MoviesRoutingModule, NzButtonModule, NzFormModule, FormsModule, ReactiveFormsModule, NzInputModule ],
  imports: [MoviesListRoutingModule, ...modules],
  declarations: [MoviesListComponent],
  exports: [MoviesListComponent]
})
export class MoviesListModule { }
