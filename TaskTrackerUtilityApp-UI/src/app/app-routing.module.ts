import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/pages/user.component';
import { DashboardComponent } from './dashboard/pages/dashboard.component';
import { LinechartComponent } from './linechart/pages/linechart.Component';

const routes: Routes = [
    { path: 'user', component: UserComponent },
    { path: 'dashboard', component: DashboardComponent},
    { path: 'linechart', component: LinechartComponent}
  ];

@NgModule({
    imports: [RouterModule.forRoot(
      routes
      )],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
