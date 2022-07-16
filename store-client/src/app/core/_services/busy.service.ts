import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  budyRequestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  busy() {
    this.budyRequestCount++;
    this.spinnerService.show(undefined, {
      // Spinner configurations.
      type: 'timer',
      bdColor: 'rgba(255,255,255,0.7)',
      color: '#333333'
    });
  }

  idle() {
    this.budyRequestCount--;
    if (this.budyRequestCount <= 0) {
      this.budyRequestCount = 0;
      this.spinnerService.hide();
    }
  }
}
