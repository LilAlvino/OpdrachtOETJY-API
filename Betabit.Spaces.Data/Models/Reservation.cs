using System;
using System.Collections.Generic;
using System.Text;

namespace Betabit.Spaces.Models
{
    public class Reservation
    {
        /// <summary>
        /// The identifier for the space
        /// </summary>
        public string SpaceCode { get; set; }

        /// <summary>
        /// The the date/time the reservation begins
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// The date/time the reservastion finishes
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// The person who made the reservation
        /// </summary>
        public string Reserver { get; set; }

        /// <summary>
        /// Optional additional comments
        /// </summary>
        public string Description { get; set; }
    }
}
