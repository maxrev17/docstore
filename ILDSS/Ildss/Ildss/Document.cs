//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ildss
{
    using System;
    using System.Collections.Generic;
    
    public partial class Document
    {
        public Document()
        {
            this.DocPaths = new HashSet<DocPath>();
            this.DocEvents = new HashSet<DocEvent>();
        }
    
        public string DocumentHash { get; set; }
        public long size { get; set; }
    
        public virtual ICollection<DocPath> DocPaths { get; set; }
        public virtual ICollection<DocEvent> DocEvents { get; set; }
    }
}
