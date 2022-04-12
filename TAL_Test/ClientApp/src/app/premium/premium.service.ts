import { Component, Inject, Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PremiumService {

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
  //  }, error => console.error(error));
  //}
  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }

  public initialSetup() {
    return this.http.get(`${this.baseUrl, 'Premium/InitialSetup'}`);
  }

  public getPremiumData() {
    return this.http.get(`${this.baseUrl, 'Premium/GetPremiumData'}`);
  }



}

