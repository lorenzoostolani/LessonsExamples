using BlaisePascal.Interview.Classroom.Domain.BookingLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Interview.Classroom.Domain.UnitTests
{
    public class LabManagerTest
    {

        // Creazione di un laboratorio di default: Lun-Ven, 8-18
        private LabManager CreateDefaultLabManager()
        {
            // TotalSlots = 10. Gli indici vanno da 0 a 9.
            LabManager lm = new LabManager(new TimeOnly(8, 0), new TimeOnly(18, 0), new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday });
            return lm;
        }

        // LabManagerTest.cs - Sezione CheckBookingAvailability

        [Fact]
        public void CheckBookingAvailability_NotInOpeningDays_ReturnsFalse()
        {
            LabManager lm = CreateDefaultLabManager();
            Booking booking = new Booking(CourseName.OOP, 1, new TimeOnly(9, 0), DayOfWeek.Saturday);

            Assert.False(lm.CheckBookingAvailability(booking));
        }
        [Fact]
        public void CheckBookingAvailability_NotInOpeningHour_ReturnsFalse()
        {
            LabManager lm = CreateDefaultLabManager();
            // 19:00 (Indice 11) è fuori dall'orario (max 17:00, indice 9)
            Booking booking = new Booking(CourseName.OOP, 1, new TimeOnly(19, 0), DayOfWeek.Monday);

            Assert.False(lm.CheckBookingAvailability(booking));
        }
        [Fact]
        public void CheckBookingAvailability_ValidDurationAtStart_ReturnsTrue()
        {
            LabManager lm = CreateDefaultLabManager();
            Booking booking = new Booking(CourseName.OOP, 1, new TimeOnly(8, 0), DayOfWeek.Monday);

            Assert.True(lm.CheckBookingAvailability(booking));
        }
        [Fact]
        public void CheckBookingAvailability_ToLongDurationAtStart_ReturnsFalse() // Corretto nome del test
        {
            LabManager lm = CreateDefaultLabManager();
            // 11 ore (slot 0-10) non ci stanno in 10 slot.
            Booking booking = new Booking(CourseName.OOP, 11, new TimeOnly(8, 0), DayOfWeek.Monday);

            Assert.False(lm.CheckBookingAvailability(booking));
        }
        [Fact]
        public void CheckBookingAvailability_ValidDurationInOpeningHour_ReturnsTrue()
        {
            LabManager lm = CreateDefaultLabManager();
            // 1 ora alle 15:00 (slot 7) ci sta.
            Booking booking = new Booking(CourseName.OOP, 1, new TimeOnly(15, 0), DayOfWeek.Monday);

            Assert.True(lm.CheckBookingAvailability(booking));
        }
        [Fact]
        public void CheckBookingAvailability_ToLongDurationInOpeningHour_ReturnsFalse() // Corretto nome del test
        {
            LabManager lm = CreateDefaultLabManager();
            // 4 ore alle 16:00 (slot 8) non ci stanno (8, 9, 10, 11). Max è slot 9.
            Booking booking = new Booking(CourseName.OOP, 4, new TimeOnly(16, 0), DayOfWeek.Monday);

            Assert.False(lm.CheckBookingAvailability(booking));
        }




        [Fact]
        public void FindHoles_AllSlotsAvailable_CreatesSingleHole()
        {
            LabManager lm = CreateDefaultLabManager();

            lm.FindHoles();

            // ci deve essere un solo buco che parte da 0 e lunghezza = TotalSlots
            Assert.Equal(0, lm.Holes[0][0].Offset);
            Assert.Equal(lm.TotalSlots, lm.Holes[0][0].Lenght);
        }
        [Fact]
        public void FindHoles_AllSlotsOccupied_NoHoles()
        {
            var lm = CreateDefaultLabManager();

            // occupiamo tutti gli slot del primo giorno
            for (int i = 0; i < lm.TotalSlots; i++)
            {
                lm.Bookings[0, i] = CourseName.OOP;
            }

            lm.FindHoles();

            // Non deve esserci nessun buco
            Assert.Empty(lm.Holes[0]);
        }


        [Fact]
        public void FindHoles_MultipleNonContiguousHoles_CreatesCorrectHoles()
        {
            var lm = CreateDefaultLabManager();
            // Bookings: [A, O, A, O, A, A, O, A, O, A]
            lm.Bookings[0, 1] = CourseName.OOP; // O slot 1 (9:00)
            lm.Bookings[0, 3] = CourseName.OOP; // O slot 3 (11:00)
            lm.Bookings[0, 6] = CourseName.OOP; // O slot 6 (14:00)
            lm.Bookings[0, 8] = CourseName.OOP; // O slot 8 (16:00)

            lm.FindHoles();

            var holes = lm.Holes[0];
            Assert.Equal(5, holes.Length); // [0], [2], [4, 5], [7], [9]

            Assert.Equal(0, holes[0].Offset); Assert.Equal(1, holes[0].Lenght); // H1: Len 1 (Slot 0)
            Assert.Equal(2, holes[1].Offset); Assert.Equal(1, holes[1].Lenght); // H2: Len 1 (Slot 2)
            Assert.Equal(4, holes[2].Offset); Assert.Equal(2, holes[2].Lenght); // H3: Len 2 (Slot 4, 5)
            Assert.Equal(7, holes[3].Offset); Assert.Equal(1, holes[3].Lenght); // H4: Len 1 (Slot 7)
            Assert.Equal(9, holes[4].Offset); Assert.Equal(1, holes[4].Lenght); // H5: Len 1 (Slot 9)
        }


        [Fact]
        public void FindHoles_HoleAtStartAndEnd_OneBigHoleInMiddle()
        {
            var lm = CreateDefaultLabManager();
            // Bookings: [O, O, A, A, A, A, A, A, O, O]
            lm.Bookings[0, 0] = CourseName.OOP;
            lm.Bookings[0, 1] = CourseName.OOP;
            lm.Bookings[0, 8] = CourseName.OOP;
            lm.Bookings[0, 9] = CourseName.OOP;

            lm.FindHoles();

            var holes = lm.Holes[0];
            Assert.Single(holes);
            Assert.Equal(2, holes[0].Offset); // Inizia a slot 2 (10:00)
            Assert.Equal(6, holes[0].Lenght); // Durata 6 ore (slot 2-7)
        }

        //SmartBooking




        [Fact]
        public void SmartBooking_PerfectFitHole_BookingAllocated()
        {
            var lm = CreateDefaultLabManager();
            // TotalSlots = 10. Buchi: [0, 1] (Len 2), [4, 5] (Len 2), [8, 9] (Len 2)
            lm.Bookings[0, 2] = CourseName.OOP;
            lm.Bookings[0, 3] = CourseName.OOP;
            lm.Bookings[0, 6] = CourseName.OOP;
            lm.Bookings[0, 7] = CourseName.OOP;

            Booking booking = new Booking(CourseName.WebDevelopment, 2, new TimeOnly(8, 0), DayOfWeek.Monday);
            bool allocated = lm.SmartBooking(booking);

            Assert.True(allocated);
            // Tutti e tre sono Perfect Fit (Len 2). Dovrebbe scegliere il primo trovato: Offset 0.
            Assert.Equal(CourseName.WebDevelopment, lm.Bookings[0, 0]);
            Assert.Equal(CourseName.WebDevelopment, lm.Bookings[0, 1]);
        }
        [Fact]
        public void SmartBooking_NoHole_ReturnsFalse()
        {
            var lm = CreateDefaultLabManager();

            // occupiamo tutti gli slot
            for (int i = 0; i < lm.TotalSlots; i++)
                lm.Bookings[0, i] = CourseName.OOP;

            lm.FindHoles();

            Booking booking = new Booking(CourseName.WebDevelopment, 1, new TimeOnly(8, 0), DayOfWeek.Monday);
            bool allocated = lm.SmartBooking(booking);

            Assert.False(allocated);
        }

        [Fact]
        public void SmartBooking_NoAvailableHole_ReturnsFalse()
        {
            var lm = CreateDefaultLabManager();
            // Buchi di max lunghezza 1: [O, A, O, A, O, A, O, A, O, A]
            for (int i = 0; i < lm.TotalSlots; i += 2)
                lm.Bookings[0, i] = CourseName.OOP;

            Booking booking = new Booking(CourseName.WebDevelopment, 2, new TimeOnly(8, 0), DayOfWeek.Monday); // Richiede 2 ore
            bool allocated = lm.SmartBooking(booking);

            Assert.False(allocated);
        }

        [Fact]
        public void SmartBooking_ChooseMaxResidualOverSmallerResidual()
        {
            var lm = CreateDefaultLabManager();
            // Bookings: [A, A, A, O, A, A, O, A, A, A]
            lm.Bookings[0, 3] = CourseName.OOP; // O slot 3
            lm.Bookings[0, 6] = CourseName.OOP; // O slot 6
            lm.FindHoles();

            // Buchi: 
            // H1: [0, 1, 2] (Len 3)
            // H2: [4, 5] (Len 2)
            // H3: [7, 8, 9] (Len 3)

            Booking booking = new Booking(CourseName.DataStructures, 2, new TimeOnly(8, 0), DayOfWeek.Monday); // Richiede 2 ore
            bool allocated = lm.SmartBooking(booking);

            Assert.True(allocated);



            // Test 1: Se H2 (Len 2) è un Perfect Fit, DEVE scegliere H2 (Offset 4).
            Assert.Equal(CourseName.DataStructures, lm.Bookings[0, 4]);
            Assert.Equal(CourseName.DataStructures, lm.Bookings[0, 5]);

            // Test 2: Se invece prenotiamo 1 ora:
            lm = CreateDefaultLabManager();
            lm.Bookings[0, 3] = CourseName.OOP;
            lm.Bookings[0, 6] = CourseName.OOP;

            Booking booking2 = new Booking(CourseName.Calculus, 1, new TimeOnly(8, 0), DayOfWeek.Monday); // Richiede 1 ora
            lm.SmartBooking(booking2);

            // H1 (Len 3), H2 (Len 2), H3 (Len 3).
            // Residui: H1: 2, H2: 1, H3: 2.
            // Dovrebbe scegliere il buco con Max Residuale (2), e tra H1 e H3 sceglie il primo (H1, Offset 0).
            Assert.Equal(CourseName.Calculus, lm.Bookings[0, 0]);
            Assert.Equal(CourseName.Available, lm.Bookings[0, 4]); // Verifica che H2 non sia stato toccato.
        }


        [Fact]
        public void SmartBooking_AllocateBookingUpdatesHoles_CorrectlySplitsLargestHole()
        {
            var lm = CreateDefaultLabManager();
            // Stato iniziale: Slot 4 occupato
            lm.Bookings[0, 4] = CourseName.OOP;

            // Buchi iniziali: H1: [0, 1, 2, 3] (Len 4), H2: [5, 6, 7, 8, 9] (Len 5)

            Booking booking = new Booking(CourseName.WebDevelopment, 3, new TimeOnly(8, 0), DayOfWeek.Monday); // Richiede 3 ore
            bool allocated = lm.SmartBooking(booking);

            Assert.True(allocated);

            // H2 è ha il Max Residual. booking negli slot 5, 6, 7.
            Assert.Equal(CourseName.WebDevelopment, lm.Bookings[0, 5]);
            Assert.Equal(CourseName.WebDevelopment, lm.Bookings[0, 6]);
            Assert.Equal(CourseName.WebDevelopment, lm.Bookings[0, 7]);

            // Verifica il nuovo stato dei buchi
            lm.FindHoles();

            var holes = lm.Holes[0];

            //Dopo l'allocazione, rimangono solo 2 buchi (H1 e il residuo di H2).
            Assert.Equal(2, holes.Length);

            // 1. H1 (uguale a prima): [0, 1, 2, 3]
            Assert.Equal(0, holes[0].Offset);
            Assert.Equal(4, holes[0].Lenght);

            // 2. Nuovo buco (residuo di H2): [8, 9]
            Assert.Equal(8, holes[1].Offset);
            Assert.Equal(2, holes[1].Lenght);

        }
    }
}
