using departamentomunicipio.Models;
using departamentomunicipioAPP.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace departamentomunicipioAPP.Controllers
{
    public class MunicipioController : Controller
    {
        private ConsumoAPI _consumoapi = new ConsumoAPI();

        // GET: MunicipioController
        public async Task<IActionResult> Index()
        {
            var municipios = await _consumoapi.GetMunicipiosAsync();
            return View(municipios);
        }

        //Metodo llenado de ddl Departamento
        public async Task<JsonResult> ObtenerDepartamento(int id)
        {
            var departamento = await _consumoapi.GetDepartamentoPorIDAsync(id);
            return Json(departamento);
        }

        // GET: MunicipioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var municipio = await _consumoapi.GetMunicipioPorIDAsync(id);            
            return View(municipio);
        }

        // GET: MunicipioController/Create
        public async Task<IActionResult> Create()
        {
            var municipio = new Municipio();
            var departamentos = await _consumoapi.GetDepartamentosAsync();
            departamentos.Add(new Departamento() { Id = 0, Name = "" });
            ViewBag.Departamentos = new SelectList(departamentos.OrderBy(x => x.Name), "Id", "Name");
            return View(municipio);
        }

        // POST: MunicipioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Municipio model)
        {
            try
            {
                var municipio = await _consumoapi.PostMunicipio(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MunicipioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var municipio = await _consumoapi.GetMunicipioPorIDAsync(id);
            var departamentos = await _consumoapi.GetDepartamentosAsync();

            departamentos = departamentos.Where(x => x.Id == id).ToList();
            ViewBag.Departamentos = new SelectList(departamentos.OrderBy(x => x.Name), "Id", "Name", municipio.DepartamentoId);

            return View(municipio);
        }

        // POST: MunicipioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Municipio model)
        {
            try
            {
                var municipio = await _consumoapi.PutMunicipio(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MunicipioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MunicipioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
