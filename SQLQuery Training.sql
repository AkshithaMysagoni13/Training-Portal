CREATE DATABASE ZelisTrainingDB;

USE ZelisTrainingDB;

CREATE TABLE Employee (
    EmpId INT PRIMARY KEY,
    Name VARCHAR(100),
    Designation VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(15)
);

CREATE TABLE Technology (
    TechnologyId INT PRIMARY KEY,
    Name VARCHAR(100),
    Level CHAR(1) CHECK (Level IN ('B', 'I', 'A')),
    Duration INT -- in days
);

CREATE TABLE Trainer (
    TrainerId INT PRIMARY KEY,
    Name VARCHAR(100),
    Type CHAR(1) CHECK (Type IN ('I', 'E')),
    Email VARCHAR(100),
    Phone VARCHAR(15)
);

CREATE TABLE Training (
    TrainingId INT PRIMARY KEY,
    TrainerId INT,
    TechnologyId INT,
    StartDate DATE,
    EndDate DATE,
    FOREIGN KEY (TrainerId) REFERENCES Trainer(TrainerId),
    FOREIGN KEY (TechnologyId) REFERENCES Technology(TechnologyId)
);

CREATE TABLE Trainee (
    TrainingId INT,
    EmpId INT,
    Status CHAR(1) CHECK (Status IN ('C', 'N')),
    PRIMARY KEY (TrainingId, EmpId),
    FOREIGN KEY (TrainingId) REFERENCES Training(TrainingId),
    FOREIGN KEY (EmpId) REFERENCES Employee(EmpId)
);




Void AddEmployee(Employee employee);
void UpdateEmployee(int empId,Employee employee);
void DeleteEmployee(int empId);
Employee GetEmployeById(int empId);
List<Employee>GetAllEmployees();
List<Employee> GetEmployeesByDesignation(string designation);



Void NewTechnology(Technology technology);
void UpdateTechnology(int techId,Technology technology);
void DeleteTechnology(int techId);
Technology GetTechnology(int techId);
List<Technology>GetTechnologyByLevel(string Level);
List<Technology> GetAllTechnologies();


Void NewTrainer(Trainer trainer);
void UpdateTechnology(int trainerId,Trainer trainer);
void DeleteTechnology(int trainerId);
Trainer GetTrainer(int trainerId);
List<Trainer>GetTrainerByType(string type);
List<Trainer> GetAllTrainers();



void AddTraining(Training training);
void UpdateTraining(int trainingId,Training training);
void DeleteTraining(int trainingId);
Training GetTraining(int id);
List<Training> GetAllTrainings();
List<Training> GetTrainingByTrainerId(int trainerId);
List<Training> GetTrainingByTechnologyId(int technologyId);


void AddTrainee(Trainee trainee);
void UpdateTrainee(int trainingId,int empId,char status);
void DeleteTrainee(int trainingId,int empId);
Trainee GetTrainee(int trainingId,int empId);
List<Trainee> GetAllTrainees();
List<Trainee> GetTraineesByStatus(char status);
List<Trainee> GetTraineesByEmpId(int empId);
List<Trainee> GetTraineesByTrainingId(int trainingId);











    
