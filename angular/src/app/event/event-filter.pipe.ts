import { Pipe, PipeTransform } from '@angular/core';
import { GetEvent } from '../models/event/get-event'

@Pipe({
  name: 'eventFilter'
})
export class EventFilterPipe implements PipeTransform {

  transform(value: GetEvent[], filterText?:string): GetEvent[] {
   filterText=filterText?filterText.toLocaleLowerCase():null

    return filterText?value.filter((p:GetEvent)=>p.name
    .toLocaleLowerCase().indexOf(filterText)!==-1):value;
  }

}
