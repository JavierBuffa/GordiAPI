import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Team } from '../_models/team';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class TeamService {
  model: any;
  baseUrl = 'Https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  
  TeamLists() {
    return this.http.get(this.baseUrl + 'teams');
  }
  
  registerTeam(model: any) {
    return this.http.post(this.baseUrl + 'teams/createteam', model);
  }
  
  getTeam(id: number): Observable<Team> {
    return this.http.get<Team>(this.baseUrl + 'teams/id/' + id);
  }
  
  editTeam(id: number, model: any) {
    return this.http.put(this.baseUrl + 'teams/edit/' + model.id, model);
  }

  deleteTeam(id: number) {
    return this.http.delete(this.baseUrl + 'teams/' + id);
  }

}
