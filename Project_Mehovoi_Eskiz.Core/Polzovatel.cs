//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Mehovoi_Eskiz.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class Polzovatel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Polzovatel()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int User_ID { get; set; }
        public string UName { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string isAdmin { get; set; }
        public string USurname { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual Message Message { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
