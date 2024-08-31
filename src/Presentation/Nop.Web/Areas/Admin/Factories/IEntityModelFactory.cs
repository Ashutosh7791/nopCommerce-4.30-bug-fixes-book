using Nop.Core.Domain.Entity;
using Nop.Web.Areas.Admin.Models.EntityModel;

namespace Nop.Web.Areas.Admin.Factories
{
    public partial interface IBooksModelFactory
    {
        /// <summary>
        /// Prepare book search model
        /// </summary>
        /// <param name="searchModel">Book search model</param>
        /// <returns>Book search model</returns>
        BooksSearchModel PrepareBooksSearchModel(BooksSearchModel searchModel);

        /// <summary>
        /// Prepare paged book list model
        /// </summary>
        /// <param name="searchModel">Book search model</param>
        /// <returns>Book list model</returns>
        BooksListModel PrepareBooksListModel(BooksSearchModel searchModel);

        /// <summary>
        /// Prepare book model
        /// </summary>
        /// <param name="model">Book model</param>
        /// <param name="book">Book</param>
        /// <returns>Books model</returns>
        BooksModel PrepareBooksModel(BooksModel model, Books books);
    }
}
