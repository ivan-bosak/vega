import { KeyValuePair } from './../models/key-value-pair';
import { Vehicle } from './../models/vehicle';
import { VehicleService } from './../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  private readonly PAGE_SIZE = 3;
  queryResult: any = {};
  makes: KeyValuePair[];
  filter: any = {
    makeId: 0,
    page: 1,
    pageSize: this.PAGE_SIZE
  };

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes()
      .subscribe(makes => this.makes = makes);

    this.populateVehicles();
  }

  private populateVehicles(){
    this.vehicleService.getVehicles(this.filter)
      .subscribe(result => this.queryResult = result);
  }

  onFilterChange(){
    this.filter.page = 1;
    this.populateVehicles();
  }

  resetFilter(){
    this.filter.makeId = 0;
    this.filter.pageSize = this.PAGE_SIZE;
    this.populateVehicles();
  }

  sortBy(columnName){
    if(this.filter.sortBy === columnName){
      this.filter.isSortAscending = !this.filter.isSortAscending;
    } else {
      this.filter.sortBy = columnName;
      this.filter.isSortAscending = true;
    }

    this.populateVehicles();
  }

  onPageChange(page){
    this.filter.page = page;
    this.populateVehicles();
  }

}
