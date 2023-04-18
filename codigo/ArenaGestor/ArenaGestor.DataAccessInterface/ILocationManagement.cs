using ArenaGestor.Domain;
using System;
using ArenaGestor.Domain;
using System;
using System.Collections.Generic;

namespace ArenaGestor.DataAccessInterface
{
    public interface ILocationManagement
    {
        Location GetLocationById(int id);
    }
}


