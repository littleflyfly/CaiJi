using CaiJi.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiJi.Client.Repositories
{
    public class UserRepository
    {
        private CaiJiDB db;

        public UserRepository(CaiJiDB db)
        {
            this.db = db;
        }

        public int Add(User entity)
        {
            using (db)
            {
                db.Users.Add(entity);
                int count = db.SaveChanges();
                return count;
            }
        }

        public User GetLast()
        {
            using (db)
            {
                var entity = db.Users.OrderByDescending(a => a.ID).ToList().FirstOrDefault();
                return entity;
            }
        }
    }
}
