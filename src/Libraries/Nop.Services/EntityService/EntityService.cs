﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Entity;
using Nop.Core.Domain.Orders;
using Nop.Data;
using Nop.Services.Caching;
using Nop.Services.Common;
using Nop.Services.Events;

namespace Nop.Services.EntityService
{
    public partial class BooksService : IBooksService
    {
        #region Fields

        private readonly IRepository<Books> _booksRepository;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region Ctor

        public BooksService(IRepository<Books> bookRepository, IEventPublisher eventPublisher)
        {
            _booksRepository = bookRepository;
            _eventPublisher = eventPublisher;
        }

        #endregion

        #region Mothods

        /// <summary>
        /// Gets online books
        /// </summary>
        /// <param name="name">A list of books filter by name; </param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Books</returns>
        public virtual IPagedList<Books> GetAllBooks(string name = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _booksRepository.Table;
            query = query.Where(c => !c.Deleted);

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(c => c.Name.Contains(name));

            query = query.OrderByDescending(c => c.CreatedOn);

            var books = new PagedList<Books>(query, pageIndex, pageSize);

            return books;
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="book">Book</param>
        public virtual void DeleteBook(Books book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            book.Deleted = true;

            UpdateBook(book);

            //event notification
            _eventPublisher.EntityDeleted(book);
        }

        /// <summary>
        /// Gets a book
        /// </summary>
        /// <param name="bookId">Book identifier</param>
        /// <returns>A book</returns>
        public virtual Books GetBookById(int bookId)
        {
            if (bookId == 0)
                return null;

            return _booksRepository.GetById(bookId);
        }

        /// <summary>
        /// Get book by name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Book</returns>
        public virtual Books GetBookByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            var query = from c in _booksRepository.Table
                        orderby c.Id
                        where c.Name == name && c.Deleted == false
                        select c;
            var book = query.FirstOrDefault();
            return book;
        }

        /// <summary>
        /// Is book already exists
        /// </summary>
        /// <param name="id">Name</param>
        /// <param name="name">Name</param>
        /// <returns>bool</returns>
        public virtual bool IsBookAlreadyExists(int id, string name)
        {
            if (id <= 0)
                return false;

            var query = from c in _booksRepository.Table
                        orderby c.Id
                        where c.Id != id && c.Name == name && c.Deleted == false
                        select c;
            var book = query.FirstOrDefault();
            return book != null ? true : false;
        }

        /// <summary>
        /// Insert a book
        /// </summary>
        /// <param name="book">Book</param>
        public virtual void InsertBook(Books book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _booksRepository.Insert(book);

            //event notification
            _eventPublisher.EntityInserted(book);
        }

        /// <summary>
        /// Updates the book
        /// </summary>
        /// <param name="book">Book</param>
        public virtual void UpdateBook(Books book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _booksRepository.Update(book);

            //event notification
            _eventPublisher.EntityUpdated(book);
        }

        #endregion
    }
}
