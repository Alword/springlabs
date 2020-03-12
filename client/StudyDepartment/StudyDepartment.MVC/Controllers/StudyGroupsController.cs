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
    public class StudyGroupsController : Controller
    {
        private readonly StudyDepartmentContext _context;

        public StudyGroupsController(StudyDepartmentContext context)
        {
            _context = context;
        }

        // GET: StudyGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudyGroups.ToListAsync());
        }

        // GET: StudyGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyGroup = await _context.StudyGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyGroup == null)
            {
                return NotFound();
            }

            return View(studyGroup);
        }

        // GET: StudyGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudyGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StudyGroup studyGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studyGroup);
        }

        // GET: StudyGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyGroup = await _context.StudyGroups.FindAsync(id);
            if (studyGroup == null)
            {
                return NotFound();
            }
            return View(studyGroup);
        }

        // POST: StudyGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StudyGroup studyGroup)
        {
            if (id != studyGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyGroupExists(studyGroup.Id))
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
            return View(studyGroup);
        }

        // GET: StudyGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyGroup = await _context.StudyGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyGroup == null)
            {
                return NotFound();
            }

            return View(studyGroup);
        }

        // POST: StudyGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyGroup = await _context.StudyGroups.FindAsync(id);
            _context.StudyGroups.Remove(studyGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyGroupExists(int id)
        {
            return _context.StudyGroups.Any(e => e.Id == id);
        }
    }
}
