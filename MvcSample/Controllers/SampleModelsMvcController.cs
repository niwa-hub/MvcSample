using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSample.Data;
using MvcSample.Models;

namespace MvcSample.Controllers
{
    public class SampleModelsMvcController : Controller
    {
        private readonly MvcSampleContext _context;

        public SampleModelsMvcController(MvcSampleContext context)
        {
            _context = context;
        }

        // GET: SampleModelsMvc
        public async Task<IActionResult> Index()
        {
            return View(await _context.SampleModel.ToListAsync());
        }

        // GET: SampleModelsMvc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleModel = await _context.SampleModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sampleModel == null)
            {
                return NotFound();
            }

            return View(sampleModel);
        }

        // GET: SampleModelsMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SampleModelsMvc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreateTime,Sex,Age")] SampleModel sampleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sampleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sampleModel);
        }

        // GET: SampleModelsMvc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleModel = await _context.SampleModel.FindAsync(id);
            if (sampleModel == null)
            {
                return NotFound();
            }
            return View(sampleModel);
        }

        // POST: SampleModelsMvc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreateTime,Sex,Age")] SampleModel sampleModel)
        {
            if (id != sampleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sampleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleModelExists(sampleModel.Id))
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
            return View(sampleModel);
        }

        // GET: SampleModelsMvc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleModel = await _context.SampleModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sampleModel == null)
            {
                return NotFound();
            }

            return View(sampleModel);
        }

        // POST: SampleModelsMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sampleModel = await _context.SampleModel.FindAsync(id);
            _context.SampleModel.Remove(sampleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SampleModelExists(int id)
        {
            return _context.SampleModel.Any(e => e.Id == id);
        }
    }
}
