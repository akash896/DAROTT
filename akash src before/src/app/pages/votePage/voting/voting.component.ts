import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { NzUploadFile } from 'ng-zorro-antd/upload';
import { VoteService } from '../../../services/vote/vote.service';

@Component({
  selector: 'nz-demo-form-horizontal-login',
  templateUrl: './voting.component.html',
  styleUrls: ['./voting.component.css']
})
export class VotingComponent implements OnInit {

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
  votingTypeOfOptions = [
    { label: 'Option1', value: '1'},
    { label: 'Option2', value: '2'},
    { label: 'Option3', value: '3'}
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
  pageno = 1;
  limit = 10;



  constructor(private fb: UntypedFormBuilder,
    private voteService: VoteService) {}

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      // userName: [null, [Validators.email, Validators.required]],
      // password: [null, [Validators.required]],
      votingTypeOfOptions :["1",[Validators.required]],
      votingTitle:['voting title',[Validators.required]],
      amountForVote:['2',[Validators.required]],
      votingPhotoTitle:['title',[Validators.required]],
      description:['',[]],
    });
  }

  // saveData(): void{  // save a vote
  //   var data = this.validateForm.getRawValue();
  //   console.log(data);
  //   this.voteService.addVote(data).subscribe(res=>{
  //     console.log(res);
  //     this.getAllVotes();
  //     this.getVoteById();
  //   });
  // }

  saveData(): void{  // save a vote
    this.deleteVoteById();
  }

  updateData(): void{   // update a vote
    // var data = this.validateForm.getRawValue();
    var data = {
      "uid": 1,
      "votingTitle": "sdf",
      "amountForVote": 100,
      "votingTypeOfOptions": 3,
      "votingPhotoTitle": "Shah Rukh Khan",
      "status": false,
      "votingState": 1,
      "description": "updated vote"
    }
    this.voteService.updateVote(data).subscribe(res=>{
      console.log(res);
      this.getAllVotes();
      console.log('current data = \n' , res);
    });
  }

  getAllVotes(): void{  // get all votes
    var data = {
      pageno: this.pageno,
      limit: this.limit
    }
    this.voteService.getAllVotes(data).subscribe(res=>{
      console.log('current data = \n' , res);
    });
  }

  getVoteById(): void{  // get all votes
    var data = {
      id: 1
    }
    this.voteService.getVoteById(data).subscribe(res=>{
      console.log('current data = \n' , res);
    });
  }

  giveVote(): void{   // give a vote
    var data = {
      "userId": 1,
      "userName": "userName123",
      "voteId": 1,
      "votedName": "srk",
      "dateTime": "2023-05-06T00:00:00"
    }
    this.voteService.giveVote(data).subscribe(res=>{
      console.log(res);
    });
  }

  addLike(): void{  // get all votes
    var data = {
      voteId: 2
    }
    this.voteService.addLike(data).subscribe(res=>{
      console.log('current data = \n' , res);
    });
  }
  addDislike(): void{  // get all votes
    var data = {
      voteId: 2
    }
    this.voteService.addDislike(data).subscribe(res=>{
      console.log('current data = \n' , res);
    });
  }

  addShare(): void{  // get all votes
    var data = {
      voteId: 2
    }
    this.voteService.addShare(data).subscribe(res=>{
      console.log('current data = \n' , res);
    });
  }

  getAllLikesOnVotes(): void{  // get all votes
    var data = {
      pageno: this.pageno,
      limit: this.limit
    }
    this.voteService.getAllLikesOnVotes(data).subscribe(res=>{
      console.log('current data = \n' , res);
    });
  }

  getAllDislikesOnVotes(): void{  // get all votes
    var data = {
      pageno: this.pageno,
      limit: this.limit
    }
    this.voteService.getAllDislikesOnVotes(data).subscribe(res=>{
      console.log('current data = \n' , res);
    });
  }

  getAllShareOnVotes(): void{  // get all votes
    var data = {
      pageno: this.pageno,
      limit: this.limit
    }
    this.voteService.getAllShareOnVotes(data).subscribe(res=>{
      console.log('current data = \n' , res);
    });
  }

  deleteVoteById(): void{  // get all votes
    var data = {
      id: 16
    }
    this.voteService.deleteVoteById(data).subscribe(res=>{
      console.log('current data = \n' , res);
    });
  }

}


