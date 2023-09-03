import { Component, Input } from '@angular/core';
import { Courier } from '../_models/courier';
import { CourierService } from '../_services/courier.service';
import { Parcel } from '../_models/parcel';
import { Order } from '../_models/order';
import { ToastrService } from 'ngx-toastr';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-courier-list',
  templateUrl: './courier-list.component.html',
  styleUrls: ['./courier-list.component.css']
})
export class CourierListComponent {

  @Input() couriers: Courier[] = [];
  @Input() parcel: Parcel | undefined;
  @Output() orderPlaced = new EventEmitter<string>();

  baseUrl = 'https://localhost:5001/api/';

  constructor(private courierService: CourierService, private toastr: ToastrService) { }


  makeOrder(courier: Courier, parcel: Parcel) {

    let order: Order = {
      packageDto: parcel,
      courierName: courier.name,
      courierPrice: courier.price,
      orderDate: new Date()
    }

    this.courierService.makeOrder(order).subscribe({
      next: response => {
        this.toastr.success(response.message);
        this.orderPlaced.emit();
        this.clearCouriers();
      },
      error: error => this.toastr.error(error.error.message),
    });

  }

  clearCouriers(){
    this.couriers = [];
  }

}
