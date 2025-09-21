using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITechnologyRepository
    {
        void Add(Technology technology);
        Technology GetById(int technologyId);
        List<Technology> GetAlltechnologies();
        void Update(Technology technology, int technologyId);
        void Delete(int technologyId);
    }
}
