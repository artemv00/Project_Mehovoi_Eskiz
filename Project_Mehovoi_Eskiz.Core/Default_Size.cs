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
    
    public partial class Default_Size
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Default_Size()
        {
            this.Cat_product = new HashSet<Cat_product>();
        }
    
        public int RU_size { get; set; }
        public string Waste_size { get; set; }
        public string Hips_size { get; set; }
        public string Breast_size { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cat_product> Cat_product { get; set; }
    }
}
