using GatewayService;
using SctJSKClient.Controllers;
using SctJSKClient.Security;
using SctJSKClient.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SctJSKClient.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class SaleController : Controller
    {
        Facade facade = new Facade();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        //------------------------------------------------------------------------------------------------------------------
        public ActionResult GetDailySales(SaleViewModel salevm)
        {
            var getDate = salevm.StartDate;
            if (getDate == null || getDate == "")
            {
                DateTime today = DateTime.Today.Date;
                getDate = today.ToString();
            }

            string date = getDate.Split(' ')[0];
            var productCount = facade.GetOrderService().GetOrderedProducts(date);
            int total = productCount.Sum(p => p.TotalPrice);
            int totalproducts = productCount.Sum(p => p.NumberOfProduct);
            SaleViewModel svm = new SaleViewModel
            {
                CountOfProducts = productCount.ToList(),
                Total = total,
                TotalProduct = totalproducts,
                StartDate = date

            };
            return View(svm);
        }

        public JsonResult GetPieRenderer(string date)
        {
            var productCount = facade.GetOrderService().GetOrderedProducts(date);
            var DbResult = productCount.Select(p => new { Title = p.product.Title, Number = p.NumberOfProduct });

            return Json(DbResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CharterColumn(string date)
        {
            var productCount = facade.GetOrderService().GetOrderedProducts(date);
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var results = productCount;
            results.ToList().ForEach(rs => xValue.Add(rs.product.Title));
            results.ToList().ForEach(rs => yValue.Add(rs.NumberOfProduct));

            new Chart(width: 390, height: 300, theme: ChartTheme.Blue)
                .AddSeries("Default", chartType: "Column", xValue: xValue, yValues: yValue)
                .Write("bmp");

            return null;
        }

        public ActionResult CharterPie(string date)
        {
            var productCount = facade.GetOrderService().GetOrderedProducts(date);
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var results = productCount;
            results.ToList().ForEach(rs => xValue.Add(rs.product.Title));
            results.ToList().ForEach(rs => yValue.Add(rs.NumberOfProduct));

            new Chart(width: 390, height: 300, theme: ChartTheme.Blue)
                .AddSeries("Default", chartType: "Pie", xValue: xValue, yValues: yValue)
                .Write("bmp");

            return null;
        }
        //------------------------------------------------------------------------------------------------------------------

        public ActionResult GetWeeklySales(SaleViewModel salevm)
        {
            string getFullDate = salevm.FullDate;
            if (getFullDate == null || getFullDate == "")
            {
                DateTime start = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                DateTime end = start.AddDays(4);

                string sd = start.ToString().Split(' ')[0];
                string ed = end.ToString().Split(' ')[0];

                getFullDate = sd + " - " + ed;

            }

            string startDate = getFullDate.Split(' ')[0];
            string endDate = getFullDate.Split(' ')[2];
            //---------------------------------------------------------------
            var productCount = facade.GetOrderService().GetOrderedProductsByDates(startDate, endDate);
            int total = productCount.Sum(p => p.TotalPrice);
            int totalproducts = productCount.Sum(p => p.NumberOfProduct);
            SaleViewModel svm = new SaleViewModel
            {
                CountOfProducts = productCount.ToList(),
                Total = total,
                TotalProduct = totalproducts,
                StartDate = startDate,
                EndDate = endDate,
                FullDate = startDate + " - " + endDate

            };
            return View(svm);
        }

        public ActionResult WeeklyCharterColumn(string startDate, string endDate)
        {
            var productCount = facade.GetOrderService().GetOrderedProductsByDates(startDate, endDate);
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var results = productCount;
            results.ToList().ForEach(rs => xValue.Add(rs.product.Title));
            results.ToList().ForEach(rs => yValue.Add(rs.NumberOfProduct));

            new Chart(width: 390, height: 300, theme: ChartTheme.Blue)
                .AddSeries("Default", chartType: "Column", xValue: xValue, yValues: yValue)
                .Write("bmp");

            return null;
        }

        public ActionResult WeeklyCharterPie(string startDate, string endDate)
        {
            var productCount = facade.GetOrderService().GetOrderedProductsByDates(startDate, endDate);
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var results = productCount;
            results.ToList().ForEach(rs => xValue.Add(rs.product.Title));
            results.ToList().ForEach(rs => yValue.Add(rs.NumberOfProduct));

            new Chart(width: 390, height: 300, theme: ChartTheme.Blue)
                .AddSeries("Default", chartType: "Pie", xValue: xValue, yValues: yValue)
                .Write("bmp");

            return null;
        }

        //------------------------------------------------------------------------------------------------------------------
        public ActionResult GetMonthlySales(SaleViewModel salevm)
        {
            //04/16
            string getDate = salevm.FullDate;

            if (getDate == null || getDate == "")
            {
                DateTime today = DateTime.Now.Date;
                DateTime start = new DateTime(today.Year, today.Month, 1).Date;
                DateTime end = start.AddMonths(1).AddDays(-1);


                string sd = start.ToString().Split(' ')[0];
                string ed = end.ToString().Split(' ')[0];

                getDate = start.ToShortDateString().Split('-')[1] + "-" + start.ToShortDateString().Split('-')[2];
            }
                
            DateTime monthDate = Convert.ToDateTime(getDate.Split(' ')[0]);

            DateTime getStartDate = Convert.ToDateTime(getDate);
            DateTime getEndDate = getStartDate.AddMonths(1).AddDays(-1);

            string startDate = getStartDate.ToString().Split(' ')[0];
            string endDate = getEndDate.ToString().Split(' ')[0];

            int year = int.Parse(getDate.Split('-')[1]);
            int month = monthDate.Month;
            string fullMonthName = new DateTime(year, month, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("da"));

            //---------------------------------------------------------------
            var productCount = facade.GetOrderService().GetOrderedProductsByDates(startDate, endDate);
            int total = productCount.Sum(p => p.TotalPrice);
            int totalproducts = productCount.Sum(p => p.NumberOfProduct);
            SaleViewModel svm = new SaleViewModel
            {
                CountOfProducts = productCount.ToList(),
                Total = total,
                TotalProduct = totalproducts,
                StartDate = startDate,
                EndDate = endDate,
                MonthDate = year + " - " + FirstLetterToUpper(fullMonthName),
                FullDate = getDate

            };
            return View(svm);
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }
}