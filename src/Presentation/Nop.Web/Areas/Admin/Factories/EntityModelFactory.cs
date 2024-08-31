using System;
using System.Linq;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Entity;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Gdpr;
using Nop.Core.Domain.Tax;
using Nop.Services.Customers;
using Nop.Services.EntityService;
using Nop.Services.Helpers;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Areas.Admin.Models.EntityModel;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    public class BooksModelFactory : IBooksModelFactory
    {
        #region Fields
        private readonly IBooksService _booksService;
        #endregion

        #region Ctor
        public BooksModelFactory(IBooksService booksService)
        {
            _booksService = booksService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Prepare book search model
        /// </summary>
        /// <param name="searchModel">Book search model</param>
        /// <returns>Book search model</returns>
        public virtual BooksSearchModel PrepareBooksSearchModel(BooksSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged book list model
        /// </summary>
        /// <param name="searchModel">Book search model</param>
        /// <returns>Book list model</returns>
        public virtual BooksListModel PrepareBooksListModel(BooksSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get books
            var books = _booksService.GetAllBooks(
                name: searchModel.SearchName,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare list model
            var model = new BooksListModel().PrepareToGrid(searchModel, books, () =>
            {
                return books.Select(book =>
                {
                    //fill in model values from the entity
                    var booksModel = book.ToModel<BooksModel>();

                    //convert dates to the user time
                    booksModel.Name = book.Name;
                    booksModel.CreatedOn = book.CreatedOn;

                    return booksModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare book model
        /// </summary>
        /// <param name="model">Book model</param>
        /// <param name="book">Book</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Books model</returns>
        public virtual BooksModel PrepareBooksModel(BooksModel model, Books books, bool excludeProperties = false)
        {
            if (books != null)
            {
                //fill in model values from the entity
                model ??= new BooksModel();

                //whether to fill in some of properties
                
                model.Id = books.Id;
                model.Name = books.Name;
                model.CreatedOn = books.CreatedOn;
            }

            return model;
        }

        #endregion

    }
}
