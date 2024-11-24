import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { AppSettingService } from './app-setting.service';
import { AppSetting } from './app-setting.model';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-app-setting',
  standalone: true,
  templateUrl: './app-setting.component.html',
  imports:
    [
      CommonModule,
      FormsModule,
      PaginationModule
    ],
})
export class AppSettingComponent implements OnInit {
  appSettings: AppSetting[] = [];
  currentPage: number = 1;
  pageSize: number = 10;
  totalCount: number = 0;
  totalPages: number = 0;

  constructor(private appSettingService: AppSettingService, private cdr: ChangeDetectorRef)
  { }

  ngOnInit() {
    this.loadAppSettings();
  }

  loadAppSettings() {
    this.appSettingService.getAppSettings(this.currentPage, this.pageSize)
      .subscribe(response => {
        this.appSettings = response.items;
        this.totalCount = response.totalCount;
        this.totalPages = Math.ceil(this.totalCount / this.pageSize);
        this.cdr.detectChanges();
      });
  }

  updateAppSetting(appSetting: AppSetting) {
    this.appSettingService.updateAppSetting(appSetting)
      .subscribe(() => {
        // Handle success, e.g., show a success message
        console.log('App setting updated successfully.');
        this.loadAppSettings();
      }, error => {
        // Handle error, e.g., show an error message
        console.error('Error updating app setting:', error);
      });
  }

  onPageChange(event: any): void {
    this.currentPage = event.page; // Update the current page
    this.loadAppSettings(); // Reload app settings for the new page
  }

  //onPageChange(pageNumber: number) {
  //  this.currentPage = pageNumber;
  //  this.loadAppSettings();
  //}
}
