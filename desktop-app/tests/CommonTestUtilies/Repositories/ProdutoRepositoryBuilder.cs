using Moq;
using SistemaVendas.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTestUtilies.Repositories
{
    public class ProdutoRepositoryBuilder
    {

        public static IProdutoRepository Build()
        {


            var mock = new Mock<IProdutoRepository>();

            return mock.Object;
        }
    }
}
