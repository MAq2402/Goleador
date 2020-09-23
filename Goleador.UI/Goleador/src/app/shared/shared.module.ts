import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material/material.module';
import { PomodoroComponent } from './components/pomodoro/pomodoro.component';
import { PomodoroSheetComponent } from './components/pomodoro/pomodoro-sheet/pomodoro-sheet.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from '../core/core.module';
import { SearchComponent } from './components/books/search/search.component';

@NgModule({
  declarations: [PomodoroComponent, PomodoroSheetComponent, SearchComponent],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    CoreModule
  ],
  exports: [
    PomodoroComponent,
    PomodoroSheetComponent,
    SearchComponent,
    MaterialModule,
    CoreModule
  ],
  entryComponents: [
    PomodoroComponent,
    PomodoroSheetComponent
  ]
})
export class SharedModule { }
