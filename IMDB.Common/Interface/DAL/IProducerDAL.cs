using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Common.Interface.DAL
{
    public interface IProducerDAL
    {
        List<Producer> GetProducer();
        string AddProducer(Producer producer);
        bool EditProducer(Producer producer);
        bool DeleteProducer(int producerId);
        Producer GetProducerById(int Id);
    }
}
