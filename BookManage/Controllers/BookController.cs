using BookManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FirstCRUDApplication.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private BookContext context=new BookContext();

        public BookController()
        {
        }
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<Books> model = context.Books.ToList();
                return View("Index", model);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        [HttpGet]
        public ActionResult Add_Book()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add()
        {
            //新增
            Books book = new Books();
            book.title = Request.Form["title"];
            book.author = Request.Form["author"];
            book.publishDate = Convert.ToDateTime(Request.Form["publishDate"]);
            context.Books.Add(book);
            context.SaveChanges();

            //使用重定向
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit_Book(int id)
        {//获取要编辑的书籍
            Books book = context.Books.SingleOrDefault(t => t.id == id);
            ViewData.Model = book;
            return View();
        }
        [HttpPost]
        public ActionResult Edit()
        {
            //更新修改
            Books book = new Books();
            book.id = int.Parse(Request.Form["id"]);
            book.title = Request.Form["title"];
            book.author = Request.Form["author"];
            book.publishDate = Convert.ToDateTime(Request.Form["publishDate"]);
            //db.Table_User
            context.Entry(book).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            //使用重定向
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete_Book(int id)
        {//删除
            Books book = context.Books.SingleOrDefault(t => t.id == id);
            context.Entry(book).State = System.Data.Entity.EntityState.Deleted;
            context.Books.Remove(book);
            context.SaveChanges();
            //使用重定向
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult GetBookById(int? id)
        //{//按id查询
        //    Book book = context.Books.SingleOrDefault(c => c.id == id.Value);
        //    return PartialView("~/Views/Book/_AddEditBook.cshtml", book);
        //}

        //[HttpPost]
        //public ActionResult AddEditBook(Book model)
        //{//新增或修改
        //    try
        //    {
        //        context.SaveBook(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult DeleteBook(int id)
        //{//删除
        //    Book book = context.Books.SingleOrDefault(c => c.id == id);
        //    string bookName = book.title;
        //    context.DeleteBook(book);
        //    return PartialView("~/Views/Book/_DeleteBook.cshtml", model: bookName);
        //}
    }
}