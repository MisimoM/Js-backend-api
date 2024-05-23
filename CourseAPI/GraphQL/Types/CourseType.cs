using Course.Infrastructure.Entities;

namespace CourseAPI.GraphQL.Types
{
    public class CourseType : ObjectType<CourseEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<CourseEntity> descriptor)
        {
            descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
            descriptor.Field(c => c.ImageUrl).Type<StringType>();
            descriptor.Field(c => c.IsBestSeller).Type<BooleanType>();
            descriptor.Field(c => c.IsDigital).Type<BooleanType>();
            descriptor.Field(c => c.Title).Type<StringType>();
            descriptor.Field(c => c.Text).Type<StringType>();
            descriptor.Field(c => c.StarRating).Type<IntType>();
            descriptor.Field(c => c.Reviews).Type<IntType>();
            descriptor.Field(c => c.Likes).Type<IntType>();
            descriptor.Field(c => c.LikesInPercent).Type<IntType>();
            descriptor.Field(c => c.Hours).Type<IntType>();
            descriptor.Field(c => c.Articles).Type<IntType>();
            descriptor.Field(c => c.DownloadeableResources).Type<IntType>();
            descriptor.Field(c => c.Description).Type<StringType>();
            descriptor.Field(c => c.DescriptionList).Type<ListType<StringType>>();
            descriptor.Field(c => c.Categories).Type<ListType<StringType>>();
            descriptor.Field(c => c.Authors).Type<ListType<AuthorType>>();
            descriptor.Field(c => c.Prices).Type<PriceType>();
            descriptor.Field(c => c.ProgramDetails).Type<ListType<ProgramDetailsType>>();
        }
    }

    public class AuthorType : ObjectType<AuthorEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<AuthorEntity> descriptor)
        {
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.ImageUrl).Type<StringType>();
            descriptor.Field(a => a.Text).Type<StringType>();
        }
    }
    public class PriceType : ObjectType<PriceEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<PriceEntity> descriptor)
        {
            descriptor.Field(p => p.Price).Type<DecimalType>();
            descriptor.Field(p => p.DiscountPrice).Type<DecimalType>();
            descriptor.Field(p => p.Currency).Type<StringType>();
        }
    }

    public class ProgramDetailsType : ObjectType<ProgramDetailsEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<ProgramDetailsEntity> descriptor)
        {
            descriptor.Field(pd => pd.Title).Type<StringType>();
            descriptor.Field(pd => pd.Text).Type<StringType>();
        }
    }
}
