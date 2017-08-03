using System;
using System.Net;
using System.Web.Mvc;
using ASP_Net_RepositoryPattern.DAL;
using ASP_Net_RepositoryPattern.DAL.Implementations;
using ASP_Net_RepositoryPattern.Models;
using ASP_Net_RepositoryPattern.Services;

namespace ASP_Net_RepositoryPattern.Controllers
{
    /// <summary>
    /// The SeriesController should only delegate the calls to the SeriesService and create
    /// approprioate response messages for the errors that can occur during that call.
    /// </summary>
    public class SeriesController : Controller
    {
        private readonly SeriesService _seriesService;

        public SeriesController()
        {
            // TODO UserService should be injected by DI framework
            _seriesService = new SeriesService(new SeriesRepository(new SeriesReminderContext()));
        }

        // GET: Series
        public ActionResult Index()
        {
            return View(_seriesService.GetAllSeries());
        }

        // GET: Series/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Series series;
            try
            {
                series = _seriesService.GetSeries(id.Value);
            }
            catch (ArgumentException e)
            {
                // Series was not found. Convert the error to appropriate response.
                return HttpNotFound(e.Message);
            }

            return View(series);
        }

        // GET: Series/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Season,Episode")] Series series)
        {
            if (ModelState.IsValid)
            {
                _seriesService.InsertSeries(series);
                return RedirectToAction("Index");
            }

            return View(series);
        }

        // GET: Series/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Series series;
            try
            {
                series = _seriesService.GetSeries(id.Value);
            }
            catch (ArgumentException e)
            {
                // Series was not found. Convert the error to appropriate response.
                return HttpNotFound(e.Message);
            }

            return View(series);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Season,Episode")] Series series)
        {
            if (ModelState.IsValid)
            {
                _seriesService.UpdateSeries(series);

                return RedirectToAction("Index");
            }
            return View(series);
        }

        // GET: Series/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Series series;
            try
            {
                series = _seriesService.GetSeries(id.Value);
            }
            catch (ArgumentException e)
            {
                // Series was not found. Convert the error to appropriate response.
                return HttpNotFound(e.Message);
            }

            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _seriesService.DeleteSeries(id);
            return RedirectToAction("Index");
        }
    }
}
