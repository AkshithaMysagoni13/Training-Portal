using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITrainerRepository
    {
        void Add(Trainer trainer);
        Trainer GetById(int trainerId);
        List<Trainer> GetAlltrainers();
        void Update(Trainer trainer, int trainerId);
        void Delete(int trainerId);
    }
}
