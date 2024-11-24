import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import {
  AppSetting
} from './app-setting.model';

@Injectable({
  providedIn: 'root'
})
export class AppSettingService {
  private apiUrl = 'https://localhost:5001/api/appsettings'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  getAppSettings(pageNumber: number, pageSize: number): Observable<any> {
  return this.http.get<any>(`${this.apiUrl}?pageNumber=${pageNumber}&pageSize=${pageSize}`).pipe(
    catchError(error => {
      console.error('Error fetching app settings:', error);
      return throwError(() => new Error('Unable to load settings'));
    })
  );
}

  updateAppSetting(appSetting: AppSetting): Observable<any> {
    return this.http.put(`${this.apiUrl}/${appSetting.id}`, appSetting);
  }
}
