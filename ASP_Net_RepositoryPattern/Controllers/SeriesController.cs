using System.Net;
using System.Web.Mvc;
using ASP_Net_RepositoryPattern.DAL;
using ASP_Net_RepositoryPattern.DAL.Implementations;
using ASP_Net_RepositoryPattern.DAL.Interfaces;
using ASP_Net_RepositoryPattern.Models;

namespace ASP_Net_RepositoryPattern.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ISeriesRepository _seriesRepository;

        public SeriesController()
        {
            _seriesRepository = new SeriesRepository(new SeriesReminderContext());   
        }

        // GET: Series
        public ActionResult Index()
        {
            return View(_seriesRepository.Get());
        }

        // GET: Series/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Series series = _seriesRepository.GetById(id.Value);
            if (series == null)
            {
                return HttpNotFound();
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
                _seriesRepository.Insert(series);
                _seriesRepository.Save();
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
            Series series = _seriesRepository.GetById(id.Value);
            if (series == null)
            {
                return HttpNotFound();
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
                _seriesRepository.Update(series);
                _seriesRepository.Save();

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
            Series series = _seriesRepository.GetById(id.Value);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _seriesRepository.Delete(id);
            _seriesRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _seriesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
