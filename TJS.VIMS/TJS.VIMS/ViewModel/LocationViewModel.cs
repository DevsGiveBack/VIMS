using System.Collections.Generic;
using System.Web.Mvc;
using TJS.VIMS.Models;
using System.Linq;



namespace TJS.VIMS.ViewModel
{
    public class LocationViewModel
    {
        private List<Location> lsLocation { get; set; }

       public int SelectedLocationId { get; set; }      

       public LocationViewModel(List<Location> lsLocation)
        {
            this.lsLocation = lsLocation;
        }

        public LocationViewModel() { }

        public IEnumerable<SelectListItem> LocationSelectListItem
        {
           get
            {
                var locationListItem = lsLocation.Select(x => new SelectListItem
                {
                    Value = x.LocationId.ToString(),
                    Text = x.LocationName
                });
                return DefaultFlavorItem.Concat(locationListItem);
            }            
        }

        public IEnumerable<SelectListItem> DefaultFlavorItem
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