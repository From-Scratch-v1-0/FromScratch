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
        void updatePersonInfo(UserInfoDTO userInfo);
        void addNewSkill(UserInfoDTO userInfoDTO);
    }
}
