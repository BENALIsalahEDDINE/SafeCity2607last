﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Models.AccountViewModels
{
    public class UserRoleViewModel
    {
        public int CounterId { get; set; }
        public string ApplicationUserId { get; set; }
        public string RoleName { get; set; }
        public bool IsHaveAccess { get; set; }
    }
}
