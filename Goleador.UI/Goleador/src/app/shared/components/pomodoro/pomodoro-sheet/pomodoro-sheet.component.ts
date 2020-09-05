import { Component } from '@angular/core';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';

@Component({
  selector: 'app-pomodoro-sheet',
  templateUrl: './pomodoro-sheet.component.html',
  styleUrls: ['./pomodoro-sheet.component.scss']
})
export class PomodoroSheetComponent {

  constructor(private bottomSheetRef: MatBottomSheetRef<PomodoroSheetComponent>) {}

  openLink(event: MouseEvent): void {
    this.bottomSheetRef.dismiss();
    event.preventDefault();
  }
}
