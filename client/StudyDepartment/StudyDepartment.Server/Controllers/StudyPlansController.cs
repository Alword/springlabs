using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyDepartment.Server.Context;
using StudyDepartment.Server.Model;

namespace StudyDepartment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyPlansController : ControllerBase
    {
        private readonly StudyDepartmentContext _context;

        public StudyPlansController(StudyDepartmentContext context)
        {
            _context = context;
        }

        // GET: api/StudyPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyPlan>>> GetStudyPlans()
        {
            return await _context.StudyPlans.ToListAsync();
        }

        // GET: api/StudyPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudyPlan>> GetStudyPlan(int id)
        {
            var studyPlan = await _context.StudyPlans.FindAsync(id);

            if (studyPlan == null)
            {
                return NotFound();
            }

            return studyPlan;
        }

        // PUT: api/StudyPlans/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudyPlan(int id, StudyPlan studyPlan)
        {
            if (id != studyPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(studyPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyPlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudyPlans
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudyPlan>> PostStudyPlan(StudyPlan studyPlan)
        {
            _context.StudyPlans.Add(studyPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudyPlan", new { id = studyPlan.Id }, studyPlan);
        }

        // DELETE: api/StudyPlans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudyPlan>> DeleteStudyPlan(int id)
        {
            var studyPlan = await _context.StudyPlans.FindAsync(id);
            if (studyPlan == null)
            {
                return NotFound();
            }

            _context.StudyPlans.Remove(studyPlan);
            await _context.SaveChangesAsync();

            return studyPlan;
        }

        private bool StudyPlanExists(int id)
        {
            return _context.StudyPlans.Any(e => e.Id == id);
        }
    }
}
