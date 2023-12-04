using AcompanhamentoFisico.DAO;
using AcompanhamentoFisico.DTO;

namespace AcompanhamentoFisico.BLL
{
    public class AcademiaBLL
    {

        AcademiaDAO dao = new AcademiaDAO();
        int retornoAcademia = 0;

        public AcademiaDTO retornaAcademiaPorCNPJ(String CNPJ)
        {
            AcademiaDTO academiaDTO = new AcademiaDTO();
            academiaDTO = dao.retornaAcademia(CNPJ);
            return academiaDTO;
        }

        public String insereAcademia(AcademiaDTO academiaDTO)
        {
            retornoAcademia = 0;

            bool cnpjValido = IsCnpj(academiaDTO.CNPJ);
            if (academiaDTO != null && cnpjValido)
            {
                retornoAcademia = dao.insereAcademia(academiaDTO);
            }
            else 
            {
                return "CNPJ inválido";
            
            }
            
            
            return retornoAcademia == 1 ? "Cadastro realizado com sucesso" : "Não foi possível cadastrar academia";
        }



        public String deletaAcademia(String CNPJ)
        {
            retornoAcademia = 0;


            if (CNPJ != null)
            {
                retornoAcademia = dao.deletaAcademia(CNPJ);
             


            }
            
            return retornoAcademia == 1 ? "Dados deletados com sucesso" : "Não foi possível deletar academia"; 
        }

        public String alteraAcademia(AcademiaDTO academiaDTO)
        {
            retornoAcademia = 0;

           retornoAcademia = dao.alteraDadosPessoais(academiaDTO);

            return retornoAcademia == 1 ? "Alteração realizada com sucesso" : "Não foi possível alterar academia";
        }

        public static bool IsValid(string Cnpj)
        {
            return (IsCnpj(Cnpj));
        }
        private static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }




}
