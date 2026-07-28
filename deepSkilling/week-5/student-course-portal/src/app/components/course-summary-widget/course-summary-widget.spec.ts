import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { CourseService } from '../../services/course';

import { CourseSummaryWidget } from './course-summary-widget';

describe('CourseSummaryWidget', () => {
  let component: CourseSummaryWidget;
  let fixture: ComponentFixture<CourseSummaryWidget>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseSummaryWidget],
      providers: [{ provide: CourseService, useValue: { getCourses: () => of([]) } }],
    }).compileComponents();

    fixture = TestBed.createComponent(CourseSummaryWidget);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
