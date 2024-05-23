using Course.Business.Models;

namespace Course.Business.Interfaces
{
    public interface ICourseService
    {
        Task<CourseModel> CreateCourseAsync(CourseCreateRequest request);

        Task<CourseModel> GetCourseByIdAsync(string id);

        Task<IEnumerable<CourseModel>> GetCoursesAsync();

        Task<CourseModel> UpdateCourseAsync(CourseUpdateRequest request);

        Task<bool> DeleteCourseAsync(string id);
    }
}
