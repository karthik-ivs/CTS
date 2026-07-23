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
    credits: 4,
    isPopular: true
  },

  {
    id: 2,
    name: 'Data Structures',
    code: 'DSA201',
    credits: 3,
    isPopular: false
  },

  {
    id: 3,
    name: 'Database Management',
    code: 'DBMS301',
    credits: 3,
    isPopular: true
  }

];

  enrolledCourseId: number | null = null;

  onEnroll(courseId: number): void {
    this.enrolledCourseId = courseId;

    const course = this.courses.find(
      c => c.id === courseId
    );

    console.log(
      'Enrollment requested:',
      course
    );
  }
}