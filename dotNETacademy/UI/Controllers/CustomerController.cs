using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using dotNETacademy.ViewModel;
using System.Linq;
using dotNETacademy.Data.UnitOfWork;
using Microsoft.AspNet.Identity;
using dotNETacademy.Areas.Identity.Data;
using System.Collections.Generic;
using dotNETacademy.Common.Entities;

namespace dotNETacademy.Controllers
{
    //LOGGED IN ACCOUNTS ONLY
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CustomerController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // Info page (GET)
        public async Task<IActionResult> Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                //custom user ID ophalen
                string userId = User.Identity.GetUserId();

                var jaarabbo = await _uow.JaarabonnementRepository.GetAll().Where(x => x.CustomerId == userId).ToListAsync();

                var viewModel = new CustomerInfoViewModel()
                {
                    Customer = await _uow.CustomerRepository.GetAll().Where(x => x.Id == userId).FirstOrDefaultAsync(),
                    Deelnemers = await _uow.DeelnemerRepository.GetAll().Where(d => d.CustomerId == userId).ToListAsync(),
                    AantalDeelnemers = await _uow.DeelnemerRepository.GetAll().Where(d => d.CustomerId == userId).CountAsync(),
                    Jaarabonnement = await _uow.JaarabonnementRepository.GetAll().Where(j => j.CustomerId == userId).OrderByDescending(j => j.Startdatum).FirstAsync(),
                    AantalFacturen = jaarabbo.Select(x => x.Facturen).Count(),
                    //TotaalBedragFacturen = await _uow.FactuurRepository.GetAll().Where(f => f.CustomerId == UserId).SumAsync(f => f.Prijs),
                    HuidigeCredits = await _uow.CustomerRepository.GetAll().Where(j => j.Id == userId).Select(f => f.HuidigeCredits).FirstOrDefaultAsync()
                };
                return View(viewModel);
            }
            else
            {
                //gegevens van gevraagde customer ophalen
                var viewModel = new CustomerInfoViewModel();
                viewModel.Customer = await _uow.CustomerRepository.GetAll().Where(x => x.Id == id.ToString()).FirstAsync();
                viewModel.Deelnemers = await _uow.DeelnemerRepository.GetAll().Where(x => x.CustomerId == id.ToString()).ToListAsync();
                viewModel.AantalDeelnemers = viewModel.Deelnemers.Count;
                viewModel.Jaarabonnement = await _uow.JaarabonnementRepository.GetAll().Where(x => x.CustomerId == id).FirstOrDefaultAsync();
                var jaarabbo = await _uow.JaarabonnementRepository.GetAll().Where(d => d.CustomerId == id).ToListAsync();
                viewModel.AantalFacturen = jaarabbo.Select(x => x.Facturen).Count();
                viewModel.HuidigeCredits = viewModel.Customer.HuidigeCredits;

                return View(viewModel);
            }
        }

        // All Deelnemers (GET)
        public async Task<IActionResult> Deelnemers()
        {
            var viewModel = new ListDeelnemersViewModel()
            {
                Deelnemers = await _uow.DeelnemerRepository.GetAll().Where(d => d.CustomerId == User.Identity.GetUserId()).OrderBy(d => d.Naam).ToListAsync()
            };
            return View(viewModel);
        }

        // Details Deelnemer (GET)
        public async Task<IActionResult> DetailsDeelnemer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new DeelnemerViewModel()
            {
                Deelnemer = await _uow.DeelnemerRepository.GetAll().FirstOrDefaultAsync(d => d.Id == id)
            };

            if (viewModel.Deelnemer == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // All Facturen (GET)
        public IActionResult Facturatie(string id)
        {
            var viewModel = new ListFacturatieViewModel()
            {
                Facturen = new List<Factuur>()
            };

            //var jaarabb = _uow.CustomerRepository.GetAll().OrderByDescending(x => x.Jaarabonnementen.Select(y => y.Startdatum)).FirstOrDefault();

            viewModel.Facturen = _uow.FactuurRepository.GetAll().ToList();

            //if (id != null)
            //{
            //    viewModel.Facturen = await _uow.FactuurRepository.GetAll().OrderByDescending(f => f.Datum).Where(f => f.IsVereffend == false).ToListAsync();
            //}
            //else
            //{
            //    viewModel.Facturen = await _uow.FactuurRepository.GetAll().OrderByDescending(d => d.Datum).ToListAsync();
            //}

            return View(viewModel);
        }

        // Details Deelnemer (GET)
        public async Task<IActionResult> DetailsFacturatie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new FacturatieViewModel()
            {
                Factuur = await _uow.FactuurRepository.GetAll().FirstOrDefaultAsync(f => f.Id == id)
            };

            if (viewModel.Factuur == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // Edit Customer credits (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomer(string id, CustomerInfoViewModel viewModel)
        {
            if (id != viewModel.Customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.CustomerRepository.UpdateByStringId(id, viewModel.Customer);
                    _uow.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(viewModel);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}
