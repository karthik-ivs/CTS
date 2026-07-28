import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
} from '@angular/forms';

export function noCourseCode(control: AbstractControl): ValidationErrors | null {
  return control.value?.toString().startsWith('XX') ? { noCourseCode: true } : null;
}

export function simulateEmailCheck(control: AbstractControl): Promise<ValidationErrors | null> {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve(control.value?.toLowerCase().includes('test@') ? { emailTaken: true } : null);
    }, 800);
  });
}

@Component({
  selector: 'app-reactive-enrollment-form',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './reactive-enrollment-form.html',
  styleUrl: './reactive-enrollment-form.css',
})
export class ReactiveEnrollmentForm implements OnInit {
  enrollForm!: FormGroup;

  constructor(private readonly fb: FormBuilder) {}

  ngOnInit(): void {
    this.enrollForm = this.fb.group({
      studentName: ['', [Validators.required, Validators.minLength(3)]],
      studentEmail: this.fb.control('', [Validators.required, Validators.email], [simulateEmailCheck]),
      courseId: ['', [Validators.required, noCourseCode]],
      preferredSemester: ['Odd', Validators.required],
      agreeToTerms: [false, Validators.requiredTrue],
      additionalCourses: this.fb.array([]),
    });
  }

  // This getter keeps casting out of the template and gives one reusable typed access point.
  get additionalCourses(): FormArray<FormControl<string | null>> {
    return this.enrollForm.get('additionalCourses') as FormArray<FormControl<string | null>>;
  }

  addCourse(): void {
    this.additionalCourses.push(this.fb.control('', Validators.required));
  }

  removeCourse(index: number): void {
    this.additionalCourses.removeAt(index);
  }

  onSubmit(): void {
    if (this.enrollForm.invalid) {
      this.enrollForm.markAllAsTouched();
      return;
    }

    console.log('Reactive enrollment form value:', this.enrollForm.value);
    // value excludes disabled controls; getRawValue() includes both enabled and disabled controls.
    console.log('Reactive enrollment form raw value:', this.enrollForm.getRawValue());
  }

  canDeactivate(): boolean {
    return !this.enrollForm.dirty || window.confirm('You have unsaved changes. Leave?');
  }
}
