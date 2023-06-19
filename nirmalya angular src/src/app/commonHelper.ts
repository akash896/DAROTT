import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzFormModule  } from 'ng-zorro-antd/form';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzTimePickerModule } from 'ng-zorro-antd/time-picker';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzUploadModule } from 'ng-zorro-antd/upload';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { IconsProviderModule } from './icons-provider.module';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { CommonModule } from '@angular/common';

export let modules = [
  NzButtonModule,
  NzInputModule,
  NzFormModule,
  FormsModule,
  NzSelectModule,
  NzCardModule,
  NzDatePickerModule,
  NzTimePickerModule,
  NzTableModule,
  NzUploadModule,
  NzLayoutModule,
  IconsProviderModule,
  ReactiveFormsModule,
  // BrowserAnimationsModule,
  NzMenuModule,
  NzMessageModule,
  CommonModule
]
