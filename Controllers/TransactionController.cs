using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Operation.Models;

namespace CRUD_Operation.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionDbContext _context;

        public TransactionController(TransactionDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
              return _context.Transactions != null ? 
                          View(await _context.Transactions.ToListAsync()) :
                          Problem("Entity set 'TransactionDbContext.Transactions'  is null.");
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transaction/Create
        public IActionResult CreateorEdit(int id)
        {
            if(id == 0)
            {
                return View(new Transaction());
            }
            else
            {
                return View(_context.Transactions.Find(id));
            }
            
        }

        // POST: Transaction/CreateorEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateorEdit([Bind("id,accountHolderName,accountNumber,bankName,amount,date")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                if(transaction.id == 0)
                {
                    transaction.date = DateTime.Now;
                    _context.Add(transaction);
                }
                else
                {
                    _context.Update(transaction);
                }                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

    

        /*// GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }*/

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
