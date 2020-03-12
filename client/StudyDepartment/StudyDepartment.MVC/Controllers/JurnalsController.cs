using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyDepartment.Server.Context;
using StudyDepartment.Server.Model;

namespace StudyDepartment.MVC.Controllers
{
    public class JurnalsController : Controller
    {
        private readonly StudyDepartmentContext _context;

        public JurnalsController(StudyDepartmentContext context)
        {
            _context = context;
        }

        // GET: Jurnals
        public async Task<IActionResult> Index()
        {
            var studyDepartmentContext = _context.Jurnals.Include(j => j.Mark).Include(j => j.Student).Include(j => j.StudyPlan);
            return View(await studyDepartmentContext.ToListAsync());
        }

        // GET: Jurnals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurnal = await _context.Jurnals
                .Include(j => j.Mark)
                .Include(j => j.Student)
                .Include(j => j.StudyPlan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jurnal == null)
            {
                return NotFound();
            }

            return View(jurnal);
        }

        // GET: Jurnals/Create
        public IActionResult Create()
        {
            ViewData["MarkId"] = new SelectList(_context.Marks, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            ViewData["StudyPlanId"] = new SelectList(_context.StudyPlans, "Id", "Id");
            return View();
        }

        // POST: Jurnals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,StudyPlanId,InTime,Count,MarkId")] Jurnal jurnal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jurnal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarkId"] = new SelectList(_context.Marks, "Id", "Id", jurnal.MarkId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", jurnal.StudentId);
            ViewData["StudyPlanId"] = new SelectList(_context.StudyPlans, "Id", "Id", jurnal.StudyPlanId);
            return View(jurnal);
        }

        // GET: Jurnals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurnal = await _context.Jurnals.FindAsync(id);
            if (jurnal == null)
            {
                return NotFound();
            }
            ViewData["MarkId"] = new SelectList(_context.Marks, "Id", "Id", jurnal.MarkId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", jurnal.StudentId);
            ViewData["StudyPlanId"] = new SelectList(_context.StudyPlans, "Id", "Id", jurnal.StudyPlanId);
            return View(jurnal);
        }

        // POST: Jurnals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,StudyPlanId,InTime,Count,MarkId")] Jurnal jurnal)
        {
            if (id != jurnal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jurnal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JurnalExists(jurnal.Id))
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
            ViewData["MarkId"] = new SelectList(_context.Marks, "Id", "Id", jurnal.MarkId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", jurnal.StudentId);
            ViewData["StudyPlanId"] = new SelectList(_context.StudyPlans, "Id", "Id", jurnal.StudyPlanId);
            return View(jurnal);
        }

        // GET: Jurnals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurnal = await _context.Jurnals
                .Include(j => j.Mark)
                .Include(j => j.Student)
                .Include(j => j.StudyPlan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jurnal == null)
            {
                return NotFound();
            }

            return View(jurnal);
        }

        // POST: Jurnals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jurnal = await _context.Jurnals.FindAsync(id);
            _context.Jurnals.Remove(jurnal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JurnalExists(int id)
        {
            return _context.Jurnals.Any(e => e.Id == id);
        }
    }
}
