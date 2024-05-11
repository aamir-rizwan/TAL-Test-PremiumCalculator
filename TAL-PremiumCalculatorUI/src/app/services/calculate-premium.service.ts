import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  ApiResponse,
  Occupations,
  PremiumCalculatorRequest,
  PremiumCalculatorResponse,
} from '../models/models';

@Injectable({ providedIn: 'root' })
export class CalculatePremiumService {
  public BaseUrl = 'https://localhost:7084/api';

  constructor(public http: HttpClient) {}

  public getOccupations(): Observable<any> {
    return this.http.get<any[]>(
      this.BaseUrl + '/CalculatePremium/GetOccupations'
    );
  }

  public CalculatePremium(request: PremiumCalculatorRequest): Observable<ApiResponse<PremiumCalculatorResponse>> {
    return this.http.post<ApiResponse<PremiumCalculatorRequest>>(
      `${this.BaseUrl}/CalculatePremium/CalculatePremium`,
      request
    );
  }
}
