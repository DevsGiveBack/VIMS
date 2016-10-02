using System.Collections.Generic;
using System.Web.Mvc;
using TJS.VIMS.Models;
using System.Linq;


namespace TJS.VIMS.ViewModel
{
    public class VolunteerViewModel
    {
        public VolunteerInfo VolunteerInfo { get; set; }
        public VolunteerProfileInfo VolunteerProfile { get; set; }
        private List<Location> lsLocation { get; set; }
        private List<Organization> lsOrganization { get; set; }

        public int LocationSelectedId { get; set; }
        public int OrganizationSelectedId { get; set; }

        public VolunteerViewModel(List<Location> lsLocation)
        {
            VolunteerInfo = new VolunteerInfo();
            VolunteerProfile = new VolunteerProfileInfo();
            this.lsLocation = lsLocation;
        }

        public IEnumerable<SelectListItem> LocationSelectListItem
        {
            get
            {
                var locationListItem = lsLocation.Select(x => new SelectListItem
                {
                    Value = x.LocationId.ToString(),
                    Text = x.LocationName
                });
                return DefaultLocationFlavorItem.Concat(locationListItem);
            }
        }

        public IEnumerable<SelectListItem> DefaultLocationFlavorItem
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

        public IEnumerable<SelectListItem> OrganizationSelectListItem
        {
            get
            {
                IEnumerable<SelectListItem> organizationListItem;
                List<SelectListItem> tmpList = new List<SelectListItem>();
                tmpList.Add(new SelectListItem { Text = "INFORMATIONAL", Value = "INFORMATIONAL" });

                if (lsOrganization != null)
                {
                    organizationListItem = lsOrganization.Select(x => new SelectListItem
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
                return DefaultOrganizationFlavorItem.Concat(organizationListItem);
            }
        }

        public IEnumerable<SelectListItem> DefaultOrganizationFlavorItem
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