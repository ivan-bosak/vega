import { PhotoService } from './../services/photo.service';
import { Contact } from './../models/contact';
import { KeyValuePair } from './../models/key-value-pair';
import { Vehicle } from './../models/vehicle';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs';

@Component({
  selector: 'app-vehicle-view',
  templateUrl: './vehicle-view.component.html',
  styleUrls: ['./vehicle-view.component.css']
})
export class VehicleViewComponent implements OnInit {

  tabId: any = 'vehicle';
  @ViewChild('fileInput') fileInput: ElementRef;
  vehicleId: number; 
  vehicle: Vehicle = {
    id: 0,
    make:  { id: 0, name: ''},
    model:  { id: 0, name: ''},
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      phone: '',
      email: ''
    },
    lastUpdated: ''
  };
  photos: any[];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    private photoService: PhotoService) {

      route.params.subscribe(p => {
        this.vehicleId= +p['id'];
      if(isNaN(this.vehicleId) || this.vehicleId <= 0){
        router.navigate(['/vehicles']);
        return;
      }
      });
     }

  ngOnInit() {
    this.photoService.getPhotos(this.vehicleId)
      .subscribe(photos => this.photos = photos);

    this.vehicleService.getVehicle(this.vehicleId)
      .subscribe(vehicle => this.vehicle = vehicle);
  }

  uploadPhoto(){
    var nativeElment: HTMLInputElement =  this.fileInput.nativeElement;

    this.photoService.upload(this.vehicleId, nativeElment.files[0])
    .subscribe(photo => {
      this.photos.push(photo);
    });
  }
}
