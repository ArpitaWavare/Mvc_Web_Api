using Mvc_Web_Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Web_Api.Models
{
    public class Mvc_Web_ApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile_No { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public int Srno { get; set; }
        public int SaveEmp(Mvc_Web_ApiModel model)
        {
            int msg = 1;

            MVC5_WWB_APIEntities Db = new MVC5_WWB_APIEntities();
            var reg = Db.tblEmployees.Where(p => p.Id == model.Id).FirstOrDefault();

            if (model.Id == 0)
            {

                var regData = new tblEmployee()
                {
                   
                    Name = model.Name,
                    Mobile_No = model.Mobile_No,
                    Email = model.Email,
                    Address = model.Address,

                };
                Db.tblEmployees.Add(regData);
                Db.SaveChanges();
                msg = 1;
            }
            else
            {
                reg.Id = model.Id;
                reg.Name = model.Name;
                reg.Mobile_No = model.Mobile_No;
                reg.Email = model.Email;
                reg.Address = model.Address;

                Db.SaveChanges();
                msg = 2;
            }

            return msg;

        }
        public List<Mvc_Web_ApiModel> GetEmployeeList()
        {
            MVC5_WWB_APIEntities Db = new MVC5_WWB_APIEntities();
            List<Mvc_Web_ApiModel> lstEmployee = new List<Mvc_Web_ApiModel>();
            var AddEmployeeList = Db.tblEmployees.ToList();
            int Srno = 1;
            if (AddEmployeeList != null)
            {
                foreach (var Employee in AddEmployeeList)
                {
                    lstEmployee.Add(new Mvc_Web_ApiModel()
                    {
                        Srno = Srno,
                        Id = Employee.Id,
                        Name = Employee.Name,
                        Mobile_No = Employee.Mobile_No,
                        Email = Employee.Email,
                        Address = Employee.Address,



                    });
                    Srno++;
                }
            }
            return lstEmployee;
        }

        public int deleteEmployee(int Id)
        {
            var msg = 0;
            MVC5_WWB_APIEntities Db = new MVC5_WWB_APIEntities();
            var data = Db.tblEmployees.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                Db.tblEmployees.Remove(data);
                Db.SaveChanges();
                msg = 1;

            }
            else 
            {
                msg = 1;
            }
            return msg;
        }

        public Mvc_Web_ApiModel getEmployeebyID(int Id)
        {
            Mvc_Web_ApiModel model = new Mvc_Web_ApiModel();
            MVC5_WWB_APIEntities Db = new MVC5_WWB_APIEntities();
            var data = Db.tblEmployees.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                model.Id = data.Id;
                model.Name = data.Name;
                model.Mobile_No = data.Mobile_No;
                model.Email = data.Email;
                model.Address = data.Address;


            }
            return model;
        }
    }
}