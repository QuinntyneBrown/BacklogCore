import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StoryFeatureService {

  public cancel$ = new Subject();

  public save$ = new Subject();
}
