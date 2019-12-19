using Betabit.Spaces.Models;
using System.Threading.Tasks;

namespace Betabit.Spaces.Services
{
    public interface IReservationsService
    {
        Task SaveReservation(Reservation reservation);
    }
}