//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StationeryApp.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pickup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pickup()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int PickupID { get; set; }
        public string PickupIndex { get; set; }
        public string PickupCity { get; set; }
        public string PickupStreet { get; set; }
        public string PickupBuilding { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}