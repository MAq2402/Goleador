import { NgModule } from '@angular/core';
import {MatBottomSheetModule} from '@angular/material/bottom-sheet';
import {MatListModule} from '@angular/material/list';
import {MatButtonModule} from '@angular/material/button';




@NgModule({
  declarations: [],
  imports: [
    MatBottomSheetModule,
    MatListModule,
    MatButtonModule
  ],
  exports: [
    MatBottomSheetModule,
    MatListModule,
    MatButtonModule
  ]
})
export class MaterialModule { }
