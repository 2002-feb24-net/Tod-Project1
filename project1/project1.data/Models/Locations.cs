using System;
using System.Collections.Generic;
using System.Text;

namespace project1.data.Models
{
    /// <summary>
    /// small class for restaurant locations
    /// </summary>
    public class Locations
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
