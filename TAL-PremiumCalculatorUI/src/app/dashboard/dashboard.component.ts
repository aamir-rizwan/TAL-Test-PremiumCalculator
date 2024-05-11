import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css', '../common/common.css'],
})
export class DashboardComponent {
  title = 'TAL Insurance Premium Calculator';
}
