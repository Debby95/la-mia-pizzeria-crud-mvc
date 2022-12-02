using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        PizzeriaContext db;
        public PizzaController() : base()
        {
            db = new PizzeriaContext();
        }
        public IActionResult Index()
        {
            PizzeriaContext db = new PizzeriaContext();
            List<Pizza> listaPizza = db.Pizzas.ToList();
            return View(listaPizza);
        }

        public IActionResult Dettagli(int id)
        {
            PizzeriaContext db = new PizzeriaContext();
            Pizza pizza = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();
            return View(pizza);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.Pizzas.Add(pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }

        public IActionResult Update(int id)
        {
            Pizza pizza = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();
            if (pizza == null)
            {
                return NotFound();
            }
                
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Update(Pizza pizza)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            db.Pizzas.Update(pizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

            if (pizza == null)
            {
                return NotFound();
            }
            db.Pizzas.Remove(pizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
