﻿using PolaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolaHotel.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();


        public ActionResult GetAll()
        {
            List<Customer> Customers = context.customers.ToList();

            return View(Customers);
        }
 

 






        public ActionResult New ()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New( Customer customer)
        {
           


            try
            {
                if(ModelState.IsValid)
                {
                    context.customers.Add(customer);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");

                }
                else
                {

                    return View(customer);
                }
                
                    
               
                

            }catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(customer);
            }

        }

        public ActionResult Edit (int id)
        {
            Customer customer = context.customers.FirstOrDefault(c => c.ID == id);

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer newcustomer)
        {
            Customer customer = context.customers.FirstOrDefault(c => c.ID == newcustomer.ID);
            try
            {
                if(ModelState.IsValid)
                {
                    customer.Name = newcustomer.Name;
                    customer.phone_Number = newcustomer.phone_Number;
                    customer.NationalID = newcustomer.NationalID;
                    customer.Nationality = newcustomer.Nationality;
                    customer.Gender = newcustomer.Gender;
                    context.SaveChanges();
                 return RedirectToAction("Index", "Home");

                }

                else
                {

                    return View(customer);
                }


            }catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(customer);
            }
        }

        public ActionResult Delete(int id)
        {
            Customer customer = context.customers.FirstOrDefault(c => c.ID == id);
            context.customers.Remove(customer);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}