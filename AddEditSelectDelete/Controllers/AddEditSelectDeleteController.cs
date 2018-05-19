using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AddEditSelectDelete.Controllers
{
    public class AddEditSelectDeleteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Cancel(string vtupd)
        {
            if (ViewData["id"] != null)
            {
                ViewData.Clear();
            }


            if (vtupd == "webindex")
                return View("WebIndex");
            else
                return View("Index");
        }
        [HttpPost]
        public ActionResult Index(FormCollection frmc)
        {


            if (Request.Form["deptID"] != null && Request.Form["nme"] != null && Request.Form["grnme"] != null && Request.Form["mddate"] != null)
            {
                string departmentID = Request.Form["deptID"].ToString();
                string name = Request.Form["nme"].ToString();
                string groupename = Request.Form["grnme"].ToString();
                string modifieddate = Request.Form["mddate"].ToString();
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection("Data Source=(localdb)\\LocalInstance;Initial Catalog=AdventureWorks2012;Integrated Security=True");
                string cmdtext = "UPDATE [HumanResources].[Department] SET [Name] = '" + name + "',[GroupName] = '" + groupename + "',[ModifiedDate] = '" + modifieddate + "' WHERE [DepartmentID] = " + departmentID + "";
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmdtext, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                ViewData.Clear();


            }




            if (Request.Form["DepartmentID"] != null && Request.Form["Name"] != null && Request.Form["GroupName"] != null && Request.Form["ModifiedDate"] != null && Request.Form["EditingFormTrue"] != null)
            {
                // we pressed on edit

                ViewData["id"] = Request.Form["DepartmentID"].ToString();
                ViewData["name"] = Request.Form["Name"].ToString();
                ViewData["groupName"] = Request.Form["GroupName"].ToString();
                ViewData["modifiedDate"] = Request.Form["ModifiedDate"].ToString();

                ViewData.Clear();
            }



            if (Request.Form["NAMETOADD"] != null && Request.Form["GROUPNAMETOADD"] != null && Request.Form["MODIFIEDDATETOADD"] != null)
            {
                string nametoadd = Request.Form["NAMETOADD"].ToString();
                string groupenametoadd = Request.Form["GROUPNAMETOADD"].ToString();
                string modifieddatetoadd = Request.Form["MODIFIEDDATETOADD"].ToString();
                System.Data.SqlClient.SqlConnection connectionnewadd = new System.Data.SqlClient.SqlConnection("Data Source=(localdb)\\LocalInstance;Initial Catalog=AdventureWorks2012;Integrated Security=True");
                string cmdtextaddnew = "INSERT INTO [HumanResources].[Department]([Name],[GroupName],[ModifiedDate])VALUES('" + nametoadd + "','" + groupenametoadd + "','" + modifieddatetoadd + "')";
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmdtextaddnew, connectionnewadd);
                connectionnewadd.Open();
                command.ExecuteNonQuery();
                connectionnewadd.Close();
                ViewData.Clear();


            }


            if (Request.Form["viewtoretupd"] != null)
                return View("WebIndex");

            else
                return View("Index");
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Update(string id, string name, string groupName, string modifiedDate)
        {
            string urlreferrer = Request.UrlReferrer.ToString();
            if (ViewData["currentview"].ToString() == "webview")
                return View("WebIndex");
            else
                return View("Index");
        }
        public ActionResult Edit(string id, string name, string groupName, string modifiedDate, string viewtoreturn)
        {

            if (id != null && name != null && groupName != null && modifiedDate != null)
            {
                ViewData["id"] = id;
                ViewData["name"] = name;
                ViewData["groupName"] = groupName;
                ViewData["modifiedDate"] = modifiedDate;
            }



            if (viewtoreturn == "webindex")
                return View("WebIndex");
            else
                return View("Index");

        }

        [HttpPost]
        public ActionResult Edit(FormCollection frm, string viewtoreturn)
        {

            if (Request.Form["deptID"] != null && Request.Form["nme"] != null && Request.Form["grnme"] != null && Request.Form["mddate"] != null)
            {
                string departmentID = Request.Form["deptID"].ToString();
                string name = Request.Form["nme"].ToString();
                string groupename = Request.Form["grnme"].ToString();
                string modifieddate = Request.Form["mddate"].ToString();
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection("Data Source=(localdb)\\LocalInstance;Initial Catalog=AdventureWorks2012;Integrated Security=True");
                string cmdtext = "UPDATE [HumanResources].[Department] SET [Name] = '" + name + "',[GroupName] = '" + groupename + "',[ModifiedDate] = '" + modifieddate + "' WHERE [DepartmentID] = " + departmentID + "";
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmdtext, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                ViewData.Clear();


            }


            if (viewtoreturn == "webindex")
                return View("WebIndex");
            else
                return View("Index");

        }


        public ActionResult Add(string viewtoretur)
        {
            ViewData["AddRecord"] = "AddRecord";


            if (viewtoretur == "webindex")
                return View("WebIndex");
            else
                return View("Index");
        }
        public ActionResult AddNew()
        {
            ViewData["AddNewRecord"] = "AddNewRecord";


            return View("Index");
        }
        public ActionResult Delete(string idtodel, string viewtoreturn)
        {
            string depidtodelete = idtodel;
            System.Data.SqlClient.SqlConnection connectionnewadd = new System.Data.SqlClient.SqlConnection("Data Source=(localdb)\\LocalInstance;Initial Catalog=AdventureWorks2012;Integrated Security=True");
            string cmdtextaddnew = "DELETE FROM [HumanResources].[Department] WHERE DepartmentID = " + depidtodelete;
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(cmdtextaddnew, connectionnewadd);
            connectionnewadd.Open();
            command.ExecuteNonQuery();
            connectionnewadd.Close();
            ViewData.Clear();
            ViewData["rowdeletednotify"] = "Yes";


            if (viewtoreturn == "webindex")
                return View("WebIndex");
            else
                return View("Index");
        }

        public ActionResult WebIndex()
        {
            return View();
        }
    }
}