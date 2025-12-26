using Bogus;
using SistemaVendas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTestUtilies.RequisicaoDTOs
{
    public class ClienteDTOBuilder
    {
        public static ClienteDTO Build()
        {
            return new Faker<ClienteDTO>("pt_BR")
                .RuleFor(c => c.Nome, f => f.Name.FullName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("###########")); // 11 dígitos
        }
    }
}