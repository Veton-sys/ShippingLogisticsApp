import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Parcel } from '../_models/parcel';
import { map } from 'rxjs';
import { Courier } from '../_models/courier';

@Injectable({
  providedIn: 'root'
})
export class CourierService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getCourierPrices(parcel: Parcel){
    return this.http.post<Courier[]>(this.baseUrl + 'shipping', parcel);
  }

  
}
