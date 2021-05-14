import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { Team } from "../_models/team";
import { TeamService } from "../_Services/team.service";

@Injectable()
export class teamRegisterResolver implements Resolve<Team> {
    constructor(private teamService: TeamService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Team> {
        return this.teamService.getTeam(route.params['id'])
    }
}