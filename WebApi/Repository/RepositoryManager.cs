using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ISchoolRepository _schoolRepository;
        private IStudentRepository _studentRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ISchoolRepository School
        {
            get
            {
                if (_schoolRepository == null)
                    _schoolRepository = new SchoolRepository(_repositoryContext);

                return _schoolRepository;
            }
        }

        public IStudentRepository Student
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_repositoryContext);

                return _studentRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
    }
}