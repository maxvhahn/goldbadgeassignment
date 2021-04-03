using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings_Repository
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    public class CompanyContent
    {
        public string EventName { get; set; }
        public int Attendees { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCost { get; set; }
        public EventType TypeOfEvent { get; set; }  

        public CompanyContent() { }

        public CompanyContent(string eventName, int attendees, DateTime date, double costPerPerson, double totalCost, EventType typeOfEvent )
        {
            EventName = eventName;
            Attendees = attendees;
            Date = date;
            CostPerPerson = costPerPerson;
            TotalCost = totalCost;
            TypeOfEvent = typeOfEvent;
        }
    }
}
