using departamentomunicipioAPP.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace departamentomunicipioAPP.Controllers
{
    public class DepartamentoController : Controller
    {
        private ConsumoAPI consumoAPI = new ConsumoAPI();

        // GET: DepartamentoController
        public async Task<IActionResult> Index()
        {
            var departamentos = await consumoAPI.GetDepartamentosAsync();
            return View(departamentos);
        }

        // GET: DepartamentoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var departamento = await consumoAPI.GetDepartamentoPorIDAsync(id);
            return View(departamento);
        }

        // GET: DepartamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DepartamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartamentoController/Edit/5
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

        // GET: DepartamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartamentoController/Delete/5
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
