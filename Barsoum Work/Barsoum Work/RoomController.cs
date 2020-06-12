using PolaHotel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolaHotel.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        //RoomService service = new RoomService();
        ApplicationDbContext Context = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(Context.Rooms.ToList());
        }

        public ActionResult Add()
        {
            ViewBag.RoomCategorys = Context.Room_Categories.ToList();
            ViewBag.Services = Context.Services.ToList();
            return View();
        }

        
        [HttpPost]
        public ActionResult Add(Room room, HttpPostedFileBase upload,List<int>IdServices)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RoomCtegorys = Context.Room_Categories.ToList();
                ViewBag.Services = Context.Services.ToList();
                return View(room);
            }
            else
            {
                try
                {
                    if (upload != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/Images"), upload.FileName);
                        upload.SaveAs(path);
                        room.Image = upload.FileName;
                    }
                    Context.Rooms.Add(room);
                    foreach(var item in IdServices)
                    {
                        Context.RoomServices.Add(new RoomService
                        {
                            RoomID=room.Room_Number,
                            ServiceID=item,
                            IsAvailble=true

                        }
                         );
                       
                    }
                    Context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewBag.RoomCtegorys = Context.Room_Categories.ToList();
                    ViewBag.Services = Context.Services.ToList();
                    return View(room);
                }

            }

        }



        public ActionResult Edit(int roomNo)
        {
            ViewBag.RoomCtegorys = Context.Room_Categories.ToList();
            ViewBag.Services = Context.Services.ToList();
            return View(Context.Rooms.FirstOrDefault(r=>r.Room_Number== roomNo));

        }


        [HttpPost]
        public ActionResult Edit(Room room, HttpPostedFileBase upload, List<int>IdServices)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RoomCtegorys = Context.Room_Categories.ToList();
                ViewBag.Services = Context.Services.ToList();
                return View(room);
            }
            else
            {
                try
                {
                    if (upload != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/Images"), upload.FileName);
                        upload.SaveAs(path);
                        room.Image = upload.FileName;
                    }
                    Room Room = Context.Rooms.FirstOrDefault(r => r.Room_Number == room.Room_Number);
                    if (Room != null)
                    {
                        Room.Price = room.Price;
                        Room.Image = room.Image;
                        Room.Description = room.Description;
                        Room.isavailble = room.isavailble;
                        Room.NumberOfBeeds = room.NumberOfBeeds;
                        Room.Room_Categ_ID = room.Room_Categ_ID;
                    }
                    Context.SaveChanges();

                    List<RoomService> rooomServices = Context.RoomServices.Where(RS => RS.RoomID == room.Room_Number).ToList();
                    if (IdServices.Count != 0)
                    {
                        Context.RoomServices.RemoveRange(rooomServices);
                        Context.SaveChanges();
                        foreach (var item in IdServices)
                        {
                            Context.RoomServices.Add(new RoomService
                            {
                                RoomID = room.Room_Number,
                                ServiceID = item,
                                IsAvailble = true

                            }
                             );

                        }
                        Context.SaveChanges();
                    }
                   
                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewBag.RoomCtegorys = Context.Room_Categories.ToList();
                    ViewBag.Services = Context.Services.ToList();
                    return View(room);
                }

            }

        }



        public ActionResult Details(int id)
        {
            Room room = Context.Rooms.FirstOrDefault(r => r.Room_Number == id);
            return View(room);
        }

        public ActionResult Delete(int id)
        {
            Room room = Context.Rooms.FirstOrDefault(r => r.Room_Number == id);
            Context.Rooms.Remove(room);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CheckRoomNumber(int Room_Number)
        {
            Room room = Context.Rooms.FirstOrDefault(r=>r.Room_Number== Room_Number);
            if (room != null)
            {
                return Json(false,JsonRequestBehavior.AllowGet);
            }
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}