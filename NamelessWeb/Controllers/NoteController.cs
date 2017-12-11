using NamelessWeb.Models;
using NamelessWeb.Models.Guitar;
using NamelessWeb.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Net;
using Microsoft.AspNet.Identity;
using NamelessWeb.Models.WebSystem;

namespace NamelessWeb.Controllers
{
    public class NoteController : Controller
    {
        SqlConnection a = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NamelessWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        DataTable dt2 = new DataTable();
        private ApplicationDbContext _DbContext = new ApplicationDbContext();
        // GET: Note
        [Authorize]
        public ActionResult Index()
        {
            return View(_DbContext.Note.ToList());
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Note models)
        {
            var userId = User.Identity.GetUserId();
            var user = _DbContext.Users.Find(userId);
            
            var content = _DbContext.Note.ToList();
            int b = content.Count();
            a.Open();
            SqlCommand x = new SqlCommand("" + "select * from Notes", a);
            SqlDataReader danhsachtam = x.ExecuteReader();
            dt2.Load(danhsachtam);
            a.Close();
            for (int i = 0; i < content.Count; i++)
            {
                for (int j = i + 1; j < content.Count; j++)
                {
                    if (int.Parse((dt2.Rows[j][0]).ToString()) != int.Parse((dt2.Rows[i][0]).ToString()) + 1)
                    {
                        b = int.Parse((dt2.Rows[i][0]).ToString()) + 1;
                        break;
                        //goto done;
                    }
                }
            }
            //var note = new Note
            //{
            //    NoteId = b,
            //    NoteMess = models.NoteMess,
            //    UserName = user.FullName,
            //    Date = DateTime.Now
            //};
            //_DbContext.Note.Add(note);
            //_DbContext.SaveChanges();
            a.Open();
            string y = string.Format("insert into dbo.Notes values('{0}','{1}','{2}','{3}')", b, models.NoteMess, user.FullName, DateTime.Now.ToShortDateString());
            SqlCommand addnote = new SqlCommand(y, a);
            addnote.ExecuteNonQuery();
            a.Close();
            return RedirectToAction("Index", "Note");
        }

        [Authorize]
        public ActionResult Delete(int? Id)
        {
            var note = _DbContext.Note.Single(m => m.NoteId == Id); 
            return View(note);
        }

        [Authorize]
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(int? Id)
        {
            var note = _DbContext.Note.Single(m => m.NoteId == Id);
            _DbContext.Note.Remove(note);
            _DbContext.SaveChanges();
            return RedirectToAction("Index", "Note");
        }
    }
}