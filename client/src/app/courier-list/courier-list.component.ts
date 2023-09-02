import { Component, Input } from '@angular/core';
import { Courier } from '../_models/courier';

@Component({
  selector: 'app-courier-list',
  templateUrl: './courier-list.component.html',
  styleUrls: ['./courier-list.component.css']
})
export class CourierListComponent {
  @Input() couriers: Courier[] = [];

  
}
