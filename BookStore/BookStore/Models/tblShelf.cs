//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblShelf
    {
        public int Shelf_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<int> Book_id { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
