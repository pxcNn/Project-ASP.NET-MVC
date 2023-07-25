using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDT.Models.BUS;

namespace WebDT.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        // GET: Admin/SanPhamAdmin
        public ActionResult Index()
        {
            
            return View(ShopOnlineBUS.DanhSachSP());
        }

        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPhamAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MaNSS = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNSS", "TenNSS");
            ViewBag.MaLoaiSP = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSP", "TenLoaiSP");
            return View();
        }

        // POST: Admin/SanPhamAdmin/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                var hpf = HttpContext.Request.Files[0];
                if(hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/Asset/img/" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhChinh = sp.MaSP + ".png";
                }

                 hpf = HttpContext.Request.Files[1];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/Asset/img1/" + fileName + "_1.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh1 = sp.MaSP + "_1.png";
                }

                 hpf = HttpContext.Request.Files[2];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/Asset/img1/" + fileName + "_2.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh2 = sp.MaSP + "_2.png";
                }
                 hpf = HttpContext.Request.Files[3];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/Asset/img1/" + fileName + "_3.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh3 = sp.MaSP + "3.png";
                }
                 hpf = HttpContext.Request.Files[4];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/Asset/img1/" + fileName + "_4.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh4 = sp.MaSP + "_4.png";
                }

                sp.TinhTrang = "0";
                sp.Soluongdaban = 0;
                // TODO: Add insert logic here
                ShopOnlineBUS.InsertSP(sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(String id)
        {
            ViewBag.MaNSS = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNSS", "TenNSS", ShopOnlineBUS.ChiTiet(id).MaNSS);
            ViewBag.MaLoaiSP = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSP", "TenLoaiSP", ShopOnlineBUS.ChiTiet(id).MaLoaiSP);
            return View(ShopOnlineBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(String id, SanPham sp)
        {
            var tam = ShopOnlineBUS.ChiTiet(id);
            try
            {
                // TODO: Add update logic here
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/Asset/img/" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhChinh = sp.MaSP + ".png";
                }
                else
                {
                    sp.HinhChinh = tam.HinhChinh;
                }

                hpf = HttpContext.Request.Files[1];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/Asset/img1/" + fileName + "_1.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh1 = sp.MaSP + "_1.png";
                }
                else
                {
                    sp.Hinh1 = tam.Hinh1;
                }

                hpf = HttpContext.Request.Files[2];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/Asset/img1/" + fileName + "_2.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh2 = sp.MaSP + "_2.png";
                }
                else
                {
                    sp.Hinh2 = tam.Hinh2;
                }
                hpf = HttpContext.Request.Files[3];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/Asset/img1/" + fileName + "_3.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh3 = sp.MaSP + "3.png";
                }
                else
                {
                    sp.Hinh3 = tam.Hinh3;
                }
                hpf = HttpContext.Request.Files[4];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/Asset/img1/" + fileName + "_4.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh4 = sp.MaSP + "_4.png";

                }
                else
                {
                    sp.Hinh4 = tam.Hinh4;
                }
                sp.TinhTrang = tam.TinhTrang;


                // TODO: Add insert logic here
                ShopOnlineBUS.UpdateSP(id, sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Delete/5
        public ActionResult Delete(String id)
        {

            return View(ShopOnlineBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Delete/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete(String id, SanPham sp)
        {
            var tam = ShopOnlineBUS.ChiTiet(id);
            try
            {
                if (tam.TinhTrang == "1         ")
                    tam.TinhTrang = "0         ";
                else
                {
                    tam.TinhTrang = "1         ";
                }
          // TODO: Add insert logic here
                ShopOnlineBUS.UpdateSP(id, tam);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
