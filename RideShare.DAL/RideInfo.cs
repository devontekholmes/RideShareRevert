//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RideShare.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class RideInfo
    {
        public int DriverId { get; set; }
        public string Email { get; set; }
        public System.DateTime Time { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
