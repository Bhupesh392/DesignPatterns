//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeePortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeDetail
    {
        public int Employee_Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public decimal HourlyPay { get; set; }
        public decimal Bonus { get; set; }
        public int EmployeeTypeID { get; set; }
        public Nullable<decimal> HouseAllowance { get; set; }
        public Nullable<decimal> MedicalAllowance { get; set; }
        public string ComputerDetails { get; set; }
        public string SystemConfigurationDetails { get; set; }
    
        public virtual Employee_Type Employee_Type { get; set; }
    }
}