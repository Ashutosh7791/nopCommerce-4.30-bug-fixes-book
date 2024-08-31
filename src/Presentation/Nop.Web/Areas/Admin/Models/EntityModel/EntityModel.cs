using System;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.EntityModel
{
    public partial class BooksModel :  BaseNopEntityModel
    {
        #region ctor
        public BooksModel()
        {
        }
        #endregion

        #region Properties

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Deleted { get; set; }
        #endregion

    }
}
