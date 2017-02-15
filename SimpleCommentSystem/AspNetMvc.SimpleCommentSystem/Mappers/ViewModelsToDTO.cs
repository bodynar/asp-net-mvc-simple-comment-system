namespace AspNetMvc.SimpleCommentSystem.Mappers
{
    #region References

    using System;
    using AutoMapper;
    using Models;

    #endregion

    public static partial class AutoMapperConfig
    {
        static void ViewModelToDTO(IMapperConfigurationExpression cfg)
        {
            #region Comment

            cfg.CreateMap<CommentAddViewModel, Comment>()
                .ForMember(dest=> dest.Id, e=> e.UseValue(Guid.NewGuid()));

            #endregion

            #region News

            cfg.CreateMap<NewsAddViewModel, News>()
               .ForMember(dest => dest.Id, e => e.UseValue(Guid.NewGuid()));

            #endregion

        }
    }
}