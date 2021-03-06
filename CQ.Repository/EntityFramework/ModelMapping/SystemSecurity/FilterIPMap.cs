﻿/*******************************************************************************
 * Copyright © 2017 Zl 版权所有
 * Author: Zl
 * Description: Tz通用权限
*********************************************************************************/
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CQ.Domain.Entity.SystemSecurity;

namespace CQ.Repository.EntityFramework
{
    public class FilterIPMap : EntityTypeConfiguration<FilterIPEntity>
    {
        public FilterIPMap()
        {
            this.ToTable("Sys_FilterIP");
            this.Property(t => t.F_Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasKey(t => t.F_Id);
        }
    }
}
