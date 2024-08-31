using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Entity;

namespace Nop.Data.Mapping.Builders.EntityMap
{
    /// <summary>
    /// Represents a book entity builder
    /// </summary>
    public partial class BooksBuilder : NopEntityBuilder<Books>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Books.Name)).AsString(1000).Nullable()
                .WithColumn(nameof(Books.CreatedOn)).AsDateTime2().Nullable();
        }

        #endregion
    }
}
