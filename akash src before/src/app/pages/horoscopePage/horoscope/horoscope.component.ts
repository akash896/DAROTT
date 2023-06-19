import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { NzUploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'nz-demo-form-horizontal-login',
  templateUrl: './horoscope.component.html',
  styleUrls: ['./horoscope.component.css']
})
export class HoroscopeComponent implements OnInit {

  validateForm!: UntypedFormGroup;

  submitForm(): void {
    console.log('submit', this.validateForm.value);
  }
  selectedValue = 'lucy';
  listOfSelectedValue = [];
  listOfOption = [
    { label: 'Jack', value: 'jack' },
    { label: 'Lucy', value: 'lucy' },
    { label: 'disabled', value: 'disabled', disabled: true }
  ];
  zodiacList = [
    { label: 'Leo', value: 'Leo'},
    { label: 'Virgo', value: 'Virgo'},
    { label: 'Sagittarius', value: 'Sagittarius'},
    { label: 'Libra', value: 'Libra'},
    { label: 'Cancer', value: 'Cancer'},
    { label: 'Pisces', value: 'Pisces'},
    { label: 'Taurus', value: 'Taurus'}
  ];
  periodTypeList = [
    { label: 'Daily', value: 'Daily'},
    { label: 'Weekly', value: 'Weekly'},
    { label: 'Monthly', value: 'Monthly'},
    { label: 'Quaterly', value: 'Quaterly'},
    { label: 'Yearly', value: 'Yearly'}
  ];

  defaultFileList: NzUploadFile[] = [
    {
      uid: '-1',
      name: 'xxx.png',
      status: 'done',
      url: 'https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png',
      thumbUrl: 'https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png'
    },
    {
      uid: '-2',
      name: 'yyy.png',
      status: 'error'
    }
  ];

  fileList1 = [...this.defaultFileList];
  fileList2 = [...this.defaultFileList];

  horoscopeDescription = '';





  constructor(private fb: UntypedFormBuilder) {}

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      // userName: [null, [Validators.email, Validators.required]],
      // password: [null, [Validators.required]],
      zodiacList :['Leo',[Validators.required]],
      periodTypeList :["Daily",[Validators.required]],
      onDate:["12/2/21",[Validators.required]],
      uploadImage:[null,[Validators.required]],
      //remember: [true]
    });
  }



}
