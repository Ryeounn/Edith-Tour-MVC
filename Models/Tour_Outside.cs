//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EdithTour.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tour_Outside
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour_Outside()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    
        public int ID_tour_outside { get; set; }
        public string Tour_Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Place { get; set; }
        public string Place_go { get; set; }
        public string Place_leave { get; set; }
        public string Time_go { get; set; }
        public string Time_leave { get; set; }
        public string Day_go { get; set; }
        public string Day_leave { get; set; }
        public Nullable<int> Numberofpeople { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string Visa_support { get; set; }
        public string Country_code { get; set; }
        public Nullable<int> ID_tour { get; set; }
        public Nullable<int> ID_schedule { get; set; }
    
        public virtual Schedule Schedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
