using AcompanhamentoFisico.BLL;
using AcompanhamentoFisico.DAO;
using AcompanhamentoFisico.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcompanhamentoFisico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademiaController : ControllerBase
    {
        AcademiaBLL bll = new AcademiaBLL();

        [HttpGet("{CNPJ}")]
        public AcademiaDTO BuscaPorCNPJ(String CNPJ)
        {

            AcademiaDTO academiaDTO = new AcademiaDTO();
            academiaDTO = bll.retornaAcademiaPorCNPJ(CNPJ);


            return academiaDTO;
        }


        [HttpPost]
        public String Post(AcademiaDTO academiaDTO)
        {
            String retorno = bll.insereAcademia(academiaDTO);

            return retorno;

        }

        [HttpPut]
        public String Put(AcademiaDTO academiaDTO)
        {
            String retorno = bll.alteraAcademia(academiaDTO);

            return retorno;
        }


        [HttpDelete("{CNPJ}")]
        public String Delete(String CNPJ)
        {

            String retorno = bll.deletaAcademia(CNPJ);

            return retorno;
        }
    }
}
