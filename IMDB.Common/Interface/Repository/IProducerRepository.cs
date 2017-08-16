using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Common.Interface.Repository
{
    public interface IProducerRepository
    {
        List<Producer> GetProducer();
        string AddProducer(Producer producer);
        bool EditProducer(Producer producer);
        bool DeleteProducer(int producerId);
        Producer GetProducerById(int Id);
    }
}
