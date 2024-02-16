using certiftrial.Models;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System.Diagnostics;
using System.Reflection.Metadata;
using SelectPdf;

namespace certiftrial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* public ActionResult HandleForm(string username, string email, Boolean flatten)
         {
             FileStreamResult pdf = fillPDF(username, email, flatten); //fill in existing pdf and return the pdf as an action result

             pdf.FileStream.Position = 0; //since the stream has been read, reset it to the start so we use it again

             return pdf; //return the pdf as weboutput to the user
         }

         //fill in existing pdf and return the pdf as an action result
         private FileStreamResult fillPDF(String username, String email, Boolean flatten)
         {
             //open the pdf form
             using (FileStream source = new FileStream(Server.MapPath("~/simpleform.pdf"), FileMode.Open, FileAccess.Read))
             {
                 Document document = new Document(source);

                 //get the correct textfields and fill in the corresponding values
                 TextField userfield = document.Fields["username"] as TextField;
                 userfield.Value = username;

                 TextField emailfield = document.Fields["e-mail"] as TextField;
                 emailfield.Value = email;

                 //if flatten, then flatten the form fields (make them uneditable).
                 if (flatten)
                 {
                     foreach (Widget widget in userfield.Widgets)
                     {
                         widget.Persistency = WidgetPersistency.Flatten;
                     }

                     foreach (Widget widget in emailfield.Widgets)
                     {
                         widget.Persistency = WidgetPersistency.Flatten;
                     }
                 }

                 //since we don't write to disk, write the pdf to a memory stream and return it as a pdf
                 MemoryStream ms = new MemoryStream();
                 document.Write(ms);
                 ms.Flush();
                 ms.Position = 0;
                 return File(ms, "application/pdf");
             }
         }
     }
 */
        public IActionResult GeneratePdf(string html)
        {
            html = html.Replace("StrTag", "<").Replace("EndTag", ">");
            HtmlToPdf oHtmlToPdf = new HtmlToPdf();
            PdfDocument oPdfDocument = oHtmlToPdf.ConvertHtmlString(html);
            byte[] pdf = oPdfDocument.Save();
			oPdfDocument.Close();
            return File(
            pdf,
            "application/pdf",
            "StudentList.pdf"
            );

        }
    }
}
