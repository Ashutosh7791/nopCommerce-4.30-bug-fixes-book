using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Entity
{
    public partial class Books : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the book has been deleted
        /// </summary>
        public bool Deleted { get; set; }
    }
}
