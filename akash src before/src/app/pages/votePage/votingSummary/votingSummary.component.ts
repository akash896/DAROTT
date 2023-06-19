import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'nz-demo-form-horizontal-login',
  templateUrl: './votingSummary.component.html',
  styleUrls: ['./votingSummary.component.css']
})
export class VotingSummaryComponent implements OnInit {

  validateForm!: UntypedFormGroup;

  submitForm(): void {
    console.log('submit', this.validateForm.value);
  }

  votingTitle = 'Who is your Favourite Hero?';

  votingSummarySearchOptions = [
    { label: 'Option1', value: 'Option1'},
    { label: 'Option2', value: 'Option2'},
    { label: 'Option3', value: 'Option3'}
  ];

votingSummaryCardList =[
  {
    url:'',
    votingTitle: 'Shah Rukh Khan',
    voteCount: '23.57K',
    percentage: '50%'
  },
  {
    url:'',
    votingTitle: 'Salman Khan',
    voteCount: '23.57K',
    percentage: '50%'
  }
];



  listOfData = [
    {
      key: '1',
      userID: 'Akash',
      voted: '2.3K',
      dateAndTime: new Date().toLocaleString(),
      like: '1.5M',
      dislike: '2K',
      share: '40K'
    },
    {
      key: '2',
      userID: 'Auro',
      voted: '2.5K',
      dateAndTime: new Date().toLocaleString(),
      like: '1.7M',
      dislike: '1K',
      share: '45K'
    }
  ];

  radioValue = 'A';



  constructor(private fb: UntypedFormBuilder) {}

  ngOnInit(): void {
    this.votingSummaryCardList.push({
      url:'',
      votingTitle: 'Salman Khan',
      voteCount: '23.57K',
      percentage: '50%'
    });
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
