using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PICodeFirst.GoToTheCloud.App.UserModel
{
    public interface IUserService
    {
        Task<IEnumerable<Group>> GetAllGroups();
        Task<bool> IsUserInGroup(User user, Guid groupId);
    }
}
