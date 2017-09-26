﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SlackerRank_preAlpha.Data;
using SlackerRank_preAlpha.Models;

namespace SlackerRank_preAlpha.Controllers
{
    public class TeacherCodeModelsController : Controller
    {
        private readonly MyDbContext _context;

        public TeacherCodeModelsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TeacherCodeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeacherCode.ToListAsync());
        }

        // GET: TeacherCodeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherCodeModel = await _context.TeacherCode
                .SingleOrDefaultAsync(m => m.Id == id);
            if (teacherCodeModel == null)
            {
                return NotFound();
            }

            return View(teacherCodeModel);
        }

        // GET: TeacherCodeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherCodeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodeIntro,CodeSolution,CodeExe,CodePath")] TeacherCodeModel teacherCodeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherCodeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherCodeModel);
        }

        // GET: TeacherCodeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherCodeModel = await _context.TeacherCode.SingleOrDefaultAsync(m => m.Id == id);
            if (teacherCodeModel == null)
            {
                return NotFound();
            }
            return View(teacherCodeModel);
        }

        // POST: TeacherCodeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodeIntro,CodeSolution,CodeExe,CodePath")] TeacherCodeModel teacherCodeModel)
        {
            if (id != teacherCodeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherCodeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherCodeModelExists(teacherCodeModel.Id))
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
            return View(teacherCodeModel);
        }

        // GET: TeacherCodeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherCodeModel = await _context.TeacherCode
                .SingleOrDefaultAsync(m => m.Id == id);
            if (teacherCodeModel == null)
            {
                return NotFound();
            }

            return View(teacherCodeModel);
        }

        // POST: TeacherCodeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherCodeModel = await _context.TeacherCode.SingleOrDefaultAsync(m => m.Id == id);
            _context.TeacherCode.Remove(teacherCodeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherCodeModelExists(int id)
        {
            return _context.TeacherCode.Any(e => e.Id == id);
        }
    }
}