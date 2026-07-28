import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import {
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  FormArray,
  FormControl,
  Validators,
  AbstractControl,
  ValidationErrors,
  AsyncValidatorFn
} from '@angular/forms';

import { Observable, of } from 'rxjs';
import { delay, map } from 'rxjs/operators';

@Component({
  selector: 'app-reactive-enrollment-form',
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './reactive-enrollment-form.html',
  styleUrl: './reactive-enrollment-form.css'
})
export class ReactiveEnrollmentForm implements OnInit {

  enrollForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {

    this.enrollForm = this.fb.group({

      // Student Name
      studentName: [
        '',
        [
          Validators.required,
          Validators.minLength(3)
        ]
      ],

      // Student Email
      studentEmail: [
        '',
        [
          Validators.required,
          Validators.email
        ],
        [
          this.simulateEmailCheck()
        ]
      ],

      // Course Code
      courseId: [
        '',
        [
          Validators.required,
          this.noCourseCode
        ]
      ],

      // Preferred Semester
      preferredSemester: [
        'Odd',
        Validators.required
      ],

      // Terms and Conditions
      agreeToTerms: [
        false,
        Validators.requiredTrue
      ],

      // Dynamic additional courses
      additionalCourses: this.fb.array([])

    });

  }


  // Custom synchronous validator
  // Rejects course codes starting with "XX"
  noCourseCode(control: AbstractControl): ValidationErrors | null {

    const value = control.value;

    if (value && value.toString().startsWith('XX')) {
      return {
        noCourseCode: true
      };
    }

    return null;
  }


  // Custom asynchronous validator
  // Rejects emails containing "test@"
  // Simulates an API call with an 800ms delay
  simulateEmailCheck(): AsyncValidatorFn {

    return (
      control: AbstractControl
    ): Observable<ValidationErrors | null> => {

      const email = control.value;

      // Don't validate empty values here.
      // Validators.required handles empty values.
      if (!email) {
        return of(null);
      }

      return of(email).pipe(

        delay(800),

        map(value => {

          if (value.includes('test@')) {
            return {
              emailTaken: true
            };
          }

          return null;

        })

      );

    };

  }


  // Getter for the FormArray
  get additionalCourses(): FormArray<FormControl<string>> {

    return this.enrollForm.get(
      'additionalCourses'
    ) as FormArray<FormControl<string>>;

  }


  // Getter that returns FormControl[] instead of AbstractControl[]
  // This fixes the [formControl]="ctrl" template error
  get additionalCourseControls(): FormControl<string>[] {

    return this.additionalCourses.controls;

  }


  // Add a new course to the FormArray
  addCourse(): void {

    const courseControl = new FormControl<string>(
      '',
      {
        nonNullable: true,
        validators: [
          Validators.required
        ]
      }
    );

    this.additionalCourses.push(courseControl);

  }


  // Remove a course from the FormArray
  removeCourse(index: number): void {

    this.additionalCourses.removeAt(index);

  }


  // Submit the form
  onSubmit(): void {

    if (this.enrollForm.valid) {

      console.log(
        'Form Value:',
        this.enrollForm.value
      );

      console.log(
        'Raw Form Value:',
        this.enrollForm.getRawValue()
      );

    } else {

      console.log('Form is invalid');

      // Show validation errors
      this.enrollForm.markAllAsTouched();

    }

  }

}