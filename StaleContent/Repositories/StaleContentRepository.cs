using System.Linq;

namespace StaleContent.Repositories
{
    public class StaleContentRepository : Sitecore.Services.Core.IRepository<Entities.StaleContent>
    {
        public IQueryable<Entities.StaleContent> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Entities.StaleContent FindById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Entities.StaleContent entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(Entities.StaleContent entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Entities.StaleContent entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Entities.StaleContent entity)
        {
            throw new System.NotImplementedException();
        }
    }
}