using AutoMapper;
using Nop.Core.Domain.Entity;
using Nop.Core.Infrastructure.Mapper;
using Nop.Web.Areas.Admin.Models.EntityModel;

namespace Nop.Web.Areas.Admin.Infrastructure.Mapper
{
    public class AutoMapperStartupTask : Profile, IOrderedMapperProfile
    {
        #region Ctor

        public AutoMapperStartupTask() {
            CreateBooksMaps();
        }
        #endregion

        #region Utilities

        /// <summary>
        /// Create books maps 
        /// </summary>
        protected virtual void CreateBooksMaps()
        {
            CreateMap<Books, BooksModel>()
                .ForMember(model => model.Name, options => options.Ignore())
                .ForMember(entity => entity.CreatedOn, options => options.Ignore())
                .ForMember(entity => entity.Deleted, options => options.Ignore());
        }

        #endregion

        #region Properties

        /// <summary>
        /// Order of this mapper implementation
        /// </summary>
        public int Order => 0;

        #endregion
    }
}
