import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestsErrorsComponent } from './errors/tests-errors/tests-errors.component';
import { HomeComponent } from './home/home.component';
import { SummonersDetailComponent } from './summoners/summoners-detail/summoners-detail.component';
import { SummonersListComponent } from './summoners/summoners-list/summoners-list.component';
import { TeamsComponent } from './teams/teams.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'summoners', component: SummonersListComponent, canActivate: [AuthGuard]},
      {path: 'summoners/:id', component: SummonersDetailComponent},
      {path: 'teams', component: TeamsComponent},
    ]
  },
  {path: 'errors', component: TestsErrorsComponent},
  {path: '**', component: TeamsComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
