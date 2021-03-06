﻿using LezizSofralar.Models;
using LezizSofralar.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LezizSofralar.Controllers
{
    public abstract class StandardGenericController<TListViewModel, TViewModel, TEntity> : Controller
        where TListViewModel : ListViewModel
        where TViewModel : BaseViewModel
    {
        // GET: StandardGeneric
        public ActionResult Index(int? page, int? pageSize)
        {
            IEnumerable<TEntity> dbItems = GetDataset();

            //filtering

            //authorisation

            //slapper mapping
            List<TListViewModel> model = new List<TListViewModel>();

            if (dbItems != null && dbItems.Count() > 0)
                model = ProjectToListViewModel(dbItems);
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize.HasValue ? pageSize.Value : 10));
        }

        public abstract string EntityName();

        public int CurrentUser()
        {
            //TO DO Authentication
            return 0;
        }

        public abstract IEnumerable<TEntity> GetDataset();

        public abstract List<TListViewModel> ProjectToListViewModel(IEnumerable<TEntity> dbItems);

        public ActionResult Details(int id)
        {
            TViewModel model;
            TEntity dbItem = GetItem(id);
            model = ProjectToViewModel(dbItem);

            return View(model);
        }

        public abstract TEntity GetItem(int id);

        public abstract TViewModel ProjectToViewModel(TEntity dbItem);

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Read(int PageSize, int PageNumber)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TViewModel model)
        {
            try
            {
                model.DateCreated = DateTime.Now;
                model.DateUpdated = DateTime.Now;
                long uid = ProjectInsertToEntity(model);


              //  LogChangeSave(CurrentUser(), EntityName(), "Add", DateTime.Now);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            TViewModel model;
            var dbItem = GetItem(id);
            model = ProjectToViewModel(dbItem);
            
            return View(model);
        }

        public abstract long ProjectInsertToEntity(TViewModel model);

        [HttpPost]
        public ActionResult Edit(int id, TViewModel model)
        {
            try
            {
                model.DateUpdated = DateTime.Now;
                var dbItem = GetItem(id);
                long uid = ProjectUpdateToEntity(dbItem, model);
            //    LogChangeSave(CurrentUser(), EntityName(), "Update", DateTime.Now);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public abstract long ProjectUpdateToEntity(TEntity dbItem, TViewModel model);

        public ActionResult Delete(int id)
        {
            TViewModel model;
            var dbItem = GetItem(id);
            model = ProjectToViewModel(dbItem);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bool isTrue = ProjectDeleteToEntity(id);
                if (isTrue)
                {
                    LogChangeSave(CurrentUser(), EntityName(), "Delete", DateTime.Now);
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        public abstract bool ProjectDeleteToEntity(int ID);

        public void LogChangeSave(int UserID, string Entity, string Operation, System.DateTime EventDate)
        {
            Current.DbInit.LogChange.Insert(
                new
                {
                    UserID = UserID,
                    Entity = Entity,
                    Operation = Operation,
                    EventDate = EventDate
                });
        }
    }
}