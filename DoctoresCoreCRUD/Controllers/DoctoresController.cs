using DoctoresCoreCRUD.Data;
using DoctoresCoreCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctoresCoreCRUD.Controllers
{
    public class DoctoresController : Controller
    {
        DoctoresContext context;

        public DoctoresController(DoctoresContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Doctor> doctores = this.context.GetDoctores();
            return View(doctores);
        }

        public IActionResult Details(int doctorno)
        {
            Doctor doctor = this.context.GetDoctor(doctorno);
            return View(doctor);
        }

        public IActionResult Edit(int doctorno)
        {
            Doctor doctor = this.context.GetDoctor(doctorno);
            return View(doctor);
        }

        [HttpPost]
        public IActionResult Edit(int doctorno, int salario, string apellido, string especialidad)
        {
            this.context.UpdateDoctor(doctorno, salario, apellido, especialidad);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int doctorno)
        {
            this.context.DeleteDoctor(doctorno);
            return RedirectToAction("Index");
        }

    }
}
