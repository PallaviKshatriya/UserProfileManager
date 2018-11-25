using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserProfiles.Model
{
    public class UserProfileSystemSetting
    {
        public LocalSystem LocalSystem { get; set; }
        public bool IsBranchLnActive { get; set; }
        public bool IsBranchBrActive { get; set; }
        public bool IsBranchPrActive { get; set; }
        public bool IsBranchDfActive { get; set; }
        public UserLevelCategory Category { get; set; }
    }
}
