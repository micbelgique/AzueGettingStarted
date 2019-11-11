import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UpdateService {
  private updatePicture = new Subject<boolean>();
  updatePicture$ = this.updatePicture.asObservable();
  constructor() { }
  updateGallery(verify: boolean) {
    if (verify) {
      this.updatePicture.next(verify);
    }
  }
}
