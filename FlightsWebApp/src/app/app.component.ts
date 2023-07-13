import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FlightService } from './services/flight.service';
import { Journey } from './classes/journey';
import Swal from 'sweetalert2';
import { Utils } from 'src/shared/utils';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FlightsWebApp';
  searchForm: FormGroup;
  journey: Journey;
  isValid:boolean = false;
  currencyFactor:number = 1;
  selectedCurrency:string='USD';

  constructor(private fb: FormBuilder,
    private service: FlightService,    
    private route: ActivatedRoute,
    private router: Router){
    this.searchForm = this.fb.group({      
      origin:['', Validators.required],
      destination:['', Validators.required],      
    });
  }
  ngOnInit(){

  }
  Search(){
    this.isValid = false;
    const valForm = this.searchForm.value;    
    this.service.Search(valForm.origin,valForm.destination).subscribe((res:any) =>{
      this.journey = res.journey;
      if(this.journey.flights == null){
        Swal.fire({
          text: 'No results found',
          icon: 'error',
          timer:2000,
          confirmButtonColor: '#a01533',
          confirmButtonText: 'Aceptar'
        });         
      }
      else{
        this.isValid = true;
      }
    },
    error =>{
      Swal.fire({
        title: '¡Error!',
        text: 'Error searching results. Please try again later',
        icon: 'error',
        timer:2000,
        confirmButtonColor: '#a01533',
        confirmButtonText: 'Aceptar'
      });
    }
    );    
  }

  Clear(){
    this.isValid = false;
    this.searchForm.setValue({      
      origin:'',
      destination:'',      
    });
  }

  onCurrencyChange(e:any){
    this.currencyFactor = Utils.SetCurrencyFactor(e.value);
    this.selectedCurrency = e.value;
  }
}
