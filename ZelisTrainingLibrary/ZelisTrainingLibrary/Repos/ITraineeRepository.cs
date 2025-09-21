using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface ITraineeRepository
    {
        void Add(Trainee trainee);
        Trainee GetById(int trainingId, int employeeId);
        List<Trainee> GetAll();
        void Update(Trainee trainee, int trainingId, int employeeId);
        void Delete(int trainingId, int employeeId);
    }
}
