import {
  Component,
  OnInit,
  OnDestroy
} from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LifecycleDemo } from '../../components/lifecycle-demo/lifecycle-demo';

@Component({
  selector: 'app-home',
  imports: [
    CommonModule,
    FormsModule,
    LifecycleDemo
  ],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home implements OnInit, OnDestroy {

  portalName = 'Student Course Portal';

  isPortalActive = true;

  message = '';

  searchTerm = '';

  showLifecycleDemo = true;

  constructor() {
    console.log('Home Constructor: Home component created');
  }

  ngOnInit(): void {
    console.log('Home ngOnInit: Home component initialized');
  }

  ngOnDestroy(): void {
    console.log('Home ngOnDestroy: Home component destroyed');
  }

  onEnrollClick(): void {
    this.message = 'Enrollment opened!';
  }

  toggleLifecycleDemo(): void {
    this.showLifecycleDemo = !this.showLifecycleDemo;
  }
}