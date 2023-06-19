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
import { environment } from './../../environments/environment';

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
    templateUrl: './movies.component.html',
    styleUrls: ['./movies.component.css'],
})
export class MoviesComponent implements OnInit {
    serverPath: string = environment.PATH;
    validateForm: FormGroup = this.fb.group({
        movieTitle: ["", [Validators.required]],
        genreUid: [1, [Validators.required]],
        maturityRating: ["", [Validators.required]],
        releaseYear: [(new Date()).toJSON(), [Validators.required]],
        duration: ['2023-06-10T00:00:00.000', [Validators.required]],
        introStart: ['2023-06-10T00:00:00.000', [Validators.required]],
        introEnd: ['2023-06-10T00:00:00.000', [Validators.required]],
        description: ["", [Validators.required]],
        crews: this.fb.array([  ]),
    });
    fileListPoster: NzUploadFile[] = [  ];
    fileListPreview: NzUploadFile[] = [  ];
    fileListMovie: NzUploadFile[] = [  ];
    testList: ItemData[] = [  ];
    loading = true;
    genreSelect = { isLoading: true, optionList: <any[]>[], api: '', data: <any[]>[] };
    categorySelect = { isLoading: true, optionList: <any[]>[], api: '', data: <any[]>[] };
    constructor(private fb: FormBuilder , private moviesService: MoviesService) { }
    ngOnInit() {
        this.onSearchSelect('', this.genreSelect);
        this.moviesService.getGenres().subscribe( e => {
            if (e.isSuccess) this.genreSelect.data = e.data;
            this.moviesService.getCrewCategories().subscribe( e => {
                if (e.isSuccess) this.categorySelect.data = e.data;
                // console.log( e.data );
            } );
            // console.log( e.data );
        } );
    }
    get crews() {
        return this.validateForm.controls['crews'] as FormArray<FormGroup>;
    }
    copyFormControl(control: any) : any {
        if (control instanceof FormControl) {
            return new FormControl(control.value);
        } else if (control instanceof FormGroup) {
            const copy = new FormGroup({});
            Object.keys(control.controls).forEach(key => {
                copy.addControl(key, this.copyFormControl(control.controls[key]));
            });
            return copy;
        } else if (control instanceof FormArray) {
            var copy = this.fb.array([  ]);
            control.controls.forEach(control => {
                copy.push(this.copyFormControl(control));
            });
            return copy;
        }
        return new FormGroup({});
    }
    addCrew(index: Number, del: Number = 0) {
        const crewForm = this.fb.group({
            categoryUid: [1, Validators.required],
            castingName: ["", Validators.required],
            characterName: ["", Validators.required]
        });
        var t = this.copyFormControl(this.validateForm.controls['crews']);
        var t2 = this.validateForm.controls['crews'] as FormArray<FormGroup>;
        if (index == -1)
            t.push(crewForm);
        else if (del == 0 && index <= t.length) {
            t.insert(index, crewForm);
        } else if (index < t.length) {
            t.removeAt(index);
        }
        // this.validateForm.controls['crews'].setValue( [...t]);
        this.validateForm.controls['crews'] = t;
        // this.crews.push(crewForm);
        // this.crews.markAsDirty();
        // this.crewTable.detectChanges();
        console.log(this.crews.controls);
        this.loading = true;
        // this.testList = [{ name: 'name1', roll: '23', address: 'address1' }] ;

        this.loading = false;
        // console.log( this.testList ) ;
    }
    onSearchSelect(e: any, searchFor: any) {
        if (typeof(e) == 'string') e = e.toLowerCase();
        console.log(e, searchFor);
        searchFor.isLoading = false;
        searchFor.optionList = searchFor.data.filter( ( es : any ) => es.label.toLowerCase().indexOf( e ) >= 0 ).map( ( es : any ) => { return { value : es.uid , label : es.label }; } ) ;
        // searchFor.optionList = [{ label: 'la1', value: 'va1' }];
    }
    getJSONData() {
        var movieData = this.validateForm.getRawValue();
        var fileListPoster = this.fileListPoster.map(e => {
          return { fileUid: e.response.uid };
        });
        var fileListPreview = this.fileListPreview.map(e => {
          return { fileUid: e.response.uid };
        });
        var fileListMovie = this.fileListMovie.map(e => {
          return { fileUid: e.response.uid };
        });
        movieData.moviePosters = fileListPoster;
        movieData.moviePreviews = fileListPreview;
        if (fileListMovie.length > 0)
            movieData.movieFile = fileListMovie[0];
        console.log(movieData);
        this.moviesService.add(movieData).subscribe(e => {
            console.log(e);
        });
    }
    setJSONData() {
        var data = {
            "movieTitle": "sdfds",
            "genreUid": null,
            "maturityRating": null,
            "releaseYear": null,
            "duration": null,
            "introStart": null,
            "introEnd": null,
            "description": "ds",
            "crews": [
                {
                    "title": "dsf",
                    "level": "rew"
                },
                {
                    "title": "hfgf",
                    "level": "hnhgj"
                }
            ]
        };
        for (var i = 0; i < data.crews.length; i++) this.addCrew( -1 ) ;
        console.log( this.validateForm.setValue( data ) ) ;
    }
    addCookie() {
        var data = this.validateForm.getRawValue();
        console.log(this.validateForm.getRawValue());
        var fileListPoster = this.fileListPoster.map(e => e.response.uid);
        var fileListPreview = this.fileListPreview.map(e => e.response.uid)
        console.log(fileListPoster, fileListPreview);
        this.moviesService.add(data).subscribe(e => {
            console.log(e);
        })
    }
}
