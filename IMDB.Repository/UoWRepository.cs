using IMDB.Common.Interface.DAL;
using IMDB.Common.Interface.Repository;
using IMDB.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Repository
{

    public class UoWRepository : IUoWRepository
    {
        public UoWRepository()
            : this(new UoWDAL())
        {
        }

        public UoWRepository(IUoWDAL dalContext)
        {
            _dalContext = dalContext;
        }

        private IUoWDAL _dalContext = null;
        private IMoviesRepository _movieRep = null;
        private IActorRepository _actorRep = null;
        private IProducerRepository _producerRep = null;


        /// <summary>
        /// 
        /// </summary>
        public IActorRepository ActorRep
        {
            get
            {
                if (_actorRep == null)
                    _actorRep = new ActorRepository(_dalContext);
                return _actorRep;
            }

            set
            {
                _actorRep = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IMoviesRepository MoviesRep
        {
            get
            {
                if (_movieRep == null)
                    _movieRep = new MovieRepository(_dalContext);
                return _movieRep;
            }

            set
            {
                _movieRep = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IProducerRepository ProducerRep
        {
            get
            {
                if (_producerRep == null)
                    _producerRep = new ProducerRepository(_dalContext);
                return _producerRep;
            }

            set
            {
                _producerRep = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IUoWDAL UOWDal
        {
            get
            {
                if (_dalContext == null)
                    _dalContext = new UoWDAL();
                return _dalContext;
            }

            set
            {
                _dalContext = value;
            }
        }
    }
}
