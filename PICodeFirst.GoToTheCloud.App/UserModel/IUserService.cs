using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PICodeFirst.GoToTheCloud.App.UserModel
{
    public interface IUserService
    {
        Task<IEnumerable<Group>> GetAllGroups();
    }
}
