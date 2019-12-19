using Betabit.Spaces.Models;
using System.Threading.Tasks;

namespace Betabit.Spaces.Repositories
{
    public interface IReservationsRepository
    {
        Task<Reservation[]> GetReservationsBySpaceCode(string code);
        Task SaveReservation(Reservation reservation);
        Task<Reservation[]> GetReservations();
    }
}