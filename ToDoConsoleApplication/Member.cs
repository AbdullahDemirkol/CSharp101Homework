using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoConsoleApplication
{
    internal class Member
    {
        private List<Member> _members;
        public int Id { get; set; }
        public string TeamMemberName { get; set; }

        public Member()
        {
            _members = new List<Member>();
        }
        public Member(int id, string teamMemberName)
        {
            Id = id;
            TeamMemberName = teamMemberName;
        }

        public void AddMember(Member member)
        {
            _members.Add(member);
        }
        public List<Member> GetMembers()
        {
            return _members;
        }
    }
}
