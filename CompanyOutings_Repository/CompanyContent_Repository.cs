using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings_Repository
{
    public class CompanyContent_Repository
    {
        private List<CompanyContent> _listOfOutings = new List<CompanyContent>();

        //Create
        public void AddCompanyOuting(CompanyContent outing)
        {
            _listOfOutings.Add(outing);
        }

        //Read
        public List<CompanyContent> DisplayCompanyOutings()
        {
            return _listOfOutings;
        }

        //Update
        public bool UpdateExistingOutings(string originalOuting, CompanyContent newOuting)
        {
            //Find the content first
            CompanyContent oldContent = GetContentByType(int.Parse(originalOuting));
            

            //Update the content
            if(oldContent != null)
            {
                oldContent.EventName = newOuting.EventName;
                oldContent.Attendees = newOuting.Attendees;
                oldContent.CostPerPerson = newOuting.CostPerPerson;
                oldContent.TotalCost = newOuting.TotalCost;
                oldContent.Date = newOuting.Date;
                oldContent.TotalCost = newOuting.TotalCost;
                oldContent.TypeOfEvent = newOuting.TypeOfEvent;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete --- Don't need to worry about this yet

        //Helper method to help display
        public CompanyContent GetContentByType(int typeOfEvent)
        {
            foreach(CompanyContent outing in _listOfOutings)
            {
                if((int)outing.TypeOfEvent == typeOfEvent)
                {
                    return outing;
                }
            }
            return null;
        }
    }
}
