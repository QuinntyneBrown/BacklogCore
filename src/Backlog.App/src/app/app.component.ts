import { Component, Inject } from '@angular/core';
import { EventService } from '@api/services/event.service';
import { BASE_URL } from '@core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'], 
  host: {
    class: 'bl-root'
  }
})
export class AppComponent {
  constructor(
    private readonly _eventService: EventService
  ) {

  }
}
