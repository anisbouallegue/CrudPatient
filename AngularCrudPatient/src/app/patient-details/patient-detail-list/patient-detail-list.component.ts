import { Component, OnInit } from '@angular/core';
import { PatientDetailService } from 'src/app/shared/patient-detail.service';
import { ToastrService } from 'ngx-toastr';
import { Patient } from 'src/app/shared/patient-detail.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-patient-detail-list',
  templateUrl: './patient-detail-list.component.html',
  styles: []
})
export class PatientDetailListComponent implements OnInit {

  constructor(private service: PatientDetailService,
    private toastr: ToastrService,public datepipe: DatePipe) { }

  ngOnInit() {
    this.service.refreshList();
  }
  populateForm(pd: Patient) {
    this.service.formData = Object.assign({}, pd);
   

  }

  onDelete(Id) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.delPatient(Id)
        .subscribe(res => {
          debugger;
          this.service.refreshList();
          this.toastr.warning('Deleted successfully', 'Patient Register');
        },
          err => {
            debugger;
            console.log(err);
          })
    }
  }

}
