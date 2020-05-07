/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ErrorDialogService } from './error-dialog.service';

describe('Service: ErrorDialog', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ErrorDialogService]
    });
  });

  it('should ...', inject([ErrorDialogService], (service: ErrorDialogService) => {
    expect(service).toBeTruthy();
  }));
});
