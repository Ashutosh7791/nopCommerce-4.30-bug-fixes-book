using FluentValidation;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Entity;
using Nop.Data;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Areas.Admin.Models.EntityModel;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.EntityValidator
{
    public partial class BooksValidator : BaseNopValidator<BooksModel>
    {
        public BooksValidator(INopDataProvider dataProvider) {
            RuleFor(x => x.Name).NotEmpty();

            SetDatabaseValidationRules<Books>(dataProvider);
        }
    }
}
