using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJS.VIMS.Models;

namespace TJS.VIMS.ViewModel
{
    public class EditLocationsViewModel
    {
        public Location Location { get; set; }

        //[StringLength(100)]
        //public string LocationName { get; set; }

        //[StringLength(50)]
        //public string Address1 { get; set; }

        //[StringLength(50)]
        //public string Address2 { get; set; }

        //[StringLength(10)]
        //public string ZipCode { get; set; }

        //[StringLength(250)]
        //public string Notes { get; set; }

        //public int SelectedCountryId { get; set; }
        public List<Country> countries { get; set; }
        public List<State> states { get; set; }

        public IEnumerable<SelectListItem> CountrySelectList
        {
            get
            {
                var list = countries.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.CountryName
                });
                return list;
            }
        }

        public IEnumerable<SelectListItem> StateSelectList
        {
            get
            {
                var list = states.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.StateName
                });
                return list;
            }
        }
    }
}