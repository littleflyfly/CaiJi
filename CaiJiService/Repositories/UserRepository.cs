using CaiJi.API.Models;
using CaiJi.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaiJi.API.Repositories
{
    public partial class UserRepository : BaseRepository<User>, IUserRepository
    {
    }
}