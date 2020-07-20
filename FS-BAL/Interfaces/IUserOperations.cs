using FS_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FS_BAL.Interfaces
{
    public interface IUserOperations
    {
        UserInfoDTO UserInfoMapping(UserInfoDTO userInfo);
        UserInfoDTO GetUserInfoById(string id);
    }
}
