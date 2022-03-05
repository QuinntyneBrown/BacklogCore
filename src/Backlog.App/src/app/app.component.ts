import { Component, Inject } from '@angular/core';
import { EventService } from '@api/services/event.service';
import { BASE_URL } from '@core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'], 
  host: {
    class: 'bl-root'
  }
})
export class AppComponent {
  constructor(private readonly _translateService: TranslateService, 
    private readonly _eventService: EventService
  ) {
    _translateService.setDefaultLang("en");
    _translateService.use(localStorage.getItem("currentLanguage") || "en");
  }
}
