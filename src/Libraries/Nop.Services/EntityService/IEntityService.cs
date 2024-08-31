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
        /// Gets a book by id
        /// </summary>
        /// <param name="bookId">Book identifier</param>
        /// <returns>A book</returns>
        Books GetBookById(int bookId);

        /// <summary>
        /// Gets a book by name
        /// </summary>
        /// <param name="name">Book identifier</param>
        /// <returns>A book</returns>
        Books GetBookByName(string name);

        /// <summary>
        /// Is book already exists
        /// </summary>
        /// <param name="id">Name</param>
        /// <param name="name">Name</param>
        /// <returns>bool</returns>
        bool IsBookAlreadyExists(int id, string name);

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
