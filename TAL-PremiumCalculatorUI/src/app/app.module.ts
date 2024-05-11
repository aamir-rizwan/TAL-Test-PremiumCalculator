import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app.routes';
import { CalculatePremiumServiceService } from './services/calculate-premium-service.service';

@NgModule({
  declarations: [
    AppComponent,
    // Add other components, directives, and pipes here
  ],
  imports: [
    BrowserModule,
    RouterModule,
    CommonModule,
    AppRoutingModule,
    // Add other imported modules here
  ],
  providers: [CalculatePremiumServiceService],
  bootstrap: [AppComponent],
  // Remove AppComponent from the bootstrap array
  // bootstrap: [AppComponent] // <-- Remove this line
})
export class AppModule {
  // Bootstrap the application programmatically
  ngDoBootstrap() {}
}
