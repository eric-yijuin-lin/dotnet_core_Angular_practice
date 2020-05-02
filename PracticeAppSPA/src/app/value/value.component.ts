import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  private http: HttpClient;
  public values: any;

  constructor(http: HttpClient) {
    this.http = http;
  }

  ngOnInit() {
    this.getValues();
  }

  getValues() {
    this.http.get('http://localhost:5000/api/Values').subscribe(
      response => {
        this.values = response;
      },
      error => {
        console.log(error);
      });
  }

}
