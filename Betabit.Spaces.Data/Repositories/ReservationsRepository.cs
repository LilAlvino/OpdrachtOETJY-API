using Betabit.Spaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betabit.Spaces.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {
        public static List<Reservation> reservations = new List<Reservation>
        {
            new Reservation{SpaceCode="101", Reserver = "Bart", Start=new DateTime(2020,1,10,14,0,0), End=new DateTime(2020,1,10,15,0,0)},
            new Reservation{SpaceCode="101", Reserver = "Jelle", Start=new DateTime(2020,1,10,15,0,0), End=new DateTime(2020,1,10,16,0,0)},
            new Reservation{SpaceCode="101", Reserver = "Bart", Start=new DateTime(2020,1,11,12,0,0), End=new DateTime(2020,11,1,15,0,0)},
            new Reservation{SpaceCode="101", Reserver = "Jelle", Start=new DateTime(2020,1,11,16,0,0), End=new DateTime(2020,11,1,17,30,0)},
            new Reservation{SpaceCode="102", Reserver = "Bart", Start=new DateTime(2020,1,10,11,0,0), End=new DateTime(2020,10,1,12,0,0)},
            new Reservation{SpaceCode="102", Reserver = "Bart", Start=new DateTime(2020,1,11,11,0,0), End=new DateTime(2020,11,1,12,0,0)},
            new Reservation{SpaceCode="102", Reserver = "Bart", Start=new DateTime(2020,1,12,11,0,0), End=new DateTime(2020,12,1,12,0,0)},
            new Reservation{SpaceCode="201", Reserver = "Jelle", Start=new DateTime(2020,1,1,14,0,0), End=new DateTime(2020,12,31,15,0,0)}
        };

        public async Task<Reservation[]> GetReservationsBySpaceCode(string code)
            => await (Task.FromResult(reservations.Where(s => s.SpaceCode == code).ToArray()));

        public async Task<Reservation[]> GetReservations()
            => await (Task.FromResult(reservations.ToArray()));


        /// <summary>
        /// Saves a reservation without checking the spacecode validity
        /// </summary>
        /// <param name="reservation">The reservation</param>
        public async Task SaveReservation(Reservation reservation)
        {
            if (reservation.End >= reservation.Start) 
                throw new InvalidOperationException("Invalid timespan");

            if (reservations.Any(r=>r.SpaceCode == reservation.SpaceCode && r.Start < reservation.End && r.End > reservation.Start))
                throw new InvalidOperationException("Reservation(s) already exists");

            await Task.Run(() => reservations.Add(reservation));
        }
    }
}
