namespace BlaisePascal.TestSimulation.Domain
{
    public class Venue
    {
        public string Name { get; private set; }
        public List<Event> Events { get; private set; }

        public Venue(string name)
        {
            Name = name;
            Events = new List<Event>();
        }

        public void AddEvent(string name, DateOnly day, EventTags[] tags, double cost)
        {
            Events.Add(new Event(name, day, (int)cost, tags));
        }

        public List<Event> MostExpensiveEvent()
        {
            int highestCost = 0;
            foreach (Event ev in Events)
            {
                if (ev.Cost > highestCost) highestCost = ev.Cost;
            }

            List<Event> mostExpensive = new List<Event>();
            foreach (Event ev in Events)
            {
                if (ev.Cost == highestCost) mostExpensive.Add(ev);
            }

            return mostExpensive;
        }

        public List<EventTags> GetExistentTags()
        {
            List<EventTags> existentTag = new List<EventTags>();
            foreach (Event ev in Events)
            {
                foreach (EventTags t in ev.EventTags)
                {
                    bool alreadyAdded = false;
                    foreach (EventTags added in existentTag)
                    {
                        if (added == t) { alreadyAdded = true; }
                    }
                    if (!alreadyAdded) existentTag.Add(t);
                }
            }
            return existentTag;
        }

        public EventTags[] MostPopularTag()
        {
            List<EventTags> existentTag = GetExistentTags();
            List<int> count = new List<int>();

            for (int i = 0; i < existentTag.Count; i++)
            {
                foreach(Event ev in Events)
                {
                    if (ev.ContainsTag(existentTag[i])) count[i]++;
                }
            }

            int highestCount = 0;

            foreach(int c in count) 
            {
                if (c > highestCount)
                {
                    highestCount = c;
                }
            }

            List<EventTags> mostPopularTags = new List<EventTags>();
            for(int i=0; i<count.Count; i++)
            {
                if (count[i] == highestCount) mostPopularTags.Add(existentTag[i]);
            }
            return mostPopularTags.ToArray();
        }

        public Event[] CompatibleTag(EventTags tags)
        {

            List<Event> compatibleEvents = new List<Event>();
            for (int i = 0; i < Events.Count; i++)
            {
                if (Events[i].ContainsTag(tags)) compatibleEvents.Add(Events[i]);
            }
            return compatibleEvents.ToArray();
        }

        public Event[] CompatibleTags(EventTags[] tags)
        {
            
            List<Event> compatibleEvents = new List<Event>();
            for (int i = 0; i < Events.Count; i++)
            {
                if (Events[i].ContainsTags(tags)) compatibleEvents.Add(Events[i]);
            }
            return compatibleEvents.ToArray();
        }

        
        public int[,] GenerateEventTagsMatrix()
        {
            List<EventTags> existentTags = GetExistentTags();
            int[,] matrix = new int[existentTags.Count, Events.Count];
            for (int i=0; i< existentTags.Count; i++)
            {
                for(int j=0; j< Events.Count; j++)
                {
                    if (Events[j].ContainsTag(existentTags[i]))
                        matrix[j,i] = 1;
                    else
                        matrix[j,i] = 0;
                }
            }
            return matrix;
        }

        public Event[][] GenerateJaggedEventTags()
        {
            List<EventTags> existentTags = GetExistentTags();
            Event[][] jagged = new Event[existentTags.Count][];
            
            for(int i=0; i< existentTags.Count; i++)
            {
                jagged[i] = CompatibleTag(existentTags[i]);
            }
            return jagged;
        }
        public Event[][] GenerateJaggedEventTagsNoCompatibleTags()
        {
            List<EventTags> existentTags = GetExistentTags();
            Event[][] jagged = new Event[existentTags.Count][];

            for (int i = 0; i < existentTags.Count; i++)
            {
                List<Event> compatibleEvents = new List<Event>();
                for (int j = 0; j < Events.Count; j++)
                {
                    if (Events[j].ContainsTag(existentTags[j])) compatibleEvents.Add(Events[j]);
                }
                jagged[i] = compatibleEvents.ToArray();
            }
            return jagged;
        }
    }
}
    

