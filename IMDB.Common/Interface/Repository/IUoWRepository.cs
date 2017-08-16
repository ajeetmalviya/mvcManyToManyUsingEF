using IMDB.Common.Interface.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Common.Interface.Repository
{
    public interface IUoWRepository
    {
        IUoWDAL UOWDal { get; set; }
        IMoviesRepository MoviesRep { get; set; }
        IActorRepository ActorRep { get; set; }
        IProducerRepository ProducerRep { get; set; }
    }
}
