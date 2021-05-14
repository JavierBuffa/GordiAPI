import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmptyTeam } from 'src/app/_models/team';
import { TeamService } from 'src/app/_Services/team.service';

@Component({
  selector: 'app-new-team',
  templateUrl: './new-team.component.html',
  styleUrls: ['./new-team.component.css']
})
export class NewTeamComponent implements OnInit {

  baseUrl = 'Https://localhost:5001/api/';
  model: any = {};
  
  constructor(private http: HttpClient, private teamService: TeamService, private route: ActivatedRoute,  private router: Router, private toastr: ToastrService) { }
  
  ngOnInit(): void {
    this.loadTeam();
  }

  loadTeam() {
    console.log(this.router.url);
    if (this.router.url === '/newteam') {
      this.model = EmptyTeam();
    }

    else {
      this.route.data.subscribe(team => {
        this.model = team['team'];
      }, error =>
          console.log(error));
    } 
  }

  updateTeam() {
    if (this.router.url === '/newteam') {
      this.teamService.registerTeam(this.model).subscribe(next => {
        this.toastr.success('Team Registered')
      }, error => {
        this.toastr.error(error);
      })
    }
    else {
      const id = this.route.snapshot.paramMap.get('id');
      this.teamService.editTeam(+id, this.model).subscribe(next => {
        this.toastr.success('Team Updated');
      }, error => {
        this.toastr.error(error)
      })
    }
  }

  
  createTeam() {
    this.teamService.registerTeam(this.model).subscribe(response => {
      console.log(response);
    })
  }
  

}
