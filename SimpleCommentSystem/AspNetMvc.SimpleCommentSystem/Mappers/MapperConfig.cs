namespace AspNetMvc.SimpleCommentSystem.Mappers
{
    using AutoMapper;

    public static partial class AutoMapperConfig
    {
        public static void ConfigureMapper()
        {
            Mapper.Initialize(cfg =>
            {
                DTOtoViewModels(cfg);

                ViewModelToDTO(cfg);
            });

#if DEBUG
            System.Diagnostics.Debug.WriteLine("\n\n\nMapper initialized.\n\n\n");
#endif
        }
    }
}