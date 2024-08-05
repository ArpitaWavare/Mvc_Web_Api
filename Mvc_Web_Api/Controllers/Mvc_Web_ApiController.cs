using Mvc_Web_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mvc_Web_Api.Controllers
{
    public class Mvc_Web_ApiController : ApiController
    {
        public int SaveEmp(Mvc_Web_ApiModel model)
        {
            var Mvc_Web_ApiModel = new Mvc_Web_ApiModel();
            var result = Mvc_Web_ApiModel.SaveEmp(model);
            return result;
        }

        public List<Mvc_Web_ApiModel> GetEmployeeList()
        {
            var Mvc_Web_ApiModel = new Mvc_Web_ApiModel();
            List<Mvc_Web_ApiModel> Lst = new List<Mvc_Web_ApiModel>();
            var result = Mvc_Web_ApiModel.GetEmployeeList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    Lst.Add(item);
                }
            }

            return Lst;
        }
        [HttpDelete]
        public int deleteEmployee(int Id)
        {
            var Mvc_Web_ApiModel = new Mvc_Web_ApiModel();
            var result = Mvc_Web_ApiModel.deleteEmployee(Id);
            return result;
        }
        public Mvc_Web_ApiModel getEmployeebyID(int Id)
        {
            var Mvc_Web_ApiModel = new Mvc_Web_ApiModel();
            var result = Mvc_Web_ApiModel.getEmployeebyID(Id);
            return result;
        }

    }
}
