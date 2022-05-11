﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataHandler.Models
{
    public partial class ConnectionCapability
    {
        [Key]
        public int ConnectionCapabilityId { get; set; }
        public int ConnectionTypeId { get; set; }
        public int DeviceId { get; set; }

        [ForeignKey("ConnectionTypeId")]
        [InverseProperty("ConnectionCapability")]
        public virtual ConnectionType ConnectionType { get; set; }
        [ForeignKey("DeviceId")]
        [InverseProperty("ConnectionCapability")]
        public virtual Device Device { get; set; }
    }
}