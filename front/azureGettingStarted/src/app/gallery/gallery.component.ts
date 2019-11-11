import { Component, OnInit } from '@angular/core';
import { BackendService } from '../services/backend.service';
import { MatBottomSheet } from '@angular/material';
import { BottomSheetDetailsComponent } from '../bottom-sheet-details/bottom-sheet-details.component';
import { UpdateService } from '../services/update.service';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {

  public pictures;
  constructor(
    private backendService: BackendService,
    private bottomSheet: MatBottomSheet,
    private updateService: UpdateService
  ) {
    this.pictures = [];
    this.updateService.updatePicture$.subscribe(
      result => {
        if (result) {
          this.loadPictures();
        }
      }
    );
   }

  ngOnInit() {
    this.loadPictures();
  }

  loadPictures() {
    this.backendService.getAllPictures().subscribe(
      (result) => {
        this.pictures = result;
      }
    );
  }

  getDetails(id: number): void {
    const picture = this.pictures.find(x => x.id === id);
    this.bottomSheet.open(BottomSheetDetailsComponent, {data: picture.visionResult});
  }

}
