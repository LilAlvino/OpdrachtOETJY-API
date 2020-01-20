using Betabit.Spaces.Models;
using Betabit.Spaces.Repositories;
using Betabit.Spaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Betabit.Spaces.Api
{
    public class ReservationsFunctions
    {
        private readonly IReservationsRepository reservationsRepository;
        private readonly IReservationsService reservationsService;


        public ReservationsFunctions(
            IReservationsRepository reservationsRepository, 
            IReservationsService reservationsService)
        {
            this.reservationsRepository = reservationsRepository;
            this.reservationsService = reservationsService;
        }

        [FunctionName("GetReservations")]
        public async Task<IActionResult> GetReservations([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Reservations")] HttpRequest req)
        {
            return new OkObjectResult(await reservationsRepository.GetReservations());
        }


        [FunctionName("PostReservation")]
        public async Task<IActionResult> PostReservation([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Reservations")] HttpRequest req)
        {
            var body = await req.ReadAsStringAsync();
            var reservation = JsonSerializer.Deserialize<Reservation>(body);
            await reservationsService.SaveReservation(reservation);
            return new OkResult();
        }
    }
}
