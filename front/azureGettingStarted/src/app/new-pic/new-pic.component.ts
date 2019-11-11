import { Component, OnInit } from '@angular/core';
import { BackendService } from '../services/backend.service';
import { UpdateService } from '../services/update.service';

@Component({
  selector: 'app-new-pic',
  templateUrl: './new-pic.component.html',
  styleUrls: ['./new-pic.component.css']
})
export class NewPicComponent implements OnInit {
  loading: boolean;
  constructor(
    private backendService: BackendService,
    private updateService: UpdateService
    ) { }

  ngOnInit() {
    this.loading = false;
  }
  upload(files) {
    const file = files[0];
    this.loading = true;
    this.backendService.sendPicture(file).subscribe(
      (result) => {
          this.loading = false;
          this.updateService.updateGallery(true);
      }
    );
  }
}
