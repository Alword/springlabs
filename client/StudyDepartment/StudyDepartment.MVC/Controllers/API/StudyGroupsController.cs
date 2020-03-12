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
    public class StudyGroupsController : ControllerBase
    {
        private readonly StudyDepartmentContext _context;

        public StudyGroupsController(StudyDepartmentContext context)
        {
            _context = context;
        }

        // GET: api/StudyGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyGroup>>> GetStudyGroups()
        {
            return await _context.StudyGroups.ToListAsync();
        }

        // GET: api/StudyGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudyGroup>> GetStudyGroup(int id)
        {
            var studyGroup = await _context.StudyGroups.FindAsync(id);

            if (studyGroup == null)
            {
                return NotFound();
            }

            return studyGroup;
        }

        // PUT: api/StudyGroups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudyGroup(int id, StudyGroup studyGroup)
        {
            if (id != studyGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(studyGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyGroupExists(id))
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

        // POST: api/StudyGroups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudyGroup>> PostStudyGroup(StudyGroup studyGroup)
        {
            _context.StudyGroups.Add(studyGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudyGroup", new { id = studyGroup.Id }, studyGroup);
        }

        // DELETE: api/StudyGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudyGroup>> DeleteStudyGroup(int id)
        {
            var studyGroup = await _context.StudyGroups.FindAsync(id);
            if (studyGroup == null)
            {
                return NotFound();
            }

            _context.StudyGroups.Remove(studyGroup);
            await _context.SaveChangesAsync();

            return studyGroup;
        }

        private bool StudyGroupExists(int id)
        {
            return _context.StudyGroups.Any(e => e.Id == id);
        }
    }
}
