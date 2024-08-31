using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Customers;
using Nop.Core;
using Nop.Core.Domain.Entity;

namespace Nop.Services.EntityService
{
    public partial interface IBooksService
    {
        /// <summary>
        /// Gets all books
        /// </summary>
        /// <param name="createdon">Created date to null to load all records</param>
        /// <param name="name">name; null to load all books</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Books</returns>
        IPagedList<Books> GetAllBooks(string name = null,
         int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="book">Book</param>
        void DeleteBook(Books book);

        /// <summary>
        /// Gets a book
        /// </summary>
        /// <param name="bookId">Book identifier</param>
        /// <returns>A book</returns>
        Books GetBookById(int bookId);

        /// <summary>
        /// Insert a book
        /// </summary>
        /// <param name="book">Book</param>
        void InsertBook(Books book);

        /// <summary>
        /// Updates the book
        /// </summary>
        /// <param name="book">Book</param>
        void UpdateBook(Books book);
    }
}
