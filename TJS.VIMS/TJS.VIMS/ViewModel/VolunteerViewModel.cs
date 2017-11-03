using System.Collections.Generic;
using System.Web.Mvc;
using TJS.VIMS.Models;
using System.Linq;

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

        public VolunteerViewModel(List<Location> locations) 
        {
            VolunteerInfo = new VolunteerInfo();
            VolunteerProfile = new VolunteerProfileInfo();
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
                return DefaultLocationItem.Concat(locationListItem);
            }
        }

        public IEnumerable<SelectListItem> DefaultLocationItem
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

        public IEnumerable<SelectListItem> OrganizationSelectList
        {
            get
            {
                IEnumerable<SelectListItem> organizationListItem;
                List<SelectListItem> tmpList = new List<SelectListItem>();
                tmpList.Add(new SelectListItem { Text = "INFORMATIONAL", Value = "INFORMATIONAL" });

                if (organizations != null)
                {
                    organizationListItem = organizations.Select(x => new SelectListItem
                    {
                        Value = x.OrganizationId.ToString(),
                        Text = x.OrganizationName
                    });
                }
                else
                {
                    organizationListItem = tmpList.Select(x => new SelectListItem
                    { Text = "INFORMATIONAL", Value = "INFORMATIONAL" });
                }
                return DefaultOrganizationItem.Concat(organizationListItem);
            }
        }

        public IEnumerable<SelectListItem> DefaultOrganizationItem
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select Organization"
                }, count: 1);
            }
        }
    }
}