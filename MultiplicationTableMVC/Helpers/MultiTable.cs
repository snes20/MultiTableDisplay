using System;
using System.Web;
using System.Web.Mvc;
using static MultiplicationTableMVC.Models.Constants;

namespace MultiplicationTableMVC.Helpers
{
    public static class MultiTable
    {
        public static HtmlString Table(this HtmlHelper helper, int size, NumericRepresentation representation = NumericRepresentation.Decimal )
        {
            var tagBuilder = new TagBuilder("table");
            tagBuilder.Attributes.Add("class", "table table-bordered FormatTable");
            var ta = new TagBuilder("table");
            GenerateHtml(0, size+1, tagBuilder, representation);
            return new HtmlString(tagBuilder.ToString());
        }

        private static void GenerateHtml(int current, int size, TagBuilder tagBuilder, NumericRepresentation representation)
        {
            var tr = new TagBuilder("tr");

            if (current == 0)// Create the headers
            {
                for (var i = 0; i < size; i++)
                {
                    var th = new TagBuilder("th");
                    if (i > 0)
                    {
                        th.Attributes.Add("class", "cyanColor");
                    }

                    th.SetInnerText((i == 0 ? "X" : i.ToString()));
                    tr.InnerHtml +=th.ToString();
                }
            }
            else
            {
                for (var i = 0; i < size; i++)
                {
                    var td = new TagBuilder("td");
                                       
                    if (i == 0)
                    {
                        td.Attributes.Add("class", "cyanColor");
                        td.SetInnerText(current.ToString());
                    }
                    else
                    {
                        var valueToFormat = current * i;
                        var formatedValue = GetRepresentation(valueToFormat, representation);
                        var strPrime = string.Empty;

                        if (IsPrime(valueToFormat))
                        {
                            td.Attributes.Add("class", "primeColor");
                            strPrime = "Prime Number\n";
                        }

                        td.Attributes.Add("data-toggle", "tooltip");
                        td.Attributes.Add("title", $"{strPrime}{current} x {i} = {valueToFormat} {((representation == NumericRepresentation.Decimal) ? "" : $"({formatedValue} {representation})")}");
                        td.SetInnerText(formatedValue);
                    }
                    
                    tr.InnerHtml += td.ToString();
                }
            }
            

            tagBuilder.InnerHtml += tr.ToString();
            current++;
            if (current < size)
            {
                GenerateHtml(current, size, tagBuilder, representation);
            }
        }

        private static string GetRepresentation(int value, NumericRepresentation numericRepresentation)
        {
            string result = string.Empty;

            switch (numericRepresentation)
            {
                case NumericRepresentation.Decimal:
                    result = value.ToString();
                    break;
                case NumericRepresentation.Binary:
                    result = Convert.ToString(value, 2);
                    break;
                case NumericRepresentation.Hexadecimal:
                    result = Convert.ToString(value, 16);
                    break;
            }

            return result;
        }

        private static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number % 2 == 0) return (number == 2);
            int root = (int)Math.Sqrt((double)number);
            for (int i = 3; i <= root; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}