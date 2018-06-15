using CaiJiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiJiService.Repositories
{
    public partial class DbContextFactory
    {
        private static CaiJiDBContext db;
        
        public static CaiJiDBContext Create()
        {
            if (db == null)
            {
                db = new CaiJiDBContext();
            }
            return db;
        }
    }
}