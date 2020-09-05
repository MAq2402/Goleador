import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material/material.module';
import { PomodoroComponent } from './components/pomodoro/pomodoro.component';
import { PomodoroSheetComponent } from './components/pomodoro/pomodoro-sheet/pomodoro-sheet.component';



@NgModule({
  declarations: [PomodoroComponent, PomodoroSheetComponent],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    PomodoroComponent,
    PomodoroSheetComponent
  ],
  entryComponents: [
    PomodoroComponent,
    PomodoroSheetComponent
  ]
})
export class SharedModule { }
