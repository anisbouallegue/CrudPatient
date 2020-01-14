import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { PatientDetailComponent } from './patient-details/patient-detail/patient-detail.component';
import { PatientDetailListComponent } from './patient-details/patient-detail-list/patient-detail-list.component';
import { PatientDetailService } from './shared/patient-detail.service';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {DatePipe} from '@angular/common';
@NgModule({
  declarations: [
    AppComponent,
    PatientDetailsComponent,
    PatientDetailComponent,
    PatientDetailListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule, 
    ToastrModule.forRoot()
    
  ],
  providers: [PatientDetailService,DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
