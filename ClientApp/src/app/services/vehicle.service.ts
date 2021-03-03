import { SaveVehicle } from './../models/save-vehicle';
import { Vehicle } from './../models/vehicle';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  private readonly vehiclesEndpoint = '/api/vehicles';
  constructor(private http: HttpClient) { }

  getMakes(){
    return this.http.get('/api/makes')
      .pipe(map(res => <any[]>res));
  }

  getFeatures(){
    return this.http.get('/api/features')
      .pipe(map(res => <any[]>res));
  }

  create(vehicle){
    return this.http.post('/api/vehicles', vehicle)
      .pipe(map(res => <any>res));
  }

  getVehicle(id){
    return this.http.get('/api/vehicles/' + id)
      .pipe(map(res => <any>res));
  }

  updateVehicle(vehicle: SaveVehicle){
    return this.http.put('/api/vehicles/' + vehicle.id, vehicle)
      .pipe(map(res => <any>res));
  }

  deleteVehicle(id){
    return this.http.delete('/api/vehicles/' + id)
      .pipe(map(res => <any>res));
  }

  getVehicles(filter){
    return this.http.get(this.vehiclesEndpoint + '?' + this.toQueryString(filter))
      .pipe(map(res => <any[]>res));
  }

  toQueryString(obj){
    var parts = [];

    for(var property in  obj){
      var value = obj[property];
      if(value != null && value != undefined && value != 0)
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }

    return parts.join('&');
  }
}
