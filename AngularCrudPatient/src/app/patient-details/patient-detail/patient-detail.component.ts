import { Component, OnInit } from '@angular/core';
import { PatientDetailService } from 'src/app/shared/patient-detail.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-patient-detail',
  templateUrl: './patient-detail.component.html',
  styles: []
})
export class PatientDetailComponent implements OnInit {
 
  checked=true;

 
  constructor(private service:PatientDetailService,private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
 
resetForm(form?:NgForm){
  if (form != null)
  form.reset();
  this.service.formData={
    Id:null,
    Nom:'',
    Prenom:'',
    NumTel:null,
    Address:'',
    BirthDay:null,
    IsActive:false

  }
}
keyPress(event: any) {
  const pattern = /[0-9\+\-\ ]/;

  let inputChar = String.fromCharCode(event.charCode);
  if (event.keyCode != 8 && !pattern.test(inputChar)) {
    event.preventDefault();
  }
}
onSubmit(form: NgForm) {
  if (this.service.formData.Id == null){
  this.service.createPatient(form.value) 
    .subscribe(data => {
      this.resetForm(form);
      this.service.refreshList();
      this.toastr.success('New Record Added Succcessfully', 'Patient Register');  
    })
  }else{
    this.service.updatePatient(this.service.formData.Id, form.value)
    .subscribe(data => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Record Updated Successfully!', 'Patient Register');
      }); 
      }

}
    
 
}

