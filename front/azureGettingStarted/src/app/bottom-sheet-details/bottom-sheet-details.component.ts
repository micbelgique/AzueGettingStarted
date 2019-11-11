import { Component, OnInit, Inject } from '@angular/core';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material';

@Component({
  selector: 'app-bottom-sheet-details',
  templateUrl: './bottom-sheet-details.component.html',
  styleUrls: ['./bottom-sheet-details.component.css']
})
export class BottomSheetDetailsComponent implements OnInit {

  constructor(
    private bottomSheetRef: MatBottomSheetRef<BottomSheetDetailsComponent>,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data
  ) { }

  ngOnInit() {
  }
  openLink(event: MouseEvent): void {
    this.bottomSheetRef.dismiss();
    event.preventDefault();
  }
}
