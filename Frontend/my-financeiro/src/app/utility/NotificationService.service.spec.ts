/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NotificationServiceService } from './NotificationService.service';

describe('Service: NotificationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NotificationServiceService]
    });
  });

  it('should ...', inject([NotificationServiceService], (service: NotificationServiceService) => {
    expect(service).toBeTruthy();
  }));
});
