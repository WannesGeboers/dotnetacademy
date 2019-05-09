using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using dotNETacademy.Data.UnitOfWork;
using dotNETacademy.Models.Enum;
using dotNETacademy.ViewModel;
using dotNETacademy.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotNETacademy.Controllers
{
    public class AdminController : Controller
    {

        private readonly IUnitOfWork _uow;

        public AdminController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        // Info page (GET)
        public async Task<IActionResult> Index()
        {
            var viewModel = new Admin_IndexViewModel();
            viewModel.Titel = "Overzicht";
            viewModel.lijstCustomers = await _uow.CustomerRepository.GetAll().ToListAsync();
            viewModel.MaandenInJaar = Enum.GetNames(typeof(MaandenInJaar));
            viewModel.lijstJaarabonnementenInHuidigJaar = await _uow.JaarabonnementRepository.GetAll().Where(x => x.Startdatum.Year.Equals(DateTime.Now.Year)).Include(x => x.JaarAbonnement).ToListAsync();
            viewModel.lijstJaarabonnementenInHuidigJaar.OrderBy(x => x.Startdatum);
            viewModel.TotaalBrons = 0;
            viewModel.TotaalGoud = 0;
            viewModel.TotaalZilver = 0;
            viewModel.TotaalPrijs = 0;

            foreach (var item in viewModel.lijstJaarabonnementenInHuidigJaar)
            {
                if (item.JaarAbonnement.Omschrijving.Equals("Bronze"))
                {
                    viewModel.TotaalBrons += item.Prijs;
                }
                else if (item.JaarAbonnement.Omschrijving.Equals("Silver"))
                {
                    viewModel.TotaalZilver += item.Prijs;
                }
                else if (item.JaarAbonnement.Omschrijving.Equals("Gold"))
                {
                    viewModel.TotaalGoud += item.Prijs;
                }
            }
            viewModel.TotaalPrijs = viewModel.TotaalBrons + viewModel.TotaalZilver + viewModel.TotaalGoud;

            return View(viewModel);
        }

        public IActionResult Default()
        {
            var viewmodel = new Admin_DefaultViewModel();
            viewmodel.Credit = _uow.CreditRepository.GetById(1);

            return View(viewmodel);
        }

        public async Task<IActionResult> Admin_Customers()
        {
            var viewmodel = new Admin_CustomersViewModel();
            viewmodel.Customer = new Customer();
            viewmodel.Customers = await _uow.CustomerRepository.GetAll().Where(x => x.Bedrijfsnaam.ToUpper() != "BITCONSULT").ToListAsync();
            return View(viewmodel);
        }
    }
}
