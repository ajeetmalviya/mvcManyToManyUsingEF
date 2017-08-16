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
    public class ProducerRepository : IProducerRepository
    {
        private IUoWDAL _dalContext = null;

        public ProducerRepository()
            : this(new UoWDAL())
        {

        }

        public ProducerRepository(IUoWDAL dalContext)
        {
            _dalContext = dalContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="producer"></param>
        public string AddProducer(Producer producer)
        {
            string result = _dalContext.ProducerDAL.AddProducer(producer);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="producerId"></param>
        public bool DeleteProducer(int producerId)
        {
            bool result = _dalContext.ProducerDAL.DeleteProducer(producerId);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="producer"></param>
        public bool EditProducer(Producer producer)
        {
            bool result = _dalContext.ProducerDAL.EditProducer(producer);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="producer"></param>
        /// <returns></returns>
        public List<Producer> GetProducer()
        {
            return _dalContext.ProducerDAL.GetProducer();
        }

        public Producer GetProducerById(int Id)
        {
            var producer = _dalContext.ProducerDAL.GetProducerById(Id);
            return producer;
        }
    }
}
