//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KURSOVAYA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class NameShow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NameShow()
        {
            this.Show = new HashSet<Show>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public int AgeLimitID { get; set; }
        public string Photo { get; set; }
    
        public virtual AgeLimit AgeLimit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Show> Show { get; set; }
    }
}
