import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material/material.module';
import { PomodoroComponent } from './components/pomodoro/pomodoro.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from '../core/core.module';
import { SearchComponent } from './components/books/search/search.component';
import { NavbarComponent } from './components/navbar/navbar.component';

@NgModule({
  declarations: [PomodoroComponent, SearchComponent, NavbarComponent],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    CoreModule
  ],
  exports: [
    PomodoroComponent,
    SearchComponent,
    MaterialModule,
    CoreModule,
    NavbarComponent
  ],
  entryComponents: [
    PomodoroComponent
  ]
})
export class SharedModule { }
