using IMDB.Common.Interface.DAL;
using IMDB.Common.Interface.Repository;
using IMDB.DAL.DAL;
using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Repository
{
    public class ActorRepository : IActorRepository
    {
        private IUoWDAL _dalContext = null;

        public ActorRepository()
            : this(new UoWDAL())
        {

        }

        public ActorRepository(IUoWDAL dalContext)
        {
            _dalContext = dalContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        public string AddActor(Actor actor)
        {
            string result = _dalContext.ActorDAL.AddActor(actor);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actorId"></param>
        public bool DeleteActor(int actorId)
        {
            bool result = _dalContext.ActorDAL.DeleteActor(actorId);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        public bool EditActor(Actor actor)
        {
            bool result = _dalContext.ActorDAL.EditActor(actor);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Actor> GetActors()
        {
            return _dalContext.ActorDAL.GetActors();
        }

        public List<Actor> GetActors(List<int> ids)
        {
            return _dalContext.ActorDAL.GetActors(ids);
        }

        public Actor GetAtorById(int Id)
        {
            var actor = _dalContext.ActorDAL.GetActorById(Id);
            return actor;
        }
    }
}
