using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteCandidatoWEB.Data;
using TesteCandidatoWEB.Models;

namespace TesteCandidatoWEB.Controllers
{
    public class CEPController :  Controller
    {
        private readonly AppDbContext _context;

        public CEPController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cep
        public async Task<IActionResult> Index(string uf)
        {
            var ceps = from c in _context.Ceps select c;

            if (!string.IsNullOrEmpty(uf))
            {
                ceps = ceps.Where(c => c.Uf.ToUpper() == uf.ToUpper());
            }

            return View(await ceps.ToListAsync());
        }

        // GET: Cep/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cep/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroCep,Logradouro,Complemento,Bairro,Localidade,Uf,Unidade,Ibge,Gia")] CEP cep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cep);
        }
    }
}
