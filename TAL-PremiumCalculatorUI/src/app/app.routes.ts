import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PremiumCalculatorComponent } from './premium-calculator/premium-calculator.component';
import { OccupationComponent } from './occupation/occupation.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'calculatepremium', component: PremiumCalculatorComponent },
  { path: 'occupation', component: OccupationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes, { useHash: true })],
})
export class AppRoutingModule {}
