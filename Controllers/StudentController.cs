using DemoApp2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        DemoApp2Entities dbobj = new DemoApp2Entities();
        public ActionResult Student(demo2 obj)
        {
            if (obj != null)
                return View(obj);
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddStudent(demo2 model)
        {
            demo2 obj = new demo2();
            if (ModelState.IsValid)
            {
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.FName = model.FName;
                obj.Mobile = model.Mobile;
                obj.Email = model.Email;
                obj.Description = model.Description;

                if (model.ID == 0)
                {
                    dbobj.demo2.Add(obj);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbobj.SaveChanges();


                }

                
            }
            ModelState.Clear();

            return View("Student");
        }

        public ActionResult StudentList() 
        {
            var res = dbobj.demo2.ToList();
            return View(res); 
        }

        public ActionResult Delete(int id)
        {
            var res = dbobj.demo2.Where(x => x.ID == id).First();
            dbobj.demo2.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.demo2.ToList();

            return View("StudentList", list);
        } 

    }
}