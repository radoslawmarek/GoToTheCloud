using PICodeFirst.GoToTheCloud.App.consts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PICodeFirst.GoToTheCloud.App.UserModel
{
    public class User
    {
        private readonly IList<Group> _groups;
        private bool _isApplicationAdministrator = false;


        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Group> Groups => _groups;
        public bool IsApplicationAdministrator => _isApplicationAdministrator;

        public User()
        {
            _groups = new List<Group>();
        }

        public void AddGroup(Group group)
        {
            _groups.Add(group);
            if (group.Name == AuthorizationConsts.ApplicationAdministratorGroupName)
            {
                _isApplicationAdministrator = true;
            }
        }
    }
}
