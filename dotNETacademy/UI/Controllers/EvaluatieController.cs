using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotNETacademy.Data;
using dotNETacademy.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using dotNETacademy.Models.Objecten;
using dotNETacademy.ViewModel;
using dotNETacademy.Common.Entities;

namespace dotNETacademy.Controllers
{
    public class EvaluatieController : Controller
    {
        //file upload
        private IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;
        public EvaluatieController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Evaluatie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Evaluatie.ToListAsync());
        }

        public async Task<IActionResult> Index_PerDeelnemer(int id)
        {
            return View(await _context.Evaluatie
                .Where(x => x.Deelnemer.Id == id)
                .OrderByDescending(x => x.Datum)
                .ToListAsync());
        }

        // GET: Evaluatie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluatie = await _context.Evaluatie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluatie == null)
            {
                return NotFound();
            }
            return View(evaluatie);
        }

        // GET: Evaluatie/Create
        public IActionResult Create(int id)
        {
            var viewmodel = new CreateEvaluatie();
            viewmodel.Evaluatie = new Evaluatie() {                
                DeelnemerId = id };            
            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEvaluatie model)
        {
            if (ModelState.IsValid)
            {                          
                if (model.Bestand != null)
                {
                    var deelnemer = _context.Deelnemers.Where(x => x.Id == model.Evaluatie.DeelnemerId).First();

                    //maak unieke naam voor bestand
                    string uniqueFileName =
                        deelnemer.Naam +
                        deelnemer.Voornaam +
                        "_Evaluatie" +
                        deelnemer.Evaluaties.Count.ToString() +
                        Path.GetExtension(model.Bestand.FileName);
                     //sla bestand op in project
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "bestanden/evaluaties");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    using (FileStream writer = new FileStream(filePath, FileMode.Create))
                    {
                        model.Bestand.CopyTo(writer);
                    }
                    model.Evaluatie.BestandLocatie = uniqueFileName;
                }                
                _context.Add(model.Evaluatie);
                await _context.SaveChangesAsync();
                
                //Ga naar index van Evaluaties van deelnemer
                return RedirectToAction(
              "Index_PerDeelnemer", // Action name    
              "Evaluatie", // Controller name
              new { id = model.Evaluatie.DeelnemerId }); // Route values
            }
            else return NotFound();
        }

        [HttpGet]
        public FileResult Download(string id)
        {
            var fileName = id;
            var filepath = Path.Combine(_hostingEnvironment.WebRootPath, "bestanden/evaluaties", fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "application/x-msdownload", fileName);
        }

        // GET: Evaluatie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluatie = await _context.Evaluatie.FindAsync(id);
            if (evaluatie == null)
            {
                return NotFound();
            }
            return View(evaluatie);
        }

        // POST: Evaluatie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,Omschrijving,Punt")] Evaluatie evaluatie)
        {
            if (id != evaluatie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluatie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluatieExists(evaluatie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(evaluatie);
        }

        // GET: Evaluatie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluatie = await _context.Evaluatie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evaluatie == null)
            {
                return NotFound();
            }

            return View(evaluatie);
        }

        // POST: Evaluatie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluatie = await _context.Evaluatie.FindAsync(id);
            _context.Evaluatie.Remove(evaluatie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluatieExists(int id)
        {
            return _context.Evaluatie.Any(e => e.Id == id);
        }               
    }
}
