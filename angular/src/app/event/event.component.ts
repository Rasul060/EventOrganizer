import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/event.service';
import { AddEvent } from "../models/event/event-add";
import { UpdateEvent } from "../models/event/event-update";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrganizerService } from '../services/organizer.service';
import { GetOrganizer, GetOrganizerResponse } from '../models/organizer/get-organizer';
import { AddOrganizer } from '../models/organizer/organizer-add';
import { UpdateOrganizer } from '../models/organizer/organizer-update';
import { GetEvent, GetEventResponse } from '../models/event/get-event';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EventFilterPipe } from './event-filter.pipe';


@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css'],
  providers: [EventService,EventFilterPipe]
})
export class EventComponent implements OnInit {

  constructor(private eventService: EventService
    , private formBuilder: FormBuilder
    , private organizerService: OrganizerService
    , private modalService: NgbModal
    , private eventFilter: EventFilterPipe) { }

  closeResult = '';
  filterText='';

  getevents: GetEvent[];
  addevent: AddEvent;
  updateevent: UpdateEvent;
  getOrganizers: GetOrganizer[];
  eventAddForm: FormGroup;
  eventUpdateForm: FormGroup;
  idUpdate: number;

  createEventForm() {
    this.eventAddForm = this.formBuilder.group({
      name: ["", Validators.required],
      type: ["", Validators.required],
      date: ["", Validators.required],
      startTime: ["", Validators.required],
      endTime: ["", Validators.required],
      location: ["", Validators.required],
      organizerId: ["", Validators.required]
    });
  }

  updateEventForm() {
    this.eventUpdateForm = this.formBuilder.group({
      startTime: ["", Validators.required],
      endTime: ["", Validators.required],
      location: ["", Validators.required]
    });
  }


  ngOnInit() {
    this.eventService.getEvents().subscribe(data => {
      this.getevents = data.items;
    });
    this.organizerService.getOrganizers().subscribe(data => {
      this.getOrganizers = data.items
    });
    this.createEventForm();
    this.updateEventForm();
  }

  addEvent() {
    if (this.eventAddForm.valid) {
      this.addevent = Object.assign({}, this.eventAddForm.value)
      this.eventService.add(this.addevent).subscribe(data => {
        this.ngOnInit();
        console.log(data);
      });
      //Todo
      // this.event.type=1;
      // this.event.creatorId='3fa85f64-5717-4562-b3fc-2c963f66afa6';
    }

  }

  updateEvent() {
    if (this.eventUpdateForm.valid) {
      this.updateevent = Object.assign({}, this.eventUpdateForm.value)
      this.eventService.updateEvent(this.idUpdate, this.updateevent).subscribe(data => {
        this.ngOnInit();
        console.log(data);
      });
    }
  }

  onDelete(id:number){
    console.log(id)
    this.eventService.deleteEvent(id).subscribe(data=>{
      this.ngOnInit();
      console.log(data);
    });
  }

  openUpdate(content, id:number) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.idUpdate=id;
    }, (reason) => {
      console.log(id);
    });
  }

  openNew(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    }, (reason) => {
      console.log(reason);
    }); 
  }


}
