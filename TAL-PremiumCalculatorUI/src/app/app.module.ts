import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app.routes';
import { CalculatePremiumServiceService } from './services/calculate-premium-service.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

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
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    // Add other imported modules here
  ],
  providers: [CalculatePremiumServiceService, provideAnimationsAsync()],
  bootstrap: [AppComponent],
})
export class AppModule {
  // Bootstrap the application programmatically
  ngDoBootstrap() {}
}
