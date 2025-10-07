using mf_dev_backend_2025.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend_2025.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext context;

        public VeiculosController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var dados = await context.Veiculos.ToListAsync();

            return View(dados);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                context.Veiculos.Add(veiculo);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(veiculo);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await context.Veiculos.FindAsync(id);

            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(veiculo);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult>Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            context.Veiculos.Remove(dados);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
