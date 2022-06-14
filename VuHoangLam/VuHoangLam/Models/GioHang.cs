using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VuHoangLam.Models
{
    public class GioHang
    {
        DbRubikStore db = new DbRubikStore();
        public int Id { get; set; }
        //[Display(Name = "Tên")]
        public string Ten { get; set; }

        //[Display(Name = "Ảnh bìa")]
        public string Hinh { get; set; }
        //[Display(Name = "Giá bán")]
        public Double Gia { get; set; }
        //[Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
        //[Display(Name = "Thành tiền")]
        public Double ThanhTien
        {
            get { return SoLuong * Gia; }
        }

        public GioHang(int id)
        {
            this.Id = id;
            Rubik rubik = db.Rubiks.Single(s => s.id == id);
            Ten = rubik.ten;
            Hinh = rubik.hinh;
            Gia = double.Parse(rubik.gia.ToString());
            SoLuong = 1;
        }
    }
}