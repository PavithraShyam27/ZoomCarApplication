using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ZoomCarRentalProject.Repository;
using ZoomCarRentalProject.Models;

namespace ZoomCarRentalProject.Controllers
{
    public class CarDetailsController : Controller
    {
        // GET: CarDetails
        [HttpGet]
        public ActionResult GetCarDetails()
        {
            try
            {
                ServicesRepository ServicesObj = new ServicesRepository();
                HttpResponseMessage Response = ServicesObj.GetResponse("/api/CarDetails");
                Response.EnsureSuccessStatusCode();
                List<CarDetails> carDetails = Response.Content.ReadAsAsync<List<CarDetails>>().Result;
                ViewBag.Title = "All Car Details";
                return View(carDetails);
                                              
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [HttpGet]
        public ActionResult CreateCarDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCarDetails(CarDetails cardetails)
        {
            try
            {
                ServicesRepository ServicesObj = new ServicesRepository();
                HttpResponseMessage Response = ServicesObj.PostResponse("/api/CarDetails", cardetails);
                Response.EnsureSuccessStatusCode();
                return RedirectToAction("GetCarDetails");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult UpdateCarDetails(int id)
        {
            try
            {
                ServicesRepository Servicesobj = new ServicesRepository();
                HttpResponseMessage Response = Servicesobj.GetResponse("/api/CarDetails?id=" + id.ToString());
                Response.EnsureSuccessStatusCode();
                Models.CarDetails Cardetail = Response.Content.ReadAsAsync<Models.CarDetails>().Result;
                ViewBag.Title = "UpdateCarDetails";
                return View(Cardetail);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult UpdateCarDetails(CarDetails cardetails)
        {
            try
            {
                ServicesRepository Servicesobj = new ServicesRepository();
                HttpResponseMessage Response = Servicesobj.PutResponse("/api/CarDetails",cardetails);
                Response.EnsureSuccessStatusCode();
                return RedirectToAction("GetCarDetails");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult DeleteCarDetails(int id)
        {
            try
            {
                ServicesRepository servicesobj = new ServicesRepository();
                HttpResponseMessage Response = servicesobj.DeleteResponse("/api/CarDetails?" + id.ToString());
                Response.EnsureSuccessStatusCode();
                return RedirectToAction("GetCarDetails");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}