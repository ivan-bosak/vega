import { Vehicle } from './../models/vehicle';
import { element } from 'protractor';
import { SaveVehicle } from './../models/save-vehicle';
import { KeyValuePair } from './../models/key-value-pair';
import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService) {
      route.params.subscribe(p => {
        this.vehicle.id = +p['id'];
      });
     }

  makes: any[];
  models: any[];
  features: KeyValuePair[];
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      phone: '',
      email: ''
    }
  };

  ngOnInit() {
    var sources = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures()
    ];

    if(this.vehicle.id)
      sources.push(this.vehicleService.getVehicle(this.vehicle.id))

    forkJoin(sources).subscribe(data => {
      this.makes = data[0];
      this.features = data[1];

      if(this.vehicle.id){
        this.setVehicle(data[2]);
        this.populateModels();
      }
    },
    err => {
      if(err.status == 404)
       this.router.navigateByUrl('', {replaceUrl: true});
     });
  }
  private setVehicle(v: Vehicle){
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.isRegistered = v.isRegistered;
    this.vehicle.contact = v.contact;
    v.features.forEach(element => {
      this.vehicle.features.push(element.id);
    });
  }

  private populateModels(){
    var selectedMake = this.makes.find(m =>m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }

  onMakeChange(){
    this.populateModels();
    this.vehicle.modelId = 0;
  }

  onFeatureToggle(featureId, $event){
    if($event.target.checked)
      this.vehicle.features.push(featureId);
    else{
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1)
    }
  }

  submit(){
    if(this.vehicle.id)
      this.vehicleService.updateVehicle(this.vehicle)
      .subscribe(x => console.log(x));

    this.vehicleService.create(this.vehicle)
      .subscribe(
        x => console.log(x),
        err => {

        });
  }

  delete(){
    if(confirm("Are you sure?"))
      this.vehicleService.deleteVehicle(this.vehicle.id)
        .subscribe(x => console.log(x));;
  }
}
