//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgPOE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_surname { get; set; }
        public Nullable<System.DateTime> emp_DOB { get; set; }
        public string emp_cell { get; set; }
        public string emp_email { get; set; }
        public string user_username { get; set; }
    
        public virtual Login_Credentials Login_Credentials { get; set; }
    }
}
