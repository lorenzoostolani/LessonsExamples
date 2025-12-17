using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Interview.Classroom.Domain.BookingLab
{
    public class LabManager
    {
        //Properties
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        public int TotalSlots { get; private set; }
        public DayOfWeek[] OpeningDays { get; private set; }
        public CourseName[,] Bookings { get; private set; }
        public Hole[][] Holes { get; set; }

        //Constructor
        public LabManager(TimeOnly startTime, TimeOnly endTime, DayOfWeek[] openingDays)
        {
            if (startTime >= endTime)
                throw new ArgumentException("Start time must be before end time.");

            StartTime = startTime;
            EndTime = endTime;
            OpeningDays = openingDays;
            TotalSlots = EndTime.Hour - StartTime.Hour;

            Bookings = new CourseName[openingDays.Length, TotalSlots];
            Holes = new Hole[OpeningDays.Length][];

            //Errore corretto: gli slot non venivano inizializzati come avaiable
            for (int d = 0; d < OpeningDays.Length; d++)
            {
                for (int s = 0; s < TotalSlots; s++)
                    Bookings[d, s] = CourseName.Available;
            }
        }


        //Methods
        public bool CheckBookingAvailability(Booking newBooking)
        {
            int dayIndex = GetDayIndex(newBooking.DayOfWeek);
            if (dayIndex == -1)
                return false;

            int requestedDurationSlots = newBooking.Duration;
            int minStartSlotIndex = FromHourToIndex(newBooking.StartTime.Hour);
            int maxStartSlotIndex = TotalSlots - requestedDurationSlots;

            if (minStartSlotIndex >= TotalSlots || maxStartSlotIndex < 0)
                return false;

            for (int startCandidate = minStartSlotIndex; startCandidate <= maxStartSlotIndex; startCandidate++)
            {
                bool isSlotAvailable = true;

                for (int currentSlot = startCandidate; currentSlot < startCandidate + requestedDurationSlots; currentSlot++)
                {
                    if (Bookings[dayIndex, currentSlot] != CourseName.Available)
                    {
                        isSlotAvailable = false;
                        // Salta direttamente alla prossima posizione utile
                        startCandidate = currentSlot;
                        break;
                    }
                }

                if (isSlotAvailable)
                    return true;
            }

            return false;
        }

        private int GetDayIndex(DayOfWeek day)
        {
            for (int i = 0; i < OpeningDays.Length; i++)
            {
                if (OpeningDays[i] == day)
                {
                    return i;
                }
            }
            return -1;
        }

        public int FromIdxToHour(int idx)
        {
            return idx + StartTime.Hour;
        }

        public int FromHourToIndex(int hour)
        {
            return hour - StartTime.Hour;
        }

        // Classe enum per automa a stati finiti
        private enum HoleState
        {
            OutsideHole,   
            InsideHole     
        }

        public void FindHoles()
        {
            List<int> offset = new List<int>();
            List<int> length = new List<int>();

            for (int row = 0; row < OpeningDays.Length; row++)
            {
                int slot = 0;

                offset.Clear();
                length.Clear();


                HoleState state = HoleState.OutsideHole;
                int holeStart = 0;
                int holeLen = 0;

                while (slot < TotalSlots)
                {
                    switch (state)
                    {
                        case HoleState.OutsideHole:
                            // Entriamo in un buco
                            if (Bookings[row, slot] == CourseName.Available)
                            {
                                state = HoleState.InsideHole;
                                holeStart = slot;
                                

                                holeLen = 1;
                            }

                            slot++;
                            break;

                        case HoleState.InsideHole:
                            // Continuiamo a contare il buco
                            if (slot < TotalSlots && Bookings[row, slot] == CourseName.Available)
                            {
                                holeLen++;
                                slot++;
                            }
                            else
                            {
                                // Usciamo dal buco
                                offset.Add(holeStart);
                                length.Add(holeLen);
                                //Holes[row][col] = new Hole(holeStart, holeLen);
                                

                                state = HoleState.OutsideHole;
                            }

                            break;
                    }
                }

                // Se finiamo l'ultima riga mentre siamo ancora inside hole
                if (state == HoleState.InsideHole)
                {
                    offset.Add(holeStart);
                    length.Add(holeLen);
                }
                Holes[row] = offset.Count > 0 ? new Hole[offset.Count] : Array.Empty<Hole>();
                //Holes[row] = new Hole[offset.Count];
                for (int i = 0; i < offset.Count; i++)
                {
                    Holes[row][i] = new Hole(offset[i], length[i]);
                }

            }
        }


        public bool SmartBooking(Booking newBooking)
        {
            //Controllo che il giorno sia disponibile
            int dayIndex = GetDayIndex(newBooking.DayOfWeek);
            if (dayIndex == -1)
                return false;

            // Aggiorna i buchi
            FindHoles();

            Hole bestHole = null;
            int maxResidual = -1;

            for (int i = 0; i < Holes[dayIndex].Length; i++)
            {
                Hole h = Holes[dayIndex][i];

                // Cerca un buco della lunghezza esatta
                if (h.Lenght == newBooking.Duration)
                {
                    bestHole = h;
                    break; // ho trovato il buco perfetto
                }

                // Cerca altrimenti il buco migliore con il residuo maggiore
                if (h.Lenght > newBooking.Duration) //Controlla che il buco sia abbastanza grande
                {
                    int residual = h.Lenght - newBooking.Duration;
                    if (residual > maxResidual)
                    {
                        maxResidual = residual;
                        bestHole = h;
                    }
                }
            }

            if (bestHole != null)
            {
                BookAtSlot(dayIndex, bestHole.Offset, newBooking);
                return true;
            }
            

            // Nessun buco disponibile
            return false;
        }

        private void BookAtSlot(int dayIndex, int startSlot, Booking booking)
        {
            for (int i = 0; i < booking.Duration; i++)
            {
                Bookings[dayIndex, startSlot + i] = booking.CourseName;
            }
            
            FindHoles();
        }

    }
}
