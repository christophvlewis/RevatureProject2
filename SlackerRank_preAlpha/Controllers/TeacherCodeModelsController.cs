using System;
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
		// GET: TracherCodeModels/
		public IActionResult Index()
		{
			return View(new TeacherCodeModel().GetListFromDatatabase());
		}

        // GET: TeacherCodeModels/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			var teacherCodeModel = new TeacherCodeModel().GetFromDatabase((int)id);

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
        public IActionResult Create([Bind("Id,CodeIntro,CodeSolution,CodeExe,CodePath")] TeacherCodeModel teacherCodeModel)
        {
            if (ModelState.IsValid)
            {
				teacherCodeModel.AddtoDatabase(teacherCodeModel);
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

			var teacherCodeModel = new TeacherCodeModel().GetFromDatabase((int)id);

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
					var teachcode = new TeacherCodeModel().UpdatetoDatabase(teacherCodeModel);
                    //_context.Update(teacherCodeModel);
                    //await _context.SaveChangesAsync();
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

			var teacherCodeModel = new TeacherCodeModel().GetFromDatabase((int)id);

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
			new TeacherCodeModel().DeletefromDatabase(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherCodeModelExists(int id)
        {
			var exist = new TeacherCodeModel().GetFromDatabase(id);

			if (exist != null) { return true; }
			else { return false; }

        }
    }
}
