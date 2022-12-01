//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practika.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductOrder = new HashSet<ProductOrder>();
            this.ShipmentProduct = new HashSet<ShipmentProduct>();
            this.SuppliersCountry = new HashSet<SuppliersCountry>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DateOfAddition { get; set; }
        public Nullable<int> UnitOfMeansurementId { get; set; }
        public Nullable<int> QuantityInStock { get; set; }
    
        public virtual UnitOfMeansurement UnitOfMeansurement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShipmentProduct> ShipmentProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuppliersCountry> SuppliersCountry { get; set; }
    }
}
