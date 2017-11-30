using PICodeFirst.GoToTheCloud.App.consts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PICodeFirst.GoToTheCloud.App.UserModel
{
    public class User
    {
        private readonly IList<Group> _groups;


        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Group> Groups => _groups;
        public bool IsApplicationAdministrator { get; set; }

        public User(Guid id)
        {
            Id = id;
            _groups = new List<Group>();
        }

        public void AddGroup(Group group)
        {
            _groups.Add(group);
            
        }
    }
}
