using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZoomCarApplication.Models;

namespace ZoomCarApplication.Controllers
{
    public class CarDetailsController : ApiController
    {
        [HttpGet]
        public IEnumerable<CarDetails> GetCarDetails()
        {
            using (DataAccessEntities entities = new DataAccessEntities())
            {
               return entities.CarDetails.ToList(); ;
            }
                       
        }

        [HttpGet]
        public CarDetails GetCarDetails(int id)
        {
            using (DataAccessEntities entities = new DataAccessEntities())
            {
                return entities.CarDetails.FirstOrDefault(i => i.ID == id);
            }
        }

        [HttpPost]
        public HttpResponseMessage InsertCarDetails([FromBody] CarDetails cardetails)
        {
            try
            {
                using (DataAccessEntities entities = new DataAccessEntities())
                {
                    entities.CarDetails.Add(cardetails);
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "The given details has been added successfully");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The Given detail cannot be added because of" + ex.ToString());
            }
            
        }

        [HttpPut]
        public HttpResponseMessage UpdateCarDetails([FromBody] CarDetails UpdateCarDetails)
        {
            try
            {
                using (DataAccessEntities entities = new DataAccessEntities())
                {
                    var Changesdetails = entities.CarDetails.FirstOrDefault(i => i.ID == UpdateCarDetails.ID);

                    if (Changesdetails == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The given id " + UpdateCarDetails.ID.ToString() + " is not found");
                    }
                    else
                    {
                        Changesdetails.CarModel = UpdateCarDetails.CarModel;
                        Changesdetails.CarNo = UpdateCarDetails.CarNo;
                        Changesdetails.NoOfSeats = UpdateCarDetails.NoOfSeats;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "The given id " + UpdateCarDetails.ID.ToString() + " is updated successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
            
        }

        [HttpDelete]
        public HttpResponseMessage DeleteCarDetails (int id)
        {
            using(DataAccessEntities entities = new DataAccessEntities())
            {
                var entity = entities.CarDetails.FirstOrDefault(i => i.ID == id);

                if (entities == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "The given id " + id + " is not found");
                }
                else
                {
                    entities.CarDetails.Remove(entity);
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "The given id " + id + " is deleted successfully");
                }
               
            }
        }
    }
}
