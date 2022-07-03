using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Helpers;
//using System.Web.Mvc;
using Projekat.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjekatWebPortal_Core.Helpers
{

    // https://stackoverflow.com/questions/57821737/replacement-for-expressionhelper-in-asp-net-core-3-0
    public static class DropDownList_Optgroup
    {
        public static string DropDownOpt<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, SelectList opcije,string name)
        {
            string povratak ="";


            var expressionProvider = helper.ViewContext.HttpContext.RequestServices
            .GetService(typeof(ModelExpressionProvider)) as ModelExpressionProvider;

            var ime = helper
                    .ViewContext
                    .ViewData
                    .TemplateInfo
                    .GetFullHtmlFieldName(expressionProvider.GetExpressionText(expression));

            List<string> Tekstualni = new List<string>();
            List<string> Slike = new List<string>();
            List<string> Ostali = new List<string>();
           

            foreach (SelectListItem opcija in opcije)
            {
                if (opcija.Text == ".txt" || opcija.Text == ".pdf" || opcija.Text == ".docx" || opcija.Text == ".rtf")
                {
                    
                    if(!Tekstualni.Contains(opcija.Text))
                    Tekstualni.Add(opcija.Text.ToString());
                }
                else if (opcija.Value == ".jpg" || opcija.Value == ".png" || opcija.Value == ".gif")
                {
                    if(!Slike.Contains(opcija.Text))
                    Slike.Add(opcija.Text.ToString());
                }
                else
                    if(!Ostali.Contains(opcija.Text))
                    Ostali.Add(opcija.Text.ToString());
            }


            povratak += String.Format("<select  class='select2formati' multiple='multiple' name='formati'>");

            if(Tekstualni.Count > 0)
            {
                povratak += String.Format("<optgroup label='Tekstualni'>");

                foreach (string ekstenzijaTekst in Tekstualni)
                {
                    povratak += String.Format("<option value ='{0}'>{1}</option>", ekstenzijaTekst, ekstenzijaTekst);
                }

                povratak += String.Format("</optgroup>");
            }



            if (Slike.Count > 0)
            {
                povratak += String.Format("<optgroup label='Slike'>");

                foreach (string ekstenzijaSlike in Slike)
                {
                    povratak += String.Format("<option value='{0}'>{1}</option>", ekstenzijaSlike, ekstenzijaSlike);
                }

                povratak += String.Format("</optgroup>");
            }


            if (Ostali.Count > 0)
            {
                povratak += String.Format("<optgroup label='Ostali'>");

                foreach (string ekstenzijaOstalo in Ostali)
                {
                    povratak += String.Format("<option value='{0}'>{1}</option>", ekstenzijaOstalo, ekstenzijaOstalo);
                }

                povratak += String.Format("</optgroup>");                
            }

            povratak += String.Format("</select>");

            return povratak; 
        }
    }
}