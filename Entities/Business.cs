using Entities.Interfaces;
using System.Collections.Generic;

namespace Entities
{
    /// <summary>
    /// Represents a trading entity of some kind
    /// (Renamed from "company" as sole traders aren't companies)
    /// </summary>
    public abstract class Business
    {
        public string Name { get; set; }
        public IAddress Address { get; set; }

        public IList<Employment> Employments { get; set; }
    }
}