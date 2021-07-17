using QuanLySach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLySach.Controllers
{
    public class SachController : ApiController
    {


        [HttpGet]
        public List<Sach> GetSachLists()
        {
            DBSachDataContext db = new DBSachDataContext();
            return db.Saches.ToList();
        }

        //Sach[] sachs = new Sach[]
        // {
        //     new Sach { Id = 1, Title = "Tôi thấy hoa vàng trên cỏ xanh", AuthorName =
        //    "Nguyễn Nhật Ánh", Price = 1, Content= "Truyện kể về Tuổi thơ..." },
        //     new Sach { Id = 2, Title = "Pro ASP.NET MVC5", AuthorName =
        //     "Adam Freeman", Content= "The ASP.NET MVC 5 Framework is the latest evolution of Microsoft’s ASP.NET web platform."
        //    , Price = 3.75 },
        // };
        //public IEnumerable<Sach> GetAll()
        //{
        //    return sachs;
        //}
        [HttpGet]
        public Sach GetSach(int id)
        {
            DBSachDataContext db = new DBSachDataContext();
            var sach = db.Saches.FirstOrDefault((p) => p.Id == id);
            
            return sach;
        }

        [HttpPost]
        public bool InsertNewFood(int id, string title, string content, string authorName, int price)
        {
            try
            {
                DBSachDataContext db = new DBSachDataContext();
                Sach sach = new Sach();
                sach.Title = title;
                sach.Content = content;
                sach.AuthorName = authorName;
                sach.Price = price;
                db.Saches.InsertOnSubmit(sach);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        public bool UpdateFood(int id, string title, string content, string authorName, int price)
        {
            try
            {
                DBSachDataContext db = new DBSachDataContext();
                //lấy food tồn tại ra
                Sach sach = db.Saches.FirstOrDefault(x => x.Id == id);
                if (sach == null) return false;//không tồn tại false
                sach.Title = title;
                sach.Content = content;
                sach.AuthorName = authorName;
                sach.Price = price;
                db.SubmitChanges();//xác nhận chỉnh sửa
                return true;
            }
            catch
            {
                return false;
            }
        }



        [HttpDelete]
        public bool DeleteFood(int id)
        {
            DBSachDataContext db = new DBSachDataContext();
            //lấy food tồn tại ra
            Sach food = db.Saches.FirstOrDefault(x => x.Id == id);
            if (food == null) return false;
            db.Saches.DeleteOnSubmit(food);
            db.SubmitChanges();
            return true;
        }




    }
}
