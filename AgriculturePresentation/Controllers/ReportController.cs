using AgricultureUI.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AgricultureUI.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticReport() //The package named EPPlus has been downloaded to access reports...
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workBook = excelPackage.Workbook.Worksheets.Add("Page 1");
            workBook.Cells[1, 1].Value = "Product Name";
            workBook.Cells[1, 2].Value = "Product Category";
            workBook.Cells[1, 3].Value = "Product Stock";

            workBook.Cells[2, 1].Value = "Rice";
            workBook.Cells[2, 2].Value = "Cereals";
            workBook.Cells[2, 3].Value = "785 kg";

            workBook.Cells[3, 1].Value = "Wheat";
            workBook.Cells[3, 2].Value = "Cereals";
            workBook.Cells[3, 3].Value = "1.785 kg";

            workBook.Cells[4, 1].Value = "Carrot";
            workBook.Cells[4, 2].Value = "Vegetable";
            workBook.Cells[4, 3].Value = "185 kg";

            var bytes = excelPackage.GetAsByteArray();

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "GrainReport.xlsx"); //for printing
        }

        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            using (var context = new AgricultureContext())
            {
                contactModels = context.Contacts.Select(x => new ContactModel
                {
                    ContactID = x.ContactID,
                    ContactName = x.Name,
                    ContactMail = x.Mail,
                    ContactDate = x.Date,
                    ContactMessage = x.Message
                }).ToList();
            }
            return contactModels;
        }
        public IActionResult ContactReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Message List");
                workSheet.Cell(1, 1).Value = "Message ID";
                workSheet.Cell(1, 2).Value = "Sender";
                workSheet.Cell(1, 3).Value = "Mail";
                workSheet.Cell(1, 4).Value = "Message Content";
                workSheet.Cell(1, 5).Value = "Message Date";


                int iContactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(iContactRowCount, 1).Value = item.ContactID;
                    workSheet.Cell(iContactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(iContactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(iContactRowCount, 4).Value = item.ContactMessage;
                    workSheet.Cell(iContactRowCount, 5).Value = item.ContactDate;
                    iContactRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MessageReport.xlsx");
                }
            }
            
        }
        public List<AnnouncementModel> AnnouncementList()
        {
            List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();
            using (var context = new AgricultureContext())
            {
                announcementModels = context.Announcements.Select(x => new AnnouncementModel
                {
                    AnnouncementID = x.AnnouncementID,
                    Status=x.Status,
                    Date= x.Date,
                    Description=x.Description,  
                    Title = x.Title 
                   
                }).ToList();
            }
            return announcementModels;
        }
        public IActionResult AnnouncementReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Announcement List");
                workSheet.Cell(1, 1).Value = "Announcement ID";
                workSheet.Cell(1, 2).Value = "Announcement Title";
                workSheet.Cell(1, 3).Value = "Announcement Date";
                workSheet.Cell(1, 4).Value = "Announcement Content";
                workSheet.Cell(1, 5).Value = "Status";


                int iContactRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    workSheet.Cell(iContactRowCount, 1).Value = item.AnnouncementID;
                    workSheet.Cell(iContactRowCount, 2).Value = item.Title;
                    workSheet.Cell(iContactRowCount, 3).Value = item.Date;
                    workSheet.Cell(iContactRowCount, 4).Value = item.Description;
                    workSheet.Cell(iContactRowCount, 5).Value = item.Status;
                    iContactRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AnnouncementReport.xlsx");
                }
            }

        }
    }
}
