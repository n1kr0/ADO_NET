//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gym
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public System.DateTime DateStart { get; set; }
        public double Weight { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public Nullable<int> IdTrener { get; set; }
    
        public virtual Coachs Coachs { get; set; }
    }
}
