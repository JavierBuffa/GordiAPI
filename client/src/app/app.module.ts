import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { TeamsComponent } from './teams/teams.component';
import { SharedModule } from './_modules/shared.module';
import { TestsErrorsComponent } from './errors/tests-errors/tests-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { NewTeamComponent } from './teams/new-team/new-team.component';
import { teamRegisterResolver } from './_resolver/teamRegisterResolver';
import { SummonersComponent } from './summoners/summoners/summoners.component';
import { TeamdetailsComponent } from './teams/teamdetails/teamdetails.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    TeamsComponent,
    TestsErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    NewTeamComponent,
    SummonersComponent,
    TeamdetailsComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule   
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    teamRegisterResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
