import { getLocaleDateTimeFormat } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { DateLocale } from 'ng-zorro-antd/i18n';
import { NzUploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'nz-demo-form-horizontal-login',
  templateUrl: './viewVoting.component.html',
  styleUrls: ['./viewVoting.component.css']
})
export class ViewVotingComponent implements OnInit {

  validateForm!: UntypedFormGroup;

  submitForm(): void {
    console.log('submit', this.validateForm.value);
  }

  listOfData = [
    {
      key: '1',
      votingTitle: 'Akash',
      amountForVote: 2,
      typeOfOptions: 'Option2',
      dateAndTime: new Date().toLocaleString(),
      like: '1.5M',
      dislike: '2K',
      share: '40K',
      votes: '12M',
      state: 'State 1',
      status: 'Active'
    },
    {
      key: '2',
      votingTitle: 'Auro',
      amountForVote: 3,
      typeOfOptions: 'Option3',
      dateAndTime: new Date().toLocaleString(),
      like: '1.7M',
      dislike: '1K',
      share: '45K',
      votes: '15M',
      state: 'State 3',
      status: 'Active'
    },
  ];

  switchValue = false;

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
}
