import { getLocaleDateTimeFormat } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { DateLocale } from 'ng-zorro-antd/i18n';
import { NzUploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'nz-demo-form-horizontal-login',
  templateUrl: './viewHoroscope.component.html',
  styleUrls: ['./viewHoroscope.component.css']
})
export class ViewHoroscopeComponent implements OnInit {

  validateForm!: UntypedFormGroup;

  submitForm(): void {
    console.log('submit', this.validateForm.value);
  }

  listOfData = [
    {
      key: '1',
      zodiac: 'Akash',
      periodType: 2,
      dateAndTime: new Date().toLocaleString(),
      description: '1.5M',
      share: '40K',
      status: 'Active'
    },
    {
      key: '2',
      zodiac: 'Akash',
      periodType: 2,
      dateAndTime: new Date().toLocaleString(),
      description: '1.5M',
      share: '40K',
      status: 'Active'
    },
  ];

  switchValue = false;
  radioValue = 'A';
  searchValue = '';
  constructor(private fb: UntypedFormBuilder) {}


  ngOnInit(): void {
    this.validateForm = this.fb.group({
      // userName: [null, [Validators.email, Validators.required]],
      // password: [null, [Validators.required]],
      // votingTypeOfOptions :["Option1",[Validators.required]],
      // uploadImage:["null",[Validators.required]],
      // votingTitle:['voting title',[Validators.required]],
      // amountForVote:['2',[Validators.required]],
      // votingPhotoTitle:['title',[Validators.required]],
    });
  }

  searchByName(): void{

  }
  resetByName(): void{

  }



}
