using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TJS.VIMS.Models;

namespace TJS.VIMS.ViewModel
{
    public class LocationViewModel
    {
        private List<Location> locations { get; set; }
        public int SelectedLocationId { get; set; }

        public LocationViewModel() { }

        public LocationViewModel(List<Location> locations)
        {
            this.locations = locations;
        }
        
        public IEnumerable<SelectListItem> LocationSelectList
        {
           get
            {
                var locationListItem = locations.Select(m => new SelectListItem
                {
                    Value = m.LocationId.ToString(),
                    Text = m.LocationName
                });
                return DefaultItem.Concat(locationListItem);
            }            
        }

        public IEnumerable<SelectListItem> DefaultItem
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select a location"
                }, count: 1);
            }
        }
    }
}