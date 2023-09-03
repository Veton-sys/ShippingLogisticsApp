import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Parcel } from '../_models/parcel';
import { Observable, map } from 'rxjs';
import { Courier } from '../_models/courier';
import { Order } from '../_models/order';
import { ServiceResponse } from '../_models/serviceResponse';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class CourierService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient, private toastr: ToastrService) { }

  getCourierPrices(parcel: Parcel){
    let params = new HttpParams();
    params = params.append("weight", parcel.weight)
    params = params.append("height", parcel.height)
    params = params.append("width", parcel.width)
    params = params.append("depth", parcel.depth)
    
    return this.http.get<ServiceResponse<Courier[]>>(this.baseUrl + 'shipping', { params: params });
  }

  makeOrder(order: Order): Observable<ServiceResponse<boolean>>{
    return this.http.post<ServiceResponse<boolean>>(this.baseUrl + 'shipping', order);
  }
}
