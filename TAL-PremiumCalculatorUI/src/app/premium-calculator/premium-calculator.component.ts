import { Component, OnInit } from '@angular/core';
import { PremiumCalculatorRequest } from '../models/models';
import { CalculatePremiumServiceService } from '../services/calculate-premium-service.service';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import {
  MatFormFieldModule,
  FloatLabelType,
} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'app-premium-calculator',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatSelectModule,
    MatIconModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatTooltipModule,
  ],
  templateUrl: './premium-calculator.component.html',
  styleUrls: ['./premium-calculator.component.css', '../common/common.css'],
})
export class PremiumCalculatorComponent implements OnInit {
  createForm: FormGroup = new FormGroup({});
  constructor(
    private formBuilder: FormBuilder,
    private calculatorService: CalculatePremiumServiceService
  ) {}

  request = new PremiumCalculatorRequest();

  ngOnInit(): void {
    this.createForm = this.formBuilder.group({
      name: ['', Validators.required],
      age: ['', Validators.required],
      dob: ['', Validators.required],
      occupation: ['', Validators.required],
      deathSumInsured: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.createForm?.valid) {
      // Handle form submission here
      console.log(this.createForm.value);
    }
  }
}
