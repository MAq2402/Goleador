import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PomodoroSheetComponent } from './pomodoro-sheet.component';

describe('PomodoroSheetComponent', () => {
  let component: PomodoroSheetComponent;
  let fixture: ComponentFixture<PomodoroSheetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PomodoroSheetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PomodoroSheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
