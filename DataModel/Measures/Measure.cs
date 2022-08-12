using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Measures
{
    public class Measure
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
