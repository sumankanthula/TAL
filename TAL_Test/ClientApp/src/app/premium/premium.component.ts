import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PremiumService } from './premium.service';

@Component({
  selector: 'premium',
  templateUrl: './premium.component.html'
})
export class PremiumComponent {
  public isSetupDone: boolean;
  public setupProgressText: string;
  public premiumData: any = {};
  public errorMessages: any[] = [];
  monthlyPremium: number;
  premiumFormData: FormGroup;

  fieldValidation: any[] = [
    {
      controlName: 'name',
      errorMessge: 'Name is required'
    },
    {
      controlName: 'age',
      errorMessge: 'Age is required'
    },
    {
      controlName: 'dob',
      errorMessge: 'Date of Birth is required'
    },
    {
      controlName: 'occupation',
      errorMessge: 'Occupation is required'
    },
    {
      controlName: 'deathSumInsured',
      errorMessge: 'Death Sum Insured is required'
    },

  ];

  constructor(private fb: FormBuilder, public premiumService: PremiumService) {
  }

  ngOnInit() {

    this.premiumFormData = this.fb.group({
      name: ['', Validators.required],
      age: ['', Validators.required],
      dob: ['', Validators.required],
      occupation: ['', Validators.required],
      deathSumInsured: ['', Validators.required],
    });


    this.setupProgressText = 'Please wait, The initial setup is in-progress!!'
    this.prepareInitialSetup();
  }

  public onPremiumCalculate(isPremiumCalcChanges = false) {
    this.errorMessages = [];
    this.monthlyPremium = 0;
    if (this.premiumFormData.status === 'INVALID') {
      this.fieldValidation.forEach(ele => {
        if (this.premiumFormData.get(ele.controlName).invalid && !isPremiumCalcChanges) {
          this.errorMessages.push(ele.errorMessge);
        }
      });
      return;
    }

    let occupationRating = this.premiumData.occupationRatings.find(x => x.occupationId === this.premiumFormData.get('occupation').value);
    let rating = this.premiumData.ratings.find(x => x.id === occupationRating.ratingId);
    // Death Premium = (Death Cover amount * Occupation Rating Factor * Age) /1000 * 12
    this.monthlyPremium = (this.premiumFormData.get('deathSumInsured').value * rating.rate * this.premiumFormData.get('age').value) / 1000 * 12;
  }

  public onOccupationChange(val) {
    if (!val) return;
    this.onPremiumCalculate(true);
  }

  public getPremiumData() {
    this.premiumService.getPremiumData().subscribe((resp: any) => {
      this.premiumData = resp;
    }, (error: any) => {
      console.log(error);
    });
  }

  public prepareInitialSetup() {
    this.premiumService.initialSetup().subscribe((resp: any) => {
      this.isSetupDone = resp.msg === 'Setup_Done';
      this.setupProgressText = '';
      this.getPremiumData();
    }, (error: any) => {
      console.log(error);
      this.setupProgressText = 'There was a error while Database initial setup, please check the console';
      this.isSetupDone = false;
    });
  }

}
