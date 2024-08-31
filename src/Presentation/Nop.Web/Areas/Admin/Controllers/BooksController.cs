using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Gdpr;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.Tax;
using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.ExportImport;
using Nop.Services.Forums;
using Nop.Services.Gdpr;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Services.Tax;
using LinqToDB;
using Nop.Services.EntityService;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Areas.Admin.Models.EntityModel;
using Nop.Web.Areas.Admin.Factories;
using Microsoft.AspNetCore.Http;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using System.Collections.Generic;
using System;
using Nop.Core.Domain.Entity;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class BooksController : BaseAdminController
    {
        #region Fields

        private readonly IBooksService _booksService;
        private readonly IBooksModelFactory _booksModelFactory;
        private readonly IPermissionService _permissionService;
        private readonly INotificationService _notificationService;

        #endregion

        #region Ctor

        public BooksController(IBooksService booksService, IBooksModelFactory booksModelFactory, INotificationService notificationService, IPermissionService permissionService)
        {
            _booksService = booksService;
            _booksModelFactory = booksModelFactory;
            _notificationService = notificationService;
            _permissionService = permissionService;
        }

        #endregion

        #region Books

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual IActionResult List()
        {
            //prepare model
            var model = new BooksSearchModel();

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult BooksList(BooksSearchModel searchModel)
        {
            //prepare model
            var model = _booksModelFactory.PrepareBooksListModel(searchModel);

            return Json(model);
        }

        public virtual IActionResult Create()
        {
            //prepare model
            var model = _booksModelFactory.PrepareBooksModel(new BooksModel(), null);

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Create(BooksModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Name) && _booksService.GetBookByName(model.Name) != null)
                ModelState.AddModelError(string.Empty, "Book is already exists.");

            if (ModelState.IsValid)
            {
                //fill entity from model
                var books = new Books();//model.ToEntity<Books>();

                books.Name = model.Name;
                books.CreatedOn = DateTime.Now;

                _booksService.InsertBook(books);

                _notificationService.SuccessNotification("The new book has been added successfully.");

                return RedirectToAction("List");
            }

            //prepare model
            model = _booksModelFactory.PrepareBooksModel(model, null, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public virtual IActionResult Edit(int id)
        {
            //try to get a book with the specified id
            var book = _booksService.GetBookById(id);
            if (book == null || book.Deleted)
                return RedirectToAction("List");

            //prepare model
            var model = _booksModelFactory.PrepareBooksModel(null, book);

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Edit(BooksModel model)
        {
            //try to get a book with the specified id
            var book = _booksService.GetBookById(model.Id);
            if (book == null || book.Deleted)
                return RedirectToAction("List");

            if (_booksService.IsBookAlreadyExists(model.Id, model.Name))
                ModelState.AddModelError(string.Empty, "Book is already exists.");

            if (ModelState.IsValid)
            {
                try
                {
                    book.Name = model.Name;
                    _booksService.UpdateBook(book);

                    //return RedirectToAction("Edit", new { id = book.Id });

                    _notificationService.SuccessNotification("The book has been updated successfully.");

                    return RedirectToAction("List");
                }
                catch (Exception exc)
                {
                    _notificationService.ErrorNotification(exc.Message);
                }
            }

            //prepare model
            model = _booksModelFactory.PrepareBooksModel(model, book, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpPost]
        public virtual IActionResult Delete(int id)
        {
            //try to get a book with the specified id
            var book = _booksService.GetBookById(id);
            if (book == null || book.Deleted)
                return RedirectToAction("List");

            try
            {
                //delete
                _booksService.DeleteBook(book);

                _notificationService.SuccessNotification("The book has been deleted successfully.");

                return RedirectToAction("List");
            }
            catch (Exception exc)
            {
                _notificationService.ErrorNotification(exc.Message);
                return RedirectToAction("Edit", new { id = book.Id });
            }
        }

        #endregion
    }
}
