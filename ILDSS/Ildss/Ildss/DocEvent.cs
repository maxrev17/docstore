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
    
    public partial class DocEvent
    {
        public int DocEventId { get; set; }
        public System.DateTime date_time { get; set; }
        public string type { get; set; }
        public string DocumentDocumentHash { get; set; }
        public string path { get; set; }
        public string old_path { get; set; }
        public string name { get; set; }
        public string old_name { get; set; }
    
        public virtual Document Document { get; set; }
    }
}
