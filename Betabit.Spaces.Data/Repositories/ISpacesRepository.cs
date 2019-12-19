using Betabit.Spaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Betabit.Spaces.Repositories
{
    public interface ISpacesRepository
    {
        Task<IList<Space>> GetSpaces();
        Task<Space> GetSpace(string code);
        Task<bool> CheckIfSpaceExists(string code);
    }
}