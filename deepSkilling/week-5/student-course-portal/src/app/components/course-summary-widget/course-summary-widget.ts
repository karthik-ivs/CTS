import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../services/course';

@Component({
  selector: 'app-course-summary-widget',
  imports: [],
  templateUrl: './course-summary-widget.html',
  styleUrl: './course-summary-widget.css',
})
export class CourseSummaryWidget implements OnInit {
  courseCount = 0;
  constructor(private readonly courseService: CourseService) {}

  ngOnInit(): void {
    this.courseService.getCourses().subscribe({ next: (courses) => (this.courseCount = courses.length) });
  }
}
