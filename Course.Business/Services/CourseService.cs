using Course.Business.Factories;
using Course.Business.Interfaces;
using Course.Business.Models;
using Course.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Course.Business.Services
{
    public class CourseService(IDbContextFactory<CourseDbContext> contextFactory) : ICourseService
    {
        private readonly IDbContextFactory<CourseDbContext> _contextFactory = contextFactory;

        public async Task<CourseModel> CreateCourseAsync(CourseCreateRequest request)
        {
            await using var context = _contextFactory.CreateDbContext();
            var courseEntity = CourseFactory.Create(request);
            context.Courses.Add(courseEntity);
            await context.SaveChangesAsync();
            return CourseFactory.Read(courseEntity);
        }

        public async Task<bool> DeleteCourseAsync(string id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var courseEntity = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (courseEntity is null) return false;

            context.Courses.Remove(courseEntity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<CourseModel> GetCourseByIdAsync(string id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var courseEntity = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);

            return courseEntity == null ? null! : CourseFactory.Read(courseEntity);
        }

        public async Task<IEnumerable<CourseModel>> GetCoursesAsync()
        {
            await using var context = _contextFactory.CreateDbContext();
            var courseEntities = await context.Courses.ToListAsync();

            return courseEntities.Select(CourseFactory.Read);
        }

        public async Task<CourseModel> UpdateCourseAsync(CourseUpdateRequest request)
        {
            await using var context = _contextFactory.CreateDbContext();
            var existingCourse = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (existingCourse is null) return null!;

            var updatedCourseEntity = CourseFactory.Update(request);
            updatedCourseEntity.Id = existingCourse.Id;
            context.Entry(updatedCourseEntity).CurrentValues.SetValues(updatedCourseEntity);

            await context.SaveChangesAsync();
            return CourseFactory.Read(existingCourse);
        }
    }
}
