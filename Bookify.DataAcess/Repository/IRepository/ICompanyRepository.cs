using Bookify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.DataAcess.Repository.IRepository
{
    public interface ICompanyRepository:IRepository<Company>
    {
        public void Update(Company obj);

    }
}
