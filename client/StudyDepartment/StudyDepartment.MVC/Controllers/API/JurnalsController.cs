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
    public class JurnalsController : ControllerBase
    {
        private readonly StudyDepartmentContext _context;

        public JurnalsController(StudyDepartmentContext context)
        {
            _context = context;
        }

        // GET: api/Jurnals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jurnal>>> GetJurnals()
        {
            return await _context.Jurnals.ToListAsync();
        }

        // GET: api/Jurnals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jurnal>> GetJurnal(int id)
        {
            var jurnal = await _context.Jurnals.FindAsync(id);

            if (jurnal == null)
            {
                return NotFound();
            }

            return jurnal;
        }

        // PUT: api/Jurnals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJurnal(int id, Jurnal jurnal)
        {
            if (id != jurnal.Id)
            {
                return BadRequest();
            }

            _context.Entry(jurnal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JurnalExists(id))
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

        // POST: api/Jurnals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Jurnal>> PostJurnal(Jurnal jurnal)
        {
            _context.Jurnals.Add(jurnal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJurnal", new { id = jurnal.Id }, jurnal);
        }

        // DELETE: api/Jurnals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Jurnal>> DeleteJurnal(int id)
        {
            var jurnal = await _context.Jurnals.FindAsync(id);
            if (jurnal == null)
            {
                return NotFound();
            }

            _context.Jurnals.Remove(jurnal);
            await _context.SaveChangesAsync();

            return jurnal;
        }

        private bool JurnalExists(int id)
        {
            return _context.Jurnals.Any(e => e.Id == id);
        }
    }
}
