﻿using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDT.Models.BUS
{
    public class NhaSanXuatBUS 
    {
        public static IEnumerable<NhaSanXuat> DanhSach()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<NhaSanXuat>("select * from NhaSanXuat where TinhTrangNSS = 0");
        }

        public static IEnumerable<SanPham> ChiTiet(String id)
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<SanPham>("select * from SanPham where MaNSS = '" + id + "'");
        }

        public static void ThemNSX(NhaSanXuat nsx)
        {
            var db = new ShopOnlineConnectionDB();
            db.Insert(nsx);
        }


        public static IEnumerable<NhaSanXuat> DanhSachAdmin()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<NhaSanXuat>("select * from NhaSanXuat");
        }

        public static NhaSanXuat ChiTietAdmin(String id)
        {
            var db = new ShopOnlineConnectionDB();
            return db.SingleOrDefault<NhaSanXuat>("select * from NhaSanXuat where MaNSS = '" + id + "'");
        }

        public static void UpdateNSX(String id, NhaSanXuat nsx)
        {
            var db = new ShopOnlineConnectionDB();
            db.Update(nsx, id);
        }
    }
}