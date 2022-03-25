import { Component } from '@angular/core';

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
  constructor(private readonly _translateService: TranslateService
  ) {
    _translateService.setDefaultLang("en");
    _translateService.use(localStorage.getItem("currentLanguage") || "en");
  }
}
