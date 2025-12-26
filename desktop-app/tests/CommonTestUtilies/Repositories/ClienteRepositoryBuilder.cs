using Moq;
using SistemaVendas.Domain.Interface;
using SistemaVendas.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTestUtilies.Repositories
{
    public  class ClienteRepositoryBuilder
    {

    

        public static IClienteRepository Build()
        {


            var mock = new Mock<IClienteRepository>();

            return mock.Object;
        }
    }
}
