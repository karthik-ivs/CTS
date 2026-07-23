import { Component } from '@angular/core';
import {
  CourseCard,
  Course
} from '../../components/course-card/course-card';

@Component({
  selector: 'app-course-list',
  imports: [CourseCard],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList {

  courses: Course[] = [
    {
      id: 1,
      name: 'Angular Development',
      code: 'ANG101',
      credits: 4
    },
    {
      id: 2,
      name: 'Data Structures',
      code: 'DSA201',
      credits: 3
    },
    {
      id: 3,
      name: 'Database Management',
      code: 'DBMS301',
      credits: 3
    }
  ];

  enrolledCourseId: number | null = null;

  onEnroll(courseId: number): void {
    this.enrolledCourseId = courseId;

    const course = this.courses.find(
      c => c.id === courseId
    );

    console.log(
      'CourseList: Enrollment requested for:',
      course
    );
  }
}