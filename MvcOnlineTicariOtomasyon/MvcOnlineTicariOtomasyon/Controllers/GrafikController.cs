using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı")
                     .AddLegend("Stok")
                     .AddSeries("Değerler",
                        xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" },
                        yValues: new[] { 85, 66, 98 })
                     .Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));

            var grafik = new Chart(width: 1500, height: 1500)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "stok", xValue: xvalue, yValues: yvalue);

            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif1> Urunlistesi()
        {
            List<Sinif1> snf = new List<Sinif1>();
            snf.Add(new Sinif1()
            {
                UrunAd = "Bilgisayar",
                Stok = 120
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Beyaz Eşya",
                Stok = 150
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Mobilya",
                Stok = 70
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Küçük Ev Aletleri",
                Stok = 180
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Mobil Cihazlar",
                Stok = 90
            });

            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif1> UrunListesi2()
        {
            List<Sinif1> snf = new List<Sinif1>();
            using (var c = new Context())
            {
                snf = c.Uruns.Select(x => new Sinif1
                {
                    UrunAd = x.UrunAd,
                    Stok = x.Stok
                }).ToList();
            }
            return snf;
        }

        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}