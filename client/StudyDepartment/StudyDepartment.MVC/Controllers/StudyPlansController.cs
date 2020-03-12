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
    public class StudyPlansController : Controller
    {
        private readonly StudyDepartmentContext _context;

        public StudyPlansController(StudyDepartmentContext context)
        {
            _context = context;
        }

        // GET: StudyPlans
        public async Task<IActionResult> Index()
        {
            var studyDepartmentContext = _context.StudyPlans.Include(s => s.ExamType).Include(s => s.Subject);
            return View(await studyDepartmentContext.ToListAsync());
        }

        // GET: StudyPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _context.StudyPlans
                .Include(s => s.ExamType)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyPlan == null)
            {
                return NotFound();
            }

            return View(studyPlan);
        }

        // GET: StudyPlans/Create
        public IActionResult Create()
        {
            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id");
            return View();
        }

        // POST: StudyPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectId,ExamTypeId")] StudyPlan studyPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "Id", "Id", studyPlan.ExamTypeId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", studyPlan.SubjectId);
            return View(studyPlan);
        }

        // GET: StudyPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _context.StudyPlans.FindAsync(id);
            if (studyPlan == null)
            {
                return NotFound();
            }
            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "Id", "Id", studyPlan.ExamTypeId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", studyPlan.SubjectId);
            return View(studyPlan);
        }

        // POST: StudyPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubjectId,ExamTypeId")] StudyPlan studyPlan)
        {
            if (id != studyPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyPlanExists(studyPlan.Id))
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
            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "Id", "Id", studyPlan.ExamTypeId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", studyPlan.SubjectId);
            return View(studyPlan);
        }

        // GET: StudyPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _context.StudyPlans
                .Include(s => s.ExamType)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyPlan == null)
            {
                return NotFound();
            }

            return View(studyPlan);
        }

        // POST: StudyPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyPlan = await _context.StudyPlans.FindAsync(id);
            _context.StudyPlans.Remove(studyPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyPlanExists(int id)
        {
            return _context.StudyPlans.Any(e => e.Id == id);
        }
    }
}
