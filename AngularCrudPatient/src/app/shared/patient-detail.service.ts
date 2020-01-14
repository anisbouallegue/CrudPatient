import { Injectable } from '@angular/core';
import { Patient } from './patient-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PatientDetailService {
  formData: Patient;
  readonly rootURL = 'http://localhost:57035/api';
  list : Patient[];
  constructor(private http:HttpClient) { }
  
  createPatient(patient) {
    return this.http.post(this.rootURL + '/patients', patient);
  }
  updatePatient(id, patient) {
    return this.http.put(this.rootURL + '/patients/'+ id, patient);
  }
  delPatient(id) {
    return this.http.delete(this.rootURL + '/patients/'+ id);
  }

  refreshList(){
    this.http.get(this.rootURL + '/patients')
    .toPromise()
    .then(res => this.list = res as Patient[]);
  }
}
