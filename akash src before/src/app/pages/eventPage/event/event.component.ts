import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { NzUploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'nz-demo-form-horizontal-login',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {

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
  eventTypeList = [
    { label: 'Type 1', value: 'Type 1'},
    { label: 'Type 2', value: 'Type 2'},
    { label: 'Type 3', value: 'Type 3'}
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
      eventTypeList :['Type 1',[Validators.required]],
      eventTitle :["eventTitle",[Validators.required]],
      onDate:["12/2/21",[Validators.required]],
      uploadImage:[null,[Validators.required]],
      //remember: [true]
    });
  }



}
