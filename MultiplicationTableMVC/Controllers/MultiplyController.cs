using System;
using System.Web.Mvc;
using MultiplicationTableMVC.Models;
using static MultiplicationTableMVC.Models.Constants;

namespace MultiplicationTableMVC.Controllers
{
    [Route("Multiply")]
    [Route("Multiplication")]
    public class MultiplyController : Controller
    {
        [HttpGet]
        [ActionName("ShowTable")]
        public ActionResult Index()
        {
            string url = Request.RawUrl;
            string size = Request.QueryString["matrix_size"];
            string representation =Request.QueryString["matrix_base"];

            var entity = new MultiplyViewModel();

            if (!string.IsNullOrEmpty(representation))
                entity.Representation = GetRepresentation(representation);

            if (!string.IsNullOrEmpty(size))
            {
                int currSize;
                entity.Size = Int32.TryParse(size, out currSize) ? (currSize >=3)? currSize :10 : 10;
            }

            return View("Index", entity);
        }

        [HttpPost]
        public ActionResult RefreshDisplayTable(int size, NumericRepresentation representation)
        {
            var entity = new MultiplyViewModel(size, representation);
            return View("Index", entity);
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }


        [NonAction]
        private NumericRepresentation GetRepresentation(string representation)
        {
            NumericRepresentation selectedRepresentation;

            switch (representation.Trim().ToLower())
            {
                case "decimal":
                    selectedRepresentation = NumericRepresentation.Decimal;
                    break;
                case "binary":
                    selectedRepresentation = NumericRepresentation.Binary;
                    break;
                case "hex":
                    selectedRepresentation = NumericRepresentation.Hexadecimal;
                    break;
                default:
                    selectedRepresentation = NumericRepresentation.Decimal;
                    break;
            }

            return selectedRepresentation;
        }
    }
}