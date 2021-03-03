import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PhotoService {
    constructor(private http: HttpClient) {}

    upload(vehicleId, file){
        var formData = new FormData();
        formData.append('file', file);
        return this.http.post(`/api/vehicles/${vehicleId}/photos`, formData)
            .pipe(map(res => <any[]>res));
    }

    getPhotos(vehicleId){
        return this.http.get(`/api/vehicles/${vehicleId}/photos`)
            .pipe(map(res => <any[]>res));
    }
}