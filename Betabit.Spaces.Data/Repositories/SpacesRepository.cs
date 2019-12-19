using Betabit.Spaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betabit.Spaces.Repositories
{
    public class SpacesRepository : ISpacesRepository
    {
        private static List<Space> spaces = new List<Space>
        {
            new Space{Code="101", Description="Small conference room on the first floor", Capacity=12},
            new Space{Code="102",  Description="Conference room on the first floor", Capacity=50},
            new Space{Code="1WC1",  Description="Toilet on the first floor", Capacity=1},
            new Space{Code="1WC2",  Description="Toilet on the first floor", Capacity=1},
            new Space{Code="201", Description= "Conference room on the second floor", Capacity=100},
            new Space{Code="2WC1",  Description="Toilet on the second floor", Capacity=1},
            new Space{Code="2WC2", Description= "Toilet on the second floor", Capacity=1},
            new Space{Code="2WC3",  Description="Toilet on the second floor", Capacity=1},
            new Space{Code="2WC4",  Description="Toilet on the second floor", Capacity=1},
        };

        public async Task<Space> GetSpace(string code) => await (Task.FromResult(spaces.Single(s => s.Code == code)));
        public async Task<IList<Space>> GetSpaces() => await Task.FromResult(spaces);
        public async Task<bool> CheckIfSpaceExists(string code) => await (Task.FromResult(spaces.Any(s => s.Code == code)));

    }
}
