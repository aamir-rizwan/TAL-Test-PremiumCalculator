export class PremiumCalculatorRequest {
  name: string | undefined;
  age: number | undefined;
  dob: Date | undefined;
  occupation: string | undefined;
  deathSumInsured: number | undefined;
}

export class PremiumCalculatorResponse {
  name: string | undefined;
  age: number | undefined;
  dob: Date | undefined;
  occupation: string | undefined;
  deathSumInsured: number | undefined;
  deathPremium: number | undefined;
}

export interface Occupations {
  name: string;
  rating: OccupationRatingType;
}

export interface OccupationRatingType {
  PROFESSIONAL: OccupationRating;
  WHITE_COLLAR: OccupationRating;
  LIGHT_MANUAL: OccupationRating;
  HEAVY_MANUAL: OccupationRating;
}

export interface OccupationRating {
  rating: string;
  factor: number;
}

export enum Occupation {
  Cleaner = 'Cleaner',
  Doctor = 'Doctor',
  Author = 'Author',
  Farmer = 'Farmer',
  Mechanic = 'Mechanic',
  Florist = 'Florist',
}

export class ApiResponse<T> {
  success: boolean | undefined;
  message: string | undefined;
  content: T | any;
}
