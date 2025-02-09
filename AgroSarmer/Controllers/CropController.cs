using Microsoft.AspNetCore.Mvc;
using AgroSarmer.Models;
using AgroSarmer.Data;
using Microsoft.EntityFrameworkCore;

public class CropController : Controller
{
    private readonly ApplicationDbContext _context;

    public CropController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Crop
    public async Task<IActionResult> Index()
    {
        return View(await _context.Crops.ToListAsync());
    }

    // GET: Crop/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var crop = await _context.Crops
            .FirstOrDefaultAsync(m => m.Id == id);
        if (crop == null)
        {
            return NotFound();
        }

        return View(crop);
    }

    // GET: Crop/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Crop/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description")] Crop crop)
    {
        if (ModelState.IsValid)
        {
            _context.Add(crop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(crop);
    }

    // GET: Crop/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var crop = await _context.Crops.FindAsync(id);
        if (crop == null)
        {
            return NotFound();
        }
        return View(crop);
    }

    // POST: Crop/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Crop crop)
    {
        if (id != crop.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(crop);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CropExists(crop.Id))
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
        return View(crop);
    }

    // GET: Crop/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var crop = await _context.Crops
            .FirstOrDefaultAsync(m => m.Id == id);
        if (crop == null)
        {
            return NotFound();
        }

        return View(crop);
    }

    // POST: Crop/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var crop = await _context.Crops.FindAsync(id);
        _context.Crops.Remove(crop);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CropExists(int id)
    {
        return _context.Crops.Any(e => e.Id == id);
    }
}

