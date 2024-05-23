using Azure.Core;
using Course.Business.Models;
using Course.Infrastructure.Entities;

namespace Course.Business.Factories
{
    public static class CourseFactory
    {
        public static CourseEntity Create(CourseCreateRequest request)
        {
            return new CourseEntity
            {
                ImageUrl = request.ImageUrl,
                IsBestSeller = request.IsBestSeller,
                IsDigital = request.IsDigital,
                Title = request.Title,
                Text = request.Text,
                StarRating = request.StarRating,
                Reviews = request.Reviews,
                Likes = request.Likes,
                LikesInPercent = request.LikesInPercent,
                Hours = request.Hours,
                Articles = request.Articles,
                DownloadeableResources = request.DownloadeableResources,
                Description = request.Description,
                DescriptionList = request.DescriptionList,
                Categories = request.Categories,

                Authors = request.Authors?.Select(a => new AuthorEntity
                {
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    Text = a.Text
                }).ToList(),

                Prices = request.Prices == null ? null : new PriceEntity
                {
                    Price = request.Prices.Price,
                    DiscountPrice = request.Prices.DiscountPrice,
                    Currency = request.Prices.Currency
                },

                ProgramDetails = request.ProgramDetails?.Select(a => new ProgramDetailsEntity
                {
                    Title = a.Title,
                    Text = a.Text
                }).ToList()

            };
        }

        public static CourseEntity Update(CourseUpdateRequest request)
        {
            return new CourseEntity
            {
                ImageUrl = request.ImageUrl,
                IsBestSeller = request.IsBestSeller,
                IsDigital = request.IsDigital,
                Title = request.Title,
                Text = request.Text,
                StarRating = request.StarRating,
                Reviews = request.Reviews,
                Likes = request.Likes,
                LikesInPercent = request.LikesInPercent,
                Hours = request.Hours,
                Articles = request.Articles,
                DownloadeableResources = request.DownloadeableResources,
                Description = request.Description,
                DescriptionList = request.DescriptionList,
                Categories = request.Categories,

                Authors = request.Authors?.Select(a => new AuthorEntity
                {
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    Text = a.Text
                }).ToList(),

                Prices = request.Prices == null ? null : new PriceEntity
                {
                    Price = request.Prices.Price,
                    DiscountPrice = request.Prices.DiscountPrice,
                    Currency = request.Prices.Currency
                },

                ProgramDetails = request.ProgramDetails?.Select(a => new ProgramDetailsEntity
                {
                    Title = a.Title,
                    Text = a.Text
                }).ToList(),
            };
        }

        public static CourseModel Read(CourseEntity entity)
        {
            return new CourseModel
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                IsBestSeller = entity.IsBestSeller,
                IsDigital = entity.IsDigital,
                Title = entity.Title,
                Text = entity.Text,
                StarRating = entity.StarRating,
                Reviews = entity.Reviews,
                Likes = entity.Likes,
                LikesInPercent = entity.LikesInPercent,
                Hours = entity.Hours,
                Articles = entity.Articles,
                DownloadeableResources = entity.DownloadeableResources,
                Description = entity.Description,
                DescriptionList = entity.DescriptionList,
                Categories = entity.Categories,

                Authors = entity.Authors?.Select(a => new AuthorModel
                {
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    Text = a.Text
                }).ToList(),

                Prices = entity.Prices == null ? null : new PriceModel
                {
                    Price = entity.Prices.Price,
                    DiscountPrice = entity.Prices.DiscountPrice,
                    Currency = entity.Prices.Currency
                },

                ProgramDetails = entity.ProgramDetails?.Select(a => new ProgramDetailsModel
                {
                    Title = a.Title,
                    Text = a.Text
                }).ToList(),
            };
        }
    }
}
