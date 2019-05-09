using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotNETacademy.Common.Entities;
using dotNETacademy.Data;
using dotNETacademy.ViewModel;
using dotNETacademy.Data.UnitOfWork;


namespace dotNETacademy.Controllers
{
    public class DeelnemerController : Controller
    {
        private readonly IUnitOfWork _uow;

        public DeelnemerController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public IActionResult Index_PerCustomer(string id)
        {
            var viewmodel = new ListDeelnemersViewModel();
            viewmodel.Deelnemers =  _uow.DeelnemerRepository.GetAll().Where(x => x.CustomerId == id.ToString()).ToList();
            viewmodel.Customer = _uow.CustomerRepository.GetAll().FirstOrDefault(x => x.Id == id);
            return View(viewmodel);
        }


        // GET: Deelnemer
        public async Task<IActionResult> Admin_Deelnemer()
        {
            var viewmodel = new Admin_DeelnemerViewModel();
            viewmodel.Deelnemers = await _uow.DeelnemerRepository.GetAll().ToListAsync();
            viewmodel.Deelnemer = new Deelnemer();
            return View(viewmodel);
        }

        // GET: Deelnemer/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var viewmodel = new DeelnemerDetailsViewModel();
            viewmodel.Deelnemer = _uow.DeelnemerRepository.GetById(id);
            viewmodel.Customer = await _uow.CustomerRepository.GetByStringId(viewmodel.Deelnemer.CustomerId);

            if (viewmodel.Deelnemer == null)
            {
                return NotFound();
            }

            return View(viewmodel);
        }

        // GET: Deelnemer/Create
        public IActionResult Create()
        {
            var viewmodel = new ListDeelnemersViewModel();
            
            return View(viewmodel);
        }


       // POST: Deelnemer/Create
       // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Voornaam,OpenstaandeCredits,CustomerId")] Deelnemer deelnemer)
        {
            var x = deelnemer.CustomerId;
            if (ModelState.IsValid)
            {
                
                _uow.DeelnemerRepository.Create(deelnemer);
                _uow.Save();
                return RedirectToAction("Index_PerCustomer","Deelnemer", new { @id = deelnemer.CustomerId });
            }
            return View(deelnemer);
        }

        //        // GET: Deelnemer/Edit/5
        //        public async Task<IActionResult> Edit(int id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var deelnemer = await _uow.DeelnemerRepository.GetById(id);
        //            if (deelnemer == null)
        //            {
        //                return NotFound();
        //            }
        //            return View(deelnemer);
        //        }

        //        // POST: Deelnemer/Edit/5
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Voornaam,OpenstaandeCredits")] Deelnemer deelnemer)
        //        {
        //            if (id != deelnemer.Id)
        //            {
        //                return NotFound();
        //            }

        //            if (ModelState.IsValid)
        //            {
        //                try
        //                {
        //                    _context.Update(deelnemer);
        //                    await _context.SaveChangesAsync();
        //                }
        //                catch (DbUpdateConcurrencyException)
        //                {
        //                    if (!DeelnemerExists(deelnemer.Id))
        //                    {
        //                        return NotFound();
        //                    }
        //                    else
        //                    {
        //                        throw;
        //                    }
        //                }
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(deelnemer);
        //        }

        //        // GET: Deelnemer/Delete/5
        //        public async Task<IActionResult> Delete(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var deelnemer = await _context.Deelnemers
        //                .FirstOrDefaultAsync(m => m.Id == id);
        //            if (deelnemer == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(deelnemer);
        //        }

        //        // POST: Deelnemer/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> DeleteConfirmed(int id)
        //        {
        //            var deelnemer = await _context.Deelnemers.FindAsync(id);
        //            _context.Deelnemers.Remove(deelnemer);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }

        //        private bool DeelnemerExists(int id)
        //        {
        //            return _context.Deelnemers.Any(e => e.Id == id);
        //        }
    }
}
