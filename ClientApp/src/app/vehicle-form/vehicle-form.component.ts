import { KeyValuePair } from './../models/key-value-pair';
import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  constructor(private vehicleService: VehicleService) { }

  makes: any[];
  models: any[];
  features: KeyValuePair[];
  vehicle: any = {};

  ngOnInit() {
    this.vehicle.makeId = 0;
    
    this.vehicleService.getMakes()
      .subscribe(makes => this.makes = makes);
    this.vehicleService.getFeatures()
      .subscribe(features => this.features = features);
  }

  onMakeChange(){
    var selectedMake = this.makes.find(m =>m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }

}
