import { Component, OnInit } from '@angular/core';
import { ApiResponse, Occupations,  PremiumCalculatorRequest,  PremiumCalculatorResponse,} from '../models/models';
import { CalculatePremiumService } from '../services/calculate-premium.service';
import { FormBuilder,  FormGroup,  ReactiveFormsModule,  Validators,} from '@angular/forms';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatDatepickerModule,} from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-premium-calculator',
  standalone: true,
  imports: [ MatFormFieldModule, MatInputModule, MatIconModule, MatSelectModule, MatIconModule, MatDatepickerModule, ReactiveFormsModule, MatButtonModule, MatTooltipModule,
    HttpClientModule, CommonModule, MatSelectModule],
  templateUrl: './premium-calculator.component.html',
  styleUrls: ['./premium-calculator.component.css', '../common/common.css'],
})

export class PremiumCalculatorComponent implements OnInit {

  createForm: FormGroup = new FormGroup({});
  occupations: Occupations[] = [];
  maxDate: Date = new Date();
  request = new PremiumCalculatorRequest();
  response: PremiumCalculatorResponse | undefined;

  constructor(
    private formBuilder: FormBuilder,
    private calculatorService: CalculatePremiumService
  ) {}

  ngOnInit(): void {
    this.createForm = this.formBuilder.group({
      name: ['', Validators.required],
      age: ['', Validators.required],
      dob: ['', Validators.required],
      occupation: ['', Validators.required],
      deathSumInsured: ['', Validators.required],
    });
    this.getOccupations();
  }

  getOccupations(): any {
    this.calculatorService.getOccupations().subscribe((data: ApiResponse<Occupations[]>) => {
        if (data) {
          this.occupations = data.content; 
        }
      });
  }

  onSubmit(): void {
    if (this.createForm?.valid) {
      this.request.name = this.createForm.get('name')?.value;
      this.request.age = this.createForm.get('age')?.value;
      this.request.dob = this.createForm.get('dob')?.value;
      this.request.occupation = this.createForm.get('occupation')?.value;
      this.request.deathSumInsured = this.createForm.get('deathSumInsured')?.value;

      this.calculatorService.CalculatePremium(this.request).subscribe((data: ApiResponse<PremiumCalculatorResponse>) => {
          if (data) {
            this.response = data.content;            
          }
        });
    }
  }

  onCancel() {
    this.createForm.reset(); // Reset the form to its initial state
  }
}
