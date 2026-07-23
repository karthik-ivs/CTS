import { CourseCodePipe } from '/Users/ivskarthik/Desktop/CTS/deepSkilling/week-5/student-course-portal/src/app/pipes/course-code-pipe';

import {
  UpperCasePipe,
  LowerCasePipe,
  DatePipe,
  CurrencyPipe,
  DecimalPipe
} from '@angular/common';

import {
  Component,
  Input,
  Output,
  EventEmitter
} from '@angular/core';

import { NgClass, NgStyle } from '@angular/common';

export interface Course {
  id: number;
  name: string;
  code: string;
  credits: number;
  isPopular?: boolean;
}


@Component({
  selector: 'app-course-card',
  imports: [
  NgClass,
  NgStyle,
  UpperCasePipe,
  LowerCasePipe,
  DatePipe,
  CurrencyPipe,
  DecimalPipe,
  CourseCodePipe
  ],
  templateUrl: './course-card.html',
  styleUrl: './course-card.css'
})
export class CourseCard {

  @Input() course!: Course;

  @Output() enrollRequested =
    new EventEmitter<number>();

  courseStartDate =
    new Date(2026, 7, 1);

  courseFee = 4999.99;

  onEnroll(): void {

    this.enrollRequested.emit(
      this.course.id
    );

  }
}