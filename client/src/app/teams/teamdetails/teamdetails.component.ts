import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { TeamService } from 'src/app/_Services/team.service';


@Component({
  selector: 'app-teamdetails',
  templateUrl: './teamdetails.component.html',
  styleUrls: ['./teamdetails.component.css']
})
export class TeamdetailsComponent implements OnInit {

  constructor(private teamService: TeamService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  getTeamWithMembers(id) {
    this.teamService.getTeam(id).subscribe(response => {
      
    })
  }
}
