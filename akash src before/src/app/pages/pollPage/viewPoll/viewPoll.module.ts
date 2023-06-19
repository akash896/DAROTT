import { NgModule } from '@angular/core';
import { ViewPollRoutingModule } from './viewPoll-routing.module';

import { ViewPollComponent } from './viewPoll.component';
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
  imports: [ViewPollRoutingModule, ...modules],
  declarations: [ViewPollComponent],
  exports: [ViewPollComponent]
})
export class ViewPollModule { }
