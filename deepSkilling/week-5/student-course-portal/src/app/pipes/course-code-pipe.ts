import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'courseCode'
})
export class CourseCodePipe implements PipeTransform {

  transform(value: string): string {

    if (!value) {
      return '';
    }

    return `COURSE-${value.toUpperCase()}`;
  }

}