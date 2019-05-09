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
using dotNETacademy.Areas.Identity.Data;

namespace dotNETacademy.Controllers
{
    public class CreditController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CreditController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //// GET: Credit
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Credits.ToListAsync());
        //}

        //// GET: Credit/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var credit = await _context.Credits
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (credit == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(credit);
        //}

        //// GET: Credit/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Credit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,PrijsPerCredit")] Credit credit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(credit);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(credit);
        //}

        // GET: Credit/Edit/5
        public async Task<IActionResult> EditDefault(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var credit = await _uow.CreditRepository.GetAll().FirstOrDefaultAsync();
            if (credit == null)
            {
                return NotFound();
            }
            return View(credit);
        }

        // POST: Credit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDefault(int id, [Bind("Id,PrijsPerCredit")] Credit credit)
        {
            if (id != credit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.CreditRepository.Update(id, credit);
                    _uow.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditExists(credit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EditDefault));
            }
            return View(credit);
        }

        //edit customer credits (GET)
        public async Task<IActionResult> EditCustomer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var viewModel = new CustomerCreditsViewModel()
            {
                Customer = await _uow.CustomerRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id)
            };

            return View(viewModel);
        }

        //edit customer credits (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomer(string id, CustomerCreditsViewModel viewModel)
        {
            if (id != viewModel.Customer.Id)
            {
                return NotFound();
            }

            Customer cust = _uow.CustomerRepository.GetAll().FirstOrDefault(x => x.Id == id);
            cust.HuidigeCredits = viewModel.Customer.HuidigeCredits;

            try
            {
                _uow.CustomerRepository.UpdateByStringId(id, cust);
                _uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return View(viewModel);
            }
            return RedirectToAction("EditCustomer", "Credit", new {id = viewModel.Customer.Id });
        }







        //// GET: Credit/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var credit = await _context.Credits
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (credit == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(credit);
        //}

        //// POST: Credit/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var credit = await _context.Credits.FindAsync(id);
        //    _context.Credits.Remove(credit);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CreditExists(int id)
        {
            return _uow.CreditRepository.GetAll().Any(e => e.Id == id);
        }
    }
}
