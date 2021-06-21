import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GetOrganizer, GetOrganizerResponse } from '../models/organizer/get-organizer';
import { AddOrganizer } from '../models/organizer/organizer-add';
import { UpdateOrganizer } from '../models/organizer/organizer-update';
import { OrganizerService } from '../services/organizer.service';

@Component({
  selector: 'app-organizer',
  templateUrl: './organizer.component.html',
  styleUrls: ['./organizer.component.css'],
  providers: [OrganizerService]
})
export class OrganizerComponent implements OnInit {

  constructor(private organizerService: OrganizerService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  closeResult = '';
  
  getorganizers:GetOrganizer[];
  getorganizerResponse: GetOrganizerResponse;
  addorganizer: AddOrganizer;
  updateorganizer: UpdateOrganizer;
  organizerAddForm: FormGroup;
  organizerUpdateForm: FormGroup;
  idUpdate:number;
  selectedOrganizer={} as GetOrganizer;
 

  createOrganizerForm() {
    this.organizerAddForm = this.formBuilder.group({
      name: ['', Validators.required],
      birthDate: ['', Validators.required],
      shortBio: ['', Validators.required]
    });
  }
  
  

  ngOnInit() {
    this.organizerService.getOrganizers().subscribe(data => {
      this.getorganizers = data.items;
    });
    this.createOrganizerForm();
    this.updateOrganizerForm();
  }

  

  onDelete(id:number){
    console.log(id)
    this.organizerService.deleteOrganizer(id).subscribe(data=>{
      this.ngOnInit();
      console.log(data);
    });
  }

  addOrganizer() {
    if (this.organizerAddForm.valid) {
      this.addorganizer = Object.assign({}, this.organizerAddForm.value)
      this.organizerService.add(this.addorganizer).subscribe(data=>{
        this.ngOnInit();
        console.log(data);
      });
    }
  }

  updateOrganizer() {
    if (this.organizerUpdateForm.valid) {
      this.updateorganizer = Object.assign({}, this.organizerUpdateForm.value)
      this.organizerService.updateOrganizer(this.idUpdate,this.updateorganizer).subscribe(data=>{
        this.updateOrganizerForm();
        this.ngOnInit();
        console.log(data);
      });
    }  
  }

  

  open(content, id:number) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.idUpdate=id;     
    }, (reason) => { 
      console.log(id);
    });
  }

  updateOrganizerForm() {
    this.organizerUpdateForm = this.formBuilder.group({
      name: [ this.selectedOrganizer.name || '', Validators.required],
      birthDate: [this.selectedOrganizer.birthDate || '' , Validators.required],
      shortBio: [this.selectedOrganizer.shortBio || '', Validators.required]
    });
  }

  openNew(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    }, (reason) => {
      console.log(reason);
    });
  }



}
