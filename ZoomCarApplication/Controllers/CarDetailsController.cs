using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZoomCarDataAccess;

namespace ZoomCarApplication.Controllers
{
    public class CarDetailsController : ApiController
    {
        public IEnumerable<CarDetails> Get()
        {
            using (CarDetailsDBEntities entities = new CarDetailsDBEntities())
            {
               return entities.CarDetails.ToList();
            }
                       
        }

        public CarDetails Get(int id)
        {
            using (CarDetailsDBEntities entities = new CarDetailsDBEntities())
            {
                return entities.CarDetails.FirstOrDefault(i => i.ID == id);
            }
        }

        public HttpResponseMessage Post([FromBody] CarDetails cardetails)
        {
            try
            {
                using (CarDetailsDBEntities entities = new CarDetailsDBEntities())
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

        public HttpResponseMessage Put(int id,[FromBody] CarDetails UpdateCarDetails)
        {
            try
            {
                using (CarDetailsDBEntities entities = new CarDetailsDBEntities())
                {
                    var Changesdetails = entities.CarDetails.FirstOrDefault(i => i.ID == id);

                    if (Changesdetails == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The given id " + id.ToString() + " is not found");
                    }
                    else
                    {
                        Changesdetails.CarModel = UpdateCarDetails.CarModel;
                        Changesdetails.CarNo = UpdateCarDetails.CarNo;
                        Changesdetails.NoOfSeats = UpdateCarDetails.NoOfSeats;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "The given id " + id.ToString() + " is updated successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
            
        }

        public HttpResponseMessage Delete (int id)
        {
            using(CarDetailsDBEntities entities = new CarDetailsDBEntities())
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
