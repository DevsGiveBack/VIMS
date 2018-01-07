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

        public Volunteer Volunteer { get; set; }
        public VolunteerProfile VolunteerProfile { get; set; }
        public int LocationSelectedId { get; set; }
        public int OrganizationSelectedId { get; set; }

        public VolunteerViewModel(List<Location> locations, List<Organization> organizations) 
        {
            Volunteer = new Volunteer(); 
            VolunteerProfile = new VolunteerProfile();
            this.locations = locations;
            this.organizations = organizations;
        }

        public IEnumerable<SelectListItem> LocationSelectList
        {
            get
            {
                var items = locations.Select(m => new SelectListItem 
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
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
                    Value = m.Id.ToString(),
                    Text = m.Name
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