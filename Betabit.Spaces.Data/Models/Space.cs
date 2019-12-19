using System;

namespace Betabit.Spaces.Models
{
    public class Space
    {
        /// <summary>
        /// A unique reference to identify this room
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Additional information to display about the room
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The number of seats or the numer of people the space is typically used for
        /// </summary>
        public int Capacity { get; set; }
    }
}
