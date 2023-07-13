import { Injectable } from '@angular/core';
import { FlightRequest } from '../classes/flight-request';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightService {

  constructor(private _httpClient: HttpClient) { }
  Search(origin:string, destination:string):Observable<any>{
    let request:FlightRequest = {
      origin : origin,
      destination: destination
    };
    return this._httpClient.post(environment.SERVICE_URL + 'Flights/GetFlights',request);
  }
}
