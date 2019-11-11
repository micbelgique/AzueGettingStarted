import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BottomSheetDetailsComponent } from './bottom-sheet-details.component';

describe('BottomSheetDetailsComponent', () => {
  let component: BottomSheetDetailsComponent;
  let fixture: ComponentFixture<BottomSheetDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BottomSheetDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BottomSheetDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
