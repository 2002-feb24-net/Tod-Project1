using System;
using System.Collections.Generic;
using System.Text;
using project1.logic.Interfaces;

namespace project1.logic.Models
{
    /// <summary>
    /// small class for restaurant locations
    /// </summary>
    public class Locations : ILocations
    {
        public string cityState { get; set; }
        public int locNum { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="cityState"></param>
        /// <param name="locNum"></param>
        public Locations(string cityState, int locNum)
        {
            this.cityState = cityState;
            this.locNum = locNum;
        }
    }
}
