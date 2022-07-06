using System;
using System.Collections.Generic;
using System.Text;

namespace PathofExile2
{
    class MockDB
    {
        private IDictionary<string, string> users;
        public MockDB()
        {
            users = new Dictionary<string, string>();
            users.Add("souledge", "akaviri");
        }
        
        public bool loginCheck(string user, string pass)
        {
            if (users.ContainsKey(user))
            {
                if (users[user] == pass)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
