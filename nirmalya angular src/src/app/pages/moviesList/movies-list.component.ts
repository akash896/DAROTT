import { Component, OnInit, ViewChild } from '@angular/core';
import {
    FormBuilder,
    FormGroup,
    FormArray,
    FormControl,
    FormControlName,
    UntypedFormBuilder,
    UntypedFormGroup,
    Validators,
    UntypedFormArray,
    AbstractControl,
} from '@angular/forms';
import { environment } from '../../environments/environment';

import { NzUploadFile } from 'ng-zorro-antd/upload';

import { NzTableLayout } from 'ng-zorro-antd/table';
import { MoviesService } from '../../services/movies/movies.service';

interface ItemData {
    name: string;
    roll: number | string;
    address: string;
  }

@Component({
    selector: 'app-movies',
    templateUrl: './movies-list.component.html',
    styleUrls: ['./movies-list.component.css'],
})
export class MoviesListComponent implements OnInit {
    serverPath: string = environment.PATH;
    fileListPoster: NzUploadFile[] = [  ];
    fileListPreview: NzUploadFile[] = [  ];
    fileListMovie: NzUploadFile[] = [  ];
    testList: ItemData[] = [  ];
    loading = true;
    genreSelect = { isLoading: true, optionList: <any[]>[], api: '', data: <any[]>[] };
    categorySelect = { isLoading: true, optionList: <any[]>[], api: '', data: <any[]>[] };
    constructor() { }
    ngOnInit() {
        // this.onSearchSelect('', this.genreSelect);
        // this.moviesService.getGenres().subscribe( e => {
        //     if (e.isSuccess) this.genreSelect.data = e.data;
        //     this.moviesService.getCrewCategories().subscribe( e => {
        //         if (e.isSuccess) this.categorySelect.data = e.data;
        //         // console.log( e.data );
        //     } );
        //     // console.log( e.data );
        // } );
    }
    onSearchSelect(e: any, searchFor: any) {
        if (typeof(e) == 'string') e = e.toLowerCase();
        console.log(e, searchFor);
        searchFor.isLoading = false;
        searchFor.optionList = searchFor.data.filter( ( es : any ) => es.label.toLowerCase().indexOf( e ) >= 0 ).map( ( es : any ) => { return { value : es.uid , label : es.label }; } ) ;
        // searchFor.optionList = [{ label: 'la1', value: 'va1' }];
    }
}
