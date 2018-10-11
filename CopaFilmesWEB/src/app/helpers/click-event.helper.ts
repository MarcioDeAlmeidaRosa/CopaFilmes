import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';


@Injectable()
export class ClickEventHelper {
  private _subject = new Subject<any>();

  callEvent(event) {
    this._subject.next(event);
  }

  get events$ () {
    return this._subject.asObservable();
  }
}
