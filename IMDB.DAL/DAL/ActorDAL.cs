using IMDB.Common.Interface.DAL;
using IMDB.DAL.Models;
using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.DAL.DAL
{
    public class ActorDAL : IActorDAL
    {
        private IMDBDatabaseContext _context = null;

        public ActorDAL()
            : this(new IMDBDatabaseContext())
        {

        }

        public ActorDAL(IMDBDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add actors to the actor table
        /// </summary>
        /// <param name="actor"></param>
        public string AddActor(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
            return actor.ActorId.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actorId"></param>
        public bool DeleteActor(int actorId)
        {
            if (actorId > 0)
            {
                var actor = _context.Actors.Where(a => a.ActorId == actorId).SingleOrDefault();
                _context.Actors.Remove(actor);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        public bool EditActor(Actor actor)
        {
            if (actor.ActorId >= 0)
            {
                var foundActor = _context.Actors.Where(a => a.ActorId == actor.ActorId).SingleOrDefault();
                if (foundActor != null)
                {
                    foundActor.ActorName = actor.ActorName;
                    foundActor.Bio = actor.Bio;
                    foundActor.DOB = actor.DOB;
                    foundActor.Gender = actor.Gender;
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public Actor GetActorById(int Id)
        {
            var actor = _context.Actors.SingleOrDefault(a => a.ActorId == Id);
            return actor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Actor> GetActors()
        {
            return _context.Actors.ToList();
        }

        public List<Actor> GetActors(List<int> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }                

            var actors = _context.Actors.Where(a => ids.Contains(a.ActorId)).ToList();

            if (actors == null)
            {
                return new List<Actor>();
            }

            return actors;
        }
    }
}
