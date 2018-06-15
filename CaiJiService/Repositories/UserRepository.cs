using CaiJiService.Models;
using CaiJiService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiJiService.Repositories
{
    public partial class UserRepository : BaseRepository<User>, IUserRepository
    {
    }
}