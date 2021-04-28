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
import { SummonersListComponent } from './summoners/summoners-list/summoners-list.component';
import { SummonersDetailComponent } from './summoners/summoners-detail/summoners-detail.component';
import { TeamsComponent } from './teams/teams.component';
import { SharedModule } from './_modules/shared.module';
import { TestsErrorsComponent } from './errors/tests-errors/tests-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    SummonersListComponent,
    SummonersDetailComponent,
    TeamsComponent,
    TestsErrorsComponent
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
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
