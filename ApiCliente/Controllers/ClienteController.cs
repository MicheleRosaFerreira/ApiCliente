using Microsoft.AspNetCore.Mvc;
using ApiCliente.Models;
namespace ApiCliente.Controllers
{
    [ApiController]
    [Route("(controller)")]
    public class ClienteController : ControllerBase
    {
        private static List<ClienteModels> _clienteModels = new List<ClienteModels>()
        {
            new ClienteModels()
            {
                nome = "Michele",
                sobrenome = "Ferreira",
                cpf = "123.456.789-09",
                dataNascimento = new DateTime(01041998)
            },

            new ClienteModels()
            {
                nome = "Moises",
                sobrenome = "Cruvinel",
                cpf = "142.567.345-87",
                dataNascimento=new DateTime(15041995)
            }
        };
      
        [HttpGet]
        [Route("/api/v1/cliente/{cpf}")]
        public ActionResult<ClienteModels> Get(string cpf)
        {
            var cliente = _clienteModels.FirstOrDefault(c => c.cpf == cpf);
          
            if (cliente == null)
            {
                return NotFound("cliente não encontrado");
            }
            return Ok(cliente);
        }
        [HttpGet]
        [Route("/api/v1/cliente")]

        public List<ClienteModels> GetAll()
        {
            return _clienteModels;
        }



        [HttpPost]
        [Route("/api/v1/cliente")]

        public ActionResult<ClienteModels> Add([FromBody] ClienteModels cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("cliente invalido");
                }
                _clienteModels.Add(cliente);
                return Ok("Cliente cadastrado com sucesso!");
            }
            catch
            {
                return NotFound("Cliente não cadastrado");
            }
        }
        [HttpPut]
        [Route("/api/v1/cliente/{cpf}")]

        public ActionResult<ClienteModels> Update(string cpf, [FromBody] ClienteModels cliente)
        {
            try
            {
                if (cliente.cpf != cpf)
                {
                    return BadRequest("Erro ao atualizar cliente");
                }
                var novoCliente = _clienteModels.FirstOrDefault(c => c.cpf == cpf);
                if (novoCliente != null)
                {
                    return Ok("cliente atualizado com sucesso");
                }
            }
            catch
            {
                return BadRequest("cliente não autualizado");
            } return cliente;
        }
       [HttpDelete]
       [Route("/api/v1/cliente{cpf}")]
        
       public ActionResult<ClienteModels> Remove(string cpf)
           
        {
           if(cpf != null)
            {
               _clienteModels = _clienteModels.Where(c => c.cpf == cpf).ToList();
            }
            return Ok("Cliente deletado");
        }

    }
    
}