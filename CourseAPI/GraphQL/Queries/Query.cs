﻿using Course.Business.Interfaces;
using Course.Business.Models;

namespace CourseAPI.GraphQL.Queries
{
    public class Query(ICourseService courseService)
    {
        private readonly ICourseService _courseService = courseService;

        [GraphQLName("getCourses")]
        public async Task<IEnumerable<CourseModel>> GetCoursesAsync()
        {
            return await _courseService.GetCoursesAsync();
        }

        [GraphQLName("getCourseById")]
        public async Task<CourseModel> GetCourseByIdAsync(string id)
        {
            return await _courseService.GetCourseByIdAsync(id);
        }
    }
}
