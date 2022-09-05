using CRM.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace CRM.Controllers
{
    public class OthetController : Controller
    {
        // GET: Othet

        private OtchetDB db = new OtchetDB();


        public ActionResult Index3(int? team)
        {
            IQueryable<Player> players = db.Players.Include(p => p.Team);
            if (team != null && team != 0)
            {
                players = players.Where(p => p.TeamId == team);
            }

            List<Team> teams = db.Teams.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            teams.Insert(0, new Team { Name = "Все", Id = 0 });

            PlayersListViewModel plvm = new PlayersListViewModel
            {
                Players = players.ToList(),
                Teams = new SelectList(teams, "Id", "Name"),
             
            };
            return View(plvm);
        }

        public ActionResult Index()
        {

            //IQueryable<Othet> othetas = db.Othets.Include(k => k.Kass);
            //if (kass != null && kass != 0)
            //{
            //    othetas = othetas.Where(k => k.Kasskass_id == kass);
            //}
            //List<Kass> kasses = db.Kasses.ToList();
            //// устанавливаем начальный элемент, который позволит выбрать всех
            //kasses.Insert(0, new Kass { kass_id = 0 });

            //KassListViewModel plvm = new KassListViewModel
            //{
            //    Otchets = othetas.ToList(),
            //    Kasses = new SelectList(kasses, "Id", "kass_name"),

            //};
            //return View(plvm);

            //var players = db.Othets.Include(p => p.Kass).ToList();
            System.DateTime startDateTime = System.DateTime.Today;
            System.DateTime endDateTime = System.DateTime.Today.AddDays(1).AddTicks(-1);

            //List<Othet> result = db.Othets.Where(i => i.time >= startDateTime && i.time <= endDateTime).ToList();
           
            List<Othet> result = db.Othets.Where(i => i.Time >= startDateTime && i.Time <= endDateTime).OrderBy(x => x.Timew).ToList();

            // List<Kas> result = db.Kasses.ToList();
            //var result = db.Players.Include(o => o.Team).ToList();
            //  IQueryable<Othet> result = db.Othets.Include(p => p.Kass);
            return View(result.ToList());
        }

        public ActionResult CreateOtchet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOtchet(Othet otchet)
        {
         
            using (var dataC = new OtchetDB())
            {
              
                otchet.Time = System.DateTime.Now;
                otchet.Timew = System.DateTime.Now;
                dataC.Othets.Add(otchet);
                dataC.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditOtchet(Othet otchet)
        {
            using (var dataContext = new OtchetDB())
            {
                dataContext.Entry(otchet).State = System.Data.Entity.EntityState.Modified;
                dataContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditOtchet(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            Othet target = null;

            using (var dataContext = new OtchetDB())
            {
                target = dataContext.Othets.FirstOrDefault(d => d.Id == id);
            }

            if (target != null)
            {
                return View(target);
            }

            return HttpNotFound();
        }

        public ActionResult DeleleOtchet(int? id)
        {
            using (var dataContext = new OtchetDB())
            {
                var othet = dataContext.Othets.FirstOrDefault(d => d.Id == id);
                if (othet != null)
                {
                    dataContext.Entry(othet).State = System.Data.Entity.EntityState.Deleted;
                    dataContext.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
    }


