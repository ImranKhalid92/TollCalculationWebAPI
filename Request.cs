using System;
using TollCalculation.Common;

namespace TollCalculation.Models
{
    public class Request
    {
        /// <summary>
        /// InterChange
        /// </summary>
        public TollPlaza InterChange { get; set; }

        /// <summary>
        /// Vehicle number
        /// </summary>
        public string NumberPlate { get; set; }

        /// <summary>
        /// The date and time of entry
        /// </summary>
        public DateTime EntryTime { get; set; }
    }
}
