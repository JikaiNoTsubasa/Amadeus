import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ResponseLogin } from "../models/dto/ResponseLogin";

@Injectable({
  providedIn: 'root'
})
export class AmaService {
    constructor(private http: HttpClient) { }

    url = 'http://localhost:5093/api';

    //#region Login
    authenticate(email: string, password: string): Observable<ResponseLogin> {
        // Json body
        let body = {
            identifier: email,
            password: password
        };
        return this.http.post<ResponseLogin>(`${this.url}/auth/login`, body);
    }
    //#endregion
}