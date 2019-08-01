using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolExhibition.Data;
using SchoolExhibition.Models;

namespace SchoolExhibition.Controllers
{
    public class StudentMastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentMasters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentMasters.Include(s => s.ClassMaster);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMaster = await _context.StudentMasters
                .Include(s => s.ClassMaster)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (studentMaster == null)
            {
                return NotFound();
            }

            return View(studentMaster);
        }

        // GET: StudentMasters/Create
        public IActionResult Create()
        {
            ViewData["ClassMasterID"] = new SelectList(_context.ClassMasters, "ID", "ClassName");
            return View();
        }

        // POST: StudentMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ClassMasterID")] StudentMaster studentMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassMasterID"] = new SelectList(_context.ClassMasters, "ID", "ClassName", studentMaster.ClassMasterID);
            return View(studentMaster);
        }

        // GET: StudentMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMaster = await _context.StudentMasters.SingleOrDefaultAsync(m => m.ID == id);
            if (studentMaster == null)
            {
                return NotFound();
            }
            ViewData["ClassMasterID"] = new SelectList(_context.ClassMasters, "ID", "ClassName", studentMaster.ClassMasterID);
            return View(studentMaster);
        }

        // POST: StudentMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ClassMasterID")] StudentMaster studentMaster)
        {
            if (id != studentMaster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentMasterExists(studentMaster.ID))
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
            ViewData["ClassMasterID"] = new SelectList(_context.ClassMasters, "ID", "ClassName", studentMaster.ClassMasterID);
            return View(studentMaster);
        }

        // GET: StudentMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMaster = await _context.StudentMasters
                .Include(s => s.ClassMaster)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (studentMaster == null)
            {
                return NotFound();
            }

            return View(studentMaster);
        }

        // POST: StudentMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentMaster = await _context.StudentMasters.SingleOrDefaultAsync(m => m.ID == id);
            _context.StudentMasters.Remove(studentMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentMasterExists(int id)
        {
            return _context.StudentMasters.Any(e => e.ID == id);
        }
    }
}
