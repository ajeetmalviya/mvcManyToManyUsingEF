using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Common.Interface.DAL
{
    public interface IActorDAL
    {
        List<Actor> GetActors();
        List<Actor> GetActors(List<int> ids);
        string AddActor(Actor actor);
        bool EditActor(Actor actor);
        bool DeleteActor(int actorId);
        Actor GetActorById(int Id);
    }
}
