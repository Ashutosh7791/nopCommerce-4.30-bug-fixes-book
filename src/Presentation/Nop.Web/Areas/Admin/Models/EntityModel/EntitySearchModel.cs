using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Nop.Web.Areas.Admin.Models.EntityModel
{
    /// <summary>
    /// Represents a books search model
    /// </summary>
    public partial class BooksSearchModel : BaseSearchModel
    {
        #region Ctor

        public BooksSearchModel()
        {
        }

        #endregion

        #region Properties

        public string SearchName { get; set; }

        #endregion
    }
}
