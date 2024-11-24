import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppSettingComponent } from './components/app-setting/app-setting.component';

const routes: Routes = [
  { path: '', redirectTo: '/settings', pathMatch: 'full' }, // Redirect to Settings by default
  { path: 'settings', component: AppSettingComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
