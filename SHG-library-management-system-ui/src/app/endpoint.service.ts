import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EndpointService {

  constructor(private http: HttpClient) { 
    
  }

  signUp(jsonString : string): Observable<any> {

    // Create an object to hold the request body
    const body =  jsonString;

    // Set the content type header
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    // Specify the API endpoint URL
    const apiUrl = `https://localhost:7093/Auth/SignUp`;

    console.log("body");

    // Make a POST request to the API endpoint with the JSON string in the request body and headers
    return this.http.post(apiUrl, body, { headers: headers });
  }
}
