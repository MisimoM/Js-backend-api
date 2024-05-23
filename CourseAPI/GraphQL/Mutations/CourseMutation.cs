using Course.Business.Interfaces;
using Course.Business.Models;

namespace CourseAPI.GraphQL.Mutations
{
    public class CourseMutation(ICourseService courseService)
    {
        private readonly ICourseService _courseService = courseService;

        [GraphQLName("createCourse")]
        public async Task<CourseModel> CreateCourseAsync(CourseCreateRequest input)
        {
            return await _courseService.CreateCourseAsync(input);
        }

        [GraphQLName("updateCourse")]
        public async Task<CourseModel> UpdateCourseAsync(CourseUpdateRequest input)
        {
            return await _courseService.UpdateCourseAsync(input);
        }

        [GraphQLName("deleteCourse")]
        public async Task<bool> DeleteCourseAsync(string id)
        {
            return await _courseService.DeleteCourseAsync(id);
        }
    }
}
