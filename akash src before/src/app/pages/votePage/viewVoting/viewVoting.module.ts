import { NgModule } from '@angular/core';
import { ViewVotingRoutingModule } from './viewVoting-routing.module';

import { ViewVotingComponent } from './viewVoting.component';
// import { NzButtonModule } from 'ng-zorro-antd/button';
// import { NzFormModule } from 'ng-zorro-antd/form';
// import { NzInputModule } from 'ng-zorro-antd/input';
// import { NzSelectModule } from 'ng-zorro-antd/select';
// import { NzCardModule } from 'ng-zorro-antd/card';
// import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { modules } from '../../../commonHelper'


import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@NgModule({
  // imports: [HoroscopeRoutingModule, NzDatePickerModule,NzButtonModule,NzFormModule,ReactiveFormsModule,FormsModule,NzInputModule,NzSelectModule,NzCardModule,CommonModule],
  imports: [ViewVotingRoutingModule, ...modules],
  declarations: [ViewVotingComponent],
  exports: [ViewVotingComponent]
})
export class ViewVotingModule { }
