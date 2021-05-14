import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { TeamService } from '../_Services/team.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  teams: any;
  
  constructor(private teamService: TeamService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadTeams();
    }
  
  
  loadTeams() {
    this.teamService.TeamLists().subscribe(model => {
      this.teams = model;
      console.log(this.teams);
    });
  }
  deleteTeam(id) {
    this.teamService.deleteTeam(id).subscribe(response => {
      console.log(response);
      this.loadTeams();
    }, error => {
      this.toastr.error(error);
    })
  }
}
