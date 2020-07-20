using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoHw.Models;

namespace ToDoHw.Controllers
{
    public class ToDosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToDos
        public ActionResult Index()
        {
            return View(db.ToDoClasses.ToList());
        }

        // GET: ToDos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoClass toDoClass = db.ToDoClasses.Find(id);
            if (toDoClass == null)
            {
                return HttpNotFound();
            }
            return View(toDoClass);
        }

        // GET: ToDos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Priority,DeadLine")] ToDoClass toDoClass)
        {
            if (ModelState.IsValid)
            {
                db.ToDoClasses.Add(toDoClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDoClass);
        }

        // GET: ToDos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoClass toDoClass = db.ToDoClasses.Find(id);
            if (toDoClass == null)
            {
                return HttpNotFound();
            }
            return View(toDoClass);
        }

        // POST: ToDos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Priority,DeadLine")] ToDoClass toDoClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDoClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoClass);
        }

        // GET: ToDos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoClass toDoClass = db.ToDoClasses.Find(id);
            if (toDoClass == null)
            {
                return HttpNotFound();
            }
            return View(toDoClass);
        }

        // POST: ToDos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoClass toDoClass = db.ToDoClasses.Find(id);
            db.ToDoClasses.Remove(toDoClass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
