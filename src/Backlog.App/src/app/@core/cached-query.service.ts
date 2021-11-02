import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { shareReplay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CachedQueryService {

  private readonly _cache = new Map<string, Observable<any>>();

  private readonly _refreshSubject = new Subject<void>();

  protected _fromCacheOrService$(key:string, func: {(): Observable<any>}): Observable<any> {
    if (!this._cache.get(key)) {
      this._cache.set(
        key,
        func().pipe(shareReplay(1))
      );
    }
    return this._cache.get(key);
  }

}
