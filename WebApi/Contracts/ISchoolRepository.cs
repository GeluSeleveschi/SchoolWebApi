using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface ISchoolRepository
    {
        IEnumerable<School> GetAllSchools(bool trackChanges);
    }
}
