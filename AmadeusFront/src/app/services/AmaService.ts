import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ResponseLogin } from "../models/dto/ResponseLogin";
import { environment } from "../../environments/environment";
import { Project } from "../models/Project";
import { TodoTask } from "../models/TodoTask";

@Injectable({
  providedIn: 'root'
})
export class AmaService {
    constructor(private http: HttpClient) { }

    url = environment.apiUrl + '/api';

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

    //#region Projects
    fetchMyProjects(): Observable<Project[]> {
        return this.http.get<Project[]>(`${this.url}/me/projects`);
    }

    fetchProjectById(id: number): Observable<Project> {
        return this.http.get<Project>(`${this.url}/projects/${id}`);
    }
    //#endregion

    //#region Todo Tasks
    fetchMyTodoTasks(): Observable<TodoTask[]> {
        return this.http.get<TodoTask[]>(`${this.url}/me/todos`);
    }

    nextStateMyTodoTask(id: number): Observable<TodoTask> {
        return this.http.post<TodoTask>(`${this.url}/me/todos/${id}/next-state`,{});
    }

    deleteMyTodoTask(id: number): Observable<any> {
        return this.http.delete<any>(`${this.url}/me/todos/${id}`);
    }
    //#endregion
}