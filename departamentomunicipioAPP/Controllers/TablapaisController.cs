using departamentomunicipio.Models;
using departamentomunicipioAPP.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace departamentomunicipioAPP.Controllers
{
    public class TablapaisController : Controller
    {
        private readonly ConsumoAPI _consumoAPI = new ConsumoAPI();
        // GET: TablapaisController
        public async Task<IActionResult> Index()
        {
            var tpaises = await _consumoAPI.GetTablapaisesAsync();
            return View(tpaises);
        }

        // GET: TablapaisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<JsonResult> getddlMunicipios(int id)
        {
            var municipios = await _consumoAPI.GetMunicipioPorDepartamento(id);
            return Json(municipios); 
        }

        // GET: TablapaisController/Create
        public async Task<IActionResult> Create()
        {
            var tpais = new Tablapai();
            var departamentos = await _consumoAPI.GetDepartamentosAsync();
            departamentos.Add(new Departamento(){ Id = 0, Name = "" });
            ViewBag.Departamentos = new SelectList(departamentos.OrderBy(x => x.Name), "Id", "Name");
            return View(tpais);
        }

        // POST: TablapaisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tablapai model)
        {
            try
            {
                var pais = await _consumoAPI.PostTablapaises(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TablapaisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TablapaisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: TablapaisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TablapaisController/Delete/5
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
