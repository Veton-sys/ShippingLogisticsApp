import { Component, OnInit } from '@angular/core';
import { CourierService } from '../_services/courier.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Courier } from '../_models/courier';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  selectedValue = 1;
  couriers: Courier[] = [];
  parcelForm: FormGroup = new FormGroup({});
  validationErrors: string[] | undefined;
  
  constructor(private courierService: CourierService, private fb: FormBuilder) {
  }


  ngOnInit(): void {
    this.initializeForm();
    this.detectFormChange();
  }

  initializeForm() {
    this.parcelForm = this.fb.group({
      weight: [1, [Validators.required, Validators.min(1), Validators.max(30)]],
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

  detectFormChange() {
    this.parcelForm.valueChanges.subscribe(res => {
      console.log(res);
      this.getCourierPrices();
    })
  }
}

