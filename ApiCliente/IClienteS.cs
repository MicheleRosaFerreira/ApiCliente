
using ApiCliente.Models;

namespace ApiCliente
{
    public interface IClienteS
    {
        IEnumerable<ClienteModels> GetAll() 
        {
            ClienteModels Get(ClienteModels usuario);
            bool Add(string cpf ,ClienteModels usuario);
            bool Remove(string cpf,ClienteModels usuario);
            bool Update(string cpf, ClienteModels usuario);
        }
    }
}
