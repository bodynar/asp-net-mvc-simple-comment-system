namespace AspNetMvc.SimpleCommentSystem.Mappers
{
    #region References

    using AutoMapper;
    using Models;

    #endregion

    public static partial class AutoMapperConfig
    {
        static void DTOtoViewModels(IMapperConfigurationExpression cfg)
        {
            #region NewsDetailsViewModel

            cfg.CreateMap<News, NewsDetailsViewModel>()
                .ForMember(dest=> dest.CommentsCount, e=> e.MapFrom(src=> src.Comments.Count));

            #endregion

        }
    }
}