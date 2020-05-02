using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerUtilityApp.API.Models;

namespace TaskTrackerUtilityApp.API.Data.Contracts
{
    public interface ILoginRespository
    {

        string Authenticate(string username, string password);

    }
}
