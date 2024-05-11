import { Component, OnInit } from '@angular/core';
import { CalculatePremiumService } from '../services/calculate-premium.service';
import { ApiResponse, Occupations } from '../models/models';
import {MatTableModule} from '@angular/material/table';

@Component({
  selector: 'app-occupation',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './occupation.component.html', 
  styleUrls: ['./occupation.component.css', '../common/common.css'],  
})
export class OccupationComponent  implements OnInit{

  occupations: Occupations[] = [];
  displayedColumns: string[] = ['name', 'rating', 'factor'];

  constructor(    
    private calculatorService: CalculatePremiumService
  ) {}

  ngOnInit(): void { 
  this.getOccupations();
  }

  getOccupations(): any {
    this.calculatorService.getOccupations().subscribe((data: ApiResponse<Occupations[]>) => {
        if (data) {
          this.occupations = data.content; 
        }
      });
  }

}
