using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuHoangLam.Models;

namespace VuHoangLam.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        DbRubikStore db = new DbRubikStore();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang == null)
            {
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }

        public ActionResult ThemGioHang(int id, string strUrl)
        {
            List<GioHang> listGioHang = LayGioHang();
            GioHang gh = listGioHang.Find(n => n.Id == id);
            if(gh == null)
            {
                gh = new GioHang(id);
                listGioHang.Add(gh);
                return Redirect(strUrl);
            }
            else
            {
                gh.SoLuong++;
                return Redirect(strUrl);
            }
        }

        private int TongSoLuong()
        {
            int result = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                result = listGioHang.Sum(n => n.SoLuong);
            }
            return result;
        }

        private int TongSoLuongSanPham()
        {
            int result = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                result = listGioHang.Count;
            }
            return result;
        }

        private double TongTien()
        {
            double result = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                result = listGioHang.Sum(n => n.ThanhTien);
            }
            return result;
        }

        public ActionResult GioHang()
        {
            List<GioHang> listGioHang = LayGioHang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(listGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }

        public ActionResult XoaGioHang(int id)
        {
            List<GioHang> listGioHang = LayGioHang();
            GioHang gh = listGioHang.SingleOrDefault(n => n.Id == id);
            if (gh == null)
            {
                listGioHang.RemoveAll(n => n.Id == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult CapNhatGioHang(int id, FormCollection collection)
        {
            List<GioHang> listGioHang = LayGioHang();
            GioHang gh = listGioHang.SingleOrDefault(n => n.Id == id);
            if(gh == null)
            {
                gh.SoLuong = int.Parse(collection["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult ChiTietGioHang(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            List<GioHang> listGioHang = LayGioHang();
            GioHang gh = listGioHang.Find(n => n.Id == id);
            if( gh == null)
            {
                return HttpNotFound();
            }
            return View(gh);
        }
    }
}