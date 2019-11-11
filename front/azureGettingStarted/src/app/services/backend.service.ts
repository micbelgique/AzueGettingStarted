import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BackendService {
  private endpoint: string;
  constructor(
    private httpClient: HttpClient
  ) {
    this.endpoint = '';
  }
  public getAllPictures(): Observable<any> {
    return this.httpClient.get(this.endpoint + 'api/image');
  }
  public sendPicture(file): Observable<any> {
    const formData = new FormData();
    formData.append('image', file);
    return this.httpClient.post(this.endpoint + 'api/image', formData);
  }
}
