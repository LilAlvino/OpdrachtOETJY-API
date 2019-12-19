using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Betabit.Spaces.Repositories;

namespace Betabit.Spaces.Api
{
    public class SpacesFunction
    {
        private readonly ISpacesRepository spacesRepository;
        private readonly IReservationsRepository reservationsRepository;

        public SpacesFunction(
            ISpacesRepository spacesRepository,
            IReservationsRepository reservationsRepository)
        {
            this.spacesRepository = spacesRepository;
            this.reservationsRepository = reservationsRepository;
        }


        /// <summary>
        /// Gets a complete list of all available spaces
        /// </summary>
        /// <param name="req">The HTTP Request</param>
        [FunctionName("GetSpaces")]
        public async Task<IActionResult> GetSpaces([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Spaces")] HttpRequest req) 
            => new OkObjectResult(await spacesRepository.GetSpaces());

        [FunctionName("GetSpace")]
        public async Task<IActionResult> GetSpace([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Spaces/{code}")] HttpRequest req, string code)
            => new OkObjectResult(await spacesRepository.GetSpace(code));

        [FunctionName("GetSpaceReservations")]
        public async Task<IActionResult> GetSpaceReservations([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Spaces/{code}/Reservations")] HttpRequest req, string code)
            => new OkObjectResult(await reservationsRepository.GetReservationsBySpaceCode(code));
    }
}
