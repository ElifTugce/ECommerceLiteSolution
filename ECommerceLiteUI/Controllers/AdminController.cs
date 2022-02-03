using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceLiteBLL.Repository;
namespace ECommerceLiteUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : BaseController
    {
        //Global Alan
        //Repoları çağıralım
        OrderRepo myOrderRepo = new OrderRepo();

        // GET: Admin
        public ActionResult Dashboard()
        {
            var orderList = myOrderRepo.GetAll();
            //1 aylık sipariş sayısı
            var newOrderCount = orderList.Where(x => x.RegisterDate >= DateTime.Now.AddMonths(-1)).ToList().Count;

            ViewBag.NewOrderCount = newOrderCount;

            return View();
        }

        [AllowAnonymous]
        public ActionResult Deneme()
        {
            return View();
        }
    }
}