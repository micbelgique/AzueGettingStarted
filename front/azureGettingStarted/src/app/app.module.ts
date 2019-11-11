import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GalleryComponent } from './gallery/gallery.component';
import { HomeComponent } from './home/home.component';
import { NewPicComponent } from './new-pic/new-pic.component';
import { BottomSheetDetailsComponent } from './bottom-sheet-details/bottom-sheet-details.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatCardModule,
  MatInputModule,
  MatButtonModule,
  MatTabsModule,
  MatGridListModule,
  MatListModule,
  MatProgressSpinnerModule,
  MatBottomSheetModule,
  MatExpansionModule,
  MatSelectModule
} from '@angular/material';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    GalleryComponent,
    HomeComponent,
    NewPicComponent,
    BottomSheetDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    HttpClientModule,
    MatTabsModule,
    MatGridListModule,
    MatListModule,
    MatProgressSpinnerModule,
    MatBottomSheetModule,
    MatExpansionModule,
    MatSelectModule
  ],
  providers: [],
  entryComponents: [BottomSheetDetailsComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
