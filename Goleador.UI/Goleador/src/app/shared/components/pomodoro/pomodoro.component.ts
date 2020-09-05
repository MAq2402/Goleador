import { Component, OnInit } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { PomodoroSheetComponent } from './pomodoro-sheet/pomodoro-sheet.component';

@Component({
  selector: 'app-pomodoro',
  templateUrl: './pomodoro.component.html',
  styleUrls: ['./pomodoro.component.scss']
})
export class PomodoroComponent implements OnInit {

  constructor(private bottomSheet: MatBottomSheet) {}

  ngOnInit() {
  }

  openBottomSheet(): void {
    this.bottomSheet.open(PomodoroSheetComponent);
  }
}
