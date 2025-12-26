using Moq;
using SistemaVendas.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTestUtilies.Repositories
{
    public class VendaRepositoryBuilder
    {
        public static IVendaRepository Build()
        {


            var mock = new Mock<IVendaRepository>();

            return mock.Object;
        }
    }
}
