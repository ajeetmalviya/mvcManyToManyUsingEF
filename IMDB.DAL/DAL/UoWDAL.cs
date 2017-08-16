using IMDB.Common.Interface.DAL;
using IMDB.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.DAL.DAL
{
    public class UoWDAL : IUoWDAL
    {
        IMDBDatabaseContext _context = null;
        private IActorDAL _actorDAL = null;
        private IMoviesDAL _moviesDAL = null;
        private IProducerDAL _producerDAL = null;

        public UoWDAL()
            : this(new IMDBDatabaseContext())
        {

        }

        public UoWDAL(IMDBDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        public IActorDAL ActorDAL
        {
            get
            {
                if (_actorDAL == null)
                    _actorDAL = new ActorDAL(_context);
                return _actorDAL;
            }

            set
            {
                _actorDAL = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IMoviesDAL MovieDAL
        {
            get
            {
                if (_moviesDAL == null)
                    _moviesDAL = new MovieDAL(_context);
                return _moviesDAL;
            }

            set
            {
                _moviesDAL = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IProducerDAL ProducerDAL
        {
            get
            {
                if (_producerDAL == null)
                    _producerDAL = new ProducerDAL(_context);
                return _producerDAL;
            }

            set
            {
                _producerDAL = value;
            }
        }
    }
}
