﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataHandler.Models
{
    public partial class ProductFamily
    {
        public ProductFamily()
        {
            Device = new HashSet<Device>();
        }

        [Key]
        public int ProductFamilyId { get; set; }
        [Required]
        public string ProductName { get; set; }

        [InverseProperty("ProductFamily")]
        public virtual ICollection<Device> Device { get; set; }
    }
}