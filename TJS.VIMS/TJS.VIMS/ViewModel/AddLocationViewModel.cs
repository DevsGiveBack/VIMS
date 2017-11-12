using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJS.VIMS.Models;

namespace TJS.VIMS.ViewModel
{
    public class AddLocationViewModel
    {
        public string SelectedCountry { get; set; }
        public List<Country> countries { get; set; }

        public IEnumerable<SelectListItem> CountrySelectListItem
        {
            get
            {
                var list = countries.Select(m => new SelectListItem
                {
                    Value = m.CountryId.ToString(),
                    Text = m.CountryName
                });
                return list;
            }
        }
    }
}