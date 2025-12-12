import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StoryActionbarService {

  public cancel$ = new Subject<void>();

  public save$ = new Subject<void>();
}
