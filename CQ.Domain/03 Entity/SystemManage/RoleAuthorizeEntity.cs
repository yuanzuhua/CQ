﻿/*******************************************************************************
 * Copyright © 2017 Zl 版权所有
 * Author: Zl
 * Description: Tz通用权限
*********************************************************************************/
using System;

namespace CQ.Domain.Entity.SystemManage
{
    public class RoleAuthorizeEntity : IEntity<RoleAuthorizeEntity>, ICreationAudited
    {
        public long F_Id { get; set; }
        public int? F_ItemType { get; set; }
        public long F_ItemId { get; set; }
        public int? F_ObjectType { get; set; }
        public long F_ObjectId { get; set; }
        public int? F_SortCode { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public long? F_CreatorUserId { get; set; }
    }
}
