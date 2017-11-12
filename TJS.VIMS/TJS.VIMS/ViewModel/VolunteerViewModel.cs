using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using TJS.VIMS.Models;

namespace TJS.VIMS.ViewModel
{
    public class VolunteerViewModel
    {
        private List<Location> locations { get; set; }
        private List<Organization> organizations { get; set; }

        public VolunteerInfo VolunteerInfo { get; set; }
        public VolunteerProfileInfo VolunteerProfile { get; set; }
        public int LocationSelectedId { get; set; }
        public int OrganizationSelectedId { get; set; }

        public VolunteerViewModel(List<Location> locations, List<Organization> organizations) 
        {
            VolunteerInfo = new VolunteerInfo(); 
            VolunteerProfile = new VolunteerProfileInfo();
            this.locations = locations;
            this.organizations = organizations;
        }

        public IEnumerable<SelectListItem> LocationSelectList
        {
            get
            {
                var items = locations.Select(m => new SelectListItem 
                {
                    Value = m.LocationId.ToString(),
                    Text = m.LocationName
                });
                return DefaultItem.Concat(items);
            }
        }
        
        public IEnumerable<SelectListItem> OrganizationSelectList
        {
            get
            {
                var items = organizations.Select(m => new SelectListItem
                {
                    Value = m.OrganizationId.ToString(),
                    Text = m.OrganizationName
                });
                return DefaultItem.Concat(items);
            }
        }

        private IEnumerable<SelectListItem> DefaultItem
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