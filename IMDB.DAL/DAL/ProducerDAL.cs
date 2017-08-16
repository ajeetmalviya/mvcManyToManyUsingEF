using IMDB.Common.Interface.DAL;
using IMDB.DAL.Models;
using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.DAL.DAL
{
    public class ProducerDAL : IProducerDAL
    {
        IMDBDatabaseContext _context = null;

        public ProducerDAL()
            : this(new IMDBDatabaseContext())
        {

        }

        public ProducerDAL(IMDBDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="producer"></param>
        public string AddProducer(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
            return producer.ProducerId.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="producerId"></param>
        public bool DeleteProducer(int producerId)
        {
            if (producerId >= 0)
            {
                var actor = _context.Producers.Where(a => a.ProducerId == producerId).SingleOrDefault();
                _context.Producers.Remove(actor);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="producer"></param>
        public bool EditProducer(Producer producer)
        {
            if (producer.ProducerId >= 0)
            {
                var foundProducer = _context.Producers.Where(a => a.ProducerId == producer.ProducerId).SingleOrDefault();
                if (foundProducer != null)
                {
                    producer.ProducerName = producer.ProducerName;
                    producer.Bio = producer.Bio;
                    producer.DOB = producer.DOB;
                    producer.Gender = producer.Gender;
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Producer> GetProducer()
        {
            return _context.Producers.ToList();
        }

        public Producer GetProducerById(int Id)
        {
            var producer = _context.Producers.SingleOrDefault(p => p.ProducerId == Id);
            return producer;
        }
    }
}
