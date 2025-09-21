using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITrainingRepository
    {
        void Add(Training training);
        Training GetById(int trainingId);
        List<Training> GetAlltrainings();
        void Update(Training training, int trainingId);
        void Delete(int trainingId);
    }
}
