using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.TestSimulation.Domain
{
    public class Event
    {
        

        public DateOnly Date { get; private set; }
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public EventTags[] EventTags { get; private set; }

        public Event(string name, DateOnly date, int cost, EventTags[] tags)
        {
            Name = name;
            Date = date;
            Cost = cost;
            EventTags = tags;
        }

        public bool ContainsTag(EventTags tag)
        {
            for (int i = 0; i < EventTags.Length; i++)
            {
                if (EventTags[i] == tag)
                    return true;
            }
            return false;
        }


        public bool ContainsTags(EventTags[] tags)
        {
            for (int i = 0; i < EventTags.Length; i++)
            {
                if (!ContainsTag(tags[i])) return false;
            }
            return true;
        }
    }
}