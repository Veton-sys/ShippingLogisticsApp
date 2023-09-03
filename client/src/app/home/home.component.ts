import { Component, OnInit, Self } from '@angular/core';
import { CourierService } from '../_services/courier.service';
import { Parcel } from '../_models/parcel';
import { ControlValueAccessor, FormBuilder, FormControl, FormGroup, NgControl, Validators } from '@angular/forms';
import { Courier } from '../_models/courier';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  couriers: Courier[] = [];
  parcelForm: FormGroup = new FormGroup({});
  validationErrors: string[] | undefined;

  constructor(private courierService: CourierService, private fb: FormBuilder) {
  }


  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.parcelForm = this.fb.group({
      weight: ['', [Validators.required, Validators.min(1),Validators.max(30)]],
      width: ['', [Validators.required, Validators.min(1)]],
      height: ['', [Validators.required, Validators.min(1)]],
      depth: ['', [Validators.required, Validators.min(1)]],
    });
  }

  getCourierPrices() {
    return this.courierService.getCourierPrices(this.parcelForm.value).subscribe({
      next: response => this.couriers = response.data,
      error: error => this.validationErrors = error
    })
  }

}

