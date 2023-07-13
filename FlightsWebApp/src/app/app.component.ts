import { Component } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FlightService } from './services/flight.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FlightsWebApp';
  searchForm: FormGroup;
  constructor(private fb: FormBuilder,
    private service: FlightService,    
    private route: ActivatedRoute,
    private router: Router){

  }
  Search(){

  }
}
