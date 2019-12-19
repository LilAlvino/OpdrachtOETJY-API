using Betabit.Spaces.Models;
using Betabit.Spaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Betabit.Spaces.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly IReservationsRepository reservationsRepository;
        private readonly ISpacesRepository spacesRepository;

        public ReservationsService(
            IReservationsRepository reservationsRepository,
            ISpacesRepository spacesRepository)
        {
            this.reservationsRepository = reservationsRepository;
            this.spacesRepository = spacesRepository;
        }

        /// <summary>
        /// Does integrity checks and saves the reservation
        /// </summary>
        /// <param name="reservation"></param>
        public async Task SaveReservation(Reservation reservation)
        {
            if (!await spacesRepository.CheckIfSpaceExists(reservation.SpaceCode))
                throw new Exception("Unknown Space");

            await reservationsRepository.SaveReservation(reservation);
        }
    }
}
