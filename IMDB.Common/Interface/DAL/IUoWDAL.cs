using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Common.Interface.DAL
{
    public interface IUoWDAL
    {
        IMoviesDAL MovieDAL { get; set; }
        IActorDAL ActorDAL { get; set; }
        IProducerDAL ProducerDAL { get; set; }
    }
}
