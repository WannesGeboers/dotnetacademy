using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotNETacademy.Common.Entities;
using dotNETacademy.ViewModel;
using dotNETacademy.Data.UnitOfWork;
using Microsoft.AspNetCore.Routing;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotNETacademy.Controllers
{
    public class JaarabonnementController : Controller
    {
        public ActionResult Creates(int Id)
        {
            ViewBag.Id = Id;
            return PartialView("_CreateJaarAbonnement");
        }

        private readonly IUnitOfWork _uow;

        public JaarabonnementController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Jaarabonnements
        public async Task<IActionResult> Index(string id)
        {
            var viewmodel = new IndexAbonnementPerKlantViewModel()
            {
                Customer = await _uow.CustomerRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id),
                Jaarabonnementen = await _uow.JaarabonnementRepository.GetAll().Where(x => x.CustomerId == id).OrderByDescending(x => x.Startdatum).ToListAsync(),
                Jaarabonnement = new Jaarabonnement()
                {
                    Startdatum = DateTime.Now,
                    Einddatum = DateTime.Now.AddYears(1),
                    CustomerId = id,
                },
                TypeJaarabonnement = new SelectList(_uow.TypeJaarabonnementRepository.GetAll().ToList(), "Id", "Omschrijving")
            };

            return View(viewmodel);
        }

        // GET: Jaarabonnements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewmodel = new DetailsAbonnementViewModel();
            viewmodel.Jaarabonnement = _uow.JaarabonnementRepository.GetById(id.Value);
            viewmodel.Customer = await _uow.CustomerRepository.GetByStringId(viewmodel.Jaarabonnement.CustomerId);

            if (viewmodel.Jaarabonnement == null)
            {
                return NotFound();
            }

            return View(viewmodel);
        }

        // GET: Jaarabonnements/Create
        public IActionResult Create(string id)
        {
            var viewmodel = new CreateAbonnementViewModel()
            {
                Jaarabonnement = new Jaarabonnement()
                {
                    Startdatum = DateTime.Now,
                    Einddatum = DateTime.Now.AddYears(1),
                    CustomerId = id,
                },
                TypeJaarabonnement = new SelectList(_uow.TypeJaarabonnementRepository.GetAll().ToList(), "Id", "Omschrijving")
            };
            return View(viewmodel);
        }

        // POST: Jaarabonnements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAbonnementViewModel viewModel)
        {
            var v = viewModel;
            if (ModelState.IsValid)
            {
                _uow.JaarabonnementRepository.Create(viewModel.Jaarabonnement);
                _uow.Save();
                return RedirectToAction("Index", "Jaarabonnement", new { id = viewModel.Jaarabonnement.CustomerId });
            }
            viewModel.TypeJaarabonnement = new SelectList(_uow.TypeJaarabonnementRepository.GetAll().ToList(), "Id", "Omschrijving", viewModel.Jaarabonnement.JaarAbonnement );
            return View(viewModel);
        }

        // GET: Jaarabonnements/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jaarabonnement = _uow.JaarabonnementRepository.GetById(id.Value);
            if (jaarabonnement == null)
            {
                return NotFound();
            }
            return View(jaarabonnement);
        }

        // POST: Jaarabonnements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Prijs,Startdatum,Einddatum,CustomerId")] Jaarabonnement jaarabb)
        {
            if (id != jaarabb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.JaarabonnementRepository.Update(id, jaarabb);
                    _uow.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JaarabonnementExists(jaarabb.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Edit));
            }
            return View(jaarabb);
        }

        //// GET: Jaarabonnements/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var jaarabonnement = await _context.Jaarabonnementen
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (jaarabonnement == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(jaarabonnement);
        //}

        //// POST: Jaarabonnements/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var jaarabonnement = await _context.Jaarabonnementen.FindAsync(id);
        //    _context.Jaarabonnementen.Remove(jaarabonnement);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool JaarabonnementExists(int id)
        {
            return _uow.JaarabonnementRepository.GetAll().Any(e => e.Id == id);
        }
    }
}
