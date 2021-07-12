using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VirtualHosp.Context;
using VirtualHosp.Models;
using VirtualHosp.Models.Enums;

namespace VirtualHosp.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly HospitalDbContext _context;
        private static readonly SelectList estado = new SelectList(Enum.GetValues(typeof(Estado)), Estado.CREADO);

        public ConsultasController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var consultas = await _context.Consultas.ToListAsync();
            foreach (var consulta in consultas)
            {
                if (consulta.MedicoId != 0)
                {
                    consulta.Medico = await _context.Medicos.FindAsync(consulta.MedicoId);
                }
                if (consulta.PacienteId != 0)
                {
                    consulta.Paciente = await _context.Pacientes.FindAsync(consulta.PacienteId);
                }
            }
            return View(consultas);
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewBag.Estado = estado;
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Estado,Coseguro,ConsultaDescripcion")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Estado = estado;
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewBag.Estado = estado;
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Estado,Coseguro,ConsultaDescripcion")] Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.Id))
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
            ViewBag.Estado = estado;
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.Id == id);
        }


        public IActionResult AddMedico(int id)
        {
            ConsultaRelations consultaMedico = new ConsultaRelations
            {
                ConsultaId = id
            };
            ViewBag.Medicos = _context.Medicos.ToList();
            return View(consultaMedico);
        }        

        public async Task<IActionResult> AddMedicoSave(ConsultaRelations consultaMedico)
        {
            var consulta = await _context.Consultas.FirstOrDefaultAsync(m => m.Id == consultaMedico.ConsultaId);
            consulta.Medico = await _context.Medicos.FirstOrDefaultAsync(m => m.Id == consultaMedico.MedicoId);

            _context.Update(consulta);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult AddPaciente(int id)
        {
            ConsultaRelations consultaMedico = new ConsultaRelations
            {
                ConsultaId = id
            };
            ViewBag.Pacientes = _context.Pacientes.ToList();
            return View(consultaMedico);
        }

        public async Task<IActionResult> AddPacienteSave(ConsultaRelations consultaPaciente)
        {
            var consulta = await _context.Consultas.FirstOrDefaultAsync(m => m.Id == consultaPaciente.ConsultaId);
            consulta.Paciente = await _context.Pacientes.FirstOrDefaultAsync(m => m.Id == consultaPaciente.PacienteId);

            _context.Update(consulta);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Gestionar(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewBag.Estado = estado;
            return View(consulta);
        }
    }
}
