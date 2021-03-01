import { PhotoService } from './services/photo.service';
import { PaginationComponent } from './shared/pagination.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { VehicleService } from './services/vehicle.service';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HttpModule } from '@angular/http';
import { VehicleViewComponent } from './vehicle-view/vehicle-view.component';
import { ImageSliderComponent } from './image-slider/image-slider.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    VehicleFormComponent,
    CounterComponent,
    FetchDataComponent,
    VehicleListComponent,
    PaginationComponent,
    VehicleViewComponent,
    ImageSliderComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'vehicles/new', component: VehicleFormComponent },
      { path: 'vehicles/:id', component: VehicleViewComponent },
      { path: 'vehicles', component: VehicleListComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [
    VehicleService,
    PhotoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
