﻿using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDT.Models.BUS;

namespace WebDT.Areas.Admin.Controllers
{
    public class NhaSanXuatAdminController : Controller
    {
        // GET: Admin/NhaSanXuatAdmin
        public ActionResult Index()
        {
            var ds = NhaSanXuatBUS.DanhSachAdmin();
            return View(ds);
        }

        // GET: Admin/NhaSanXuatAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhaSanXuatAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaSanXuatAdmin/Create
        [HttpPost]
        public ActionResult Create(NhaSanXuat nsx)
        { 
            try
            {
                // TODO: Add insert logic here
                NhaSanXuatBUS.ThemNSX(nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaSanXuatAdmin/Edit/5
        public ActionResult Edit(String id)
        {

            return View(NhaSanXuatBUS.ChiTietAdmin(id));
        }

        // POST: Admin/NhaSanXuatAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add update logic here
                NhaSanXuatBUS.UpdateNSX(id, nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult XoaTamThoi(String id)
        {
            return View(NhaSanXuatBUS.ChiTietAdmin(id));
        }

        [HttpPost]
        public ActionResult XoaTamThoi(String id, NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add delete logic here
                nsx.TinhTrangNSS = "1";
                NhaSanXuatBUS.UpdateNSX(id, nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaSanXuatAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NhaSanXuatAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(String id, NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
