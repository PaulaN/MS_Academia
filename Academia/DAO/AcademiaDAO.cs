using AcompanhamentoFisico.Model;
using AutoMapper;
using System.Data.SqlClient;
using System.Data;
using AcompanhamentoFisico.DTO;

namespace AcompanhamentoFisico.DAO
{
    public class AcademiaDAO
    {
        String conexao = @"Server=DESKTOP-BJNTUCI\MSSQLSERVER01;Database=Cliente;Trusted_Connection=True";
        public AcademiaDTO retornaAcademia(String CNPJ)
        {
            AcademiaDTO academiaDTO = new AcademiaDTO();
            Academia academia = new Academia();

            string sql = "select id_pk_academia, nome_fantasia, CNPJ,razao_social from Academia where CNPJ =" + "'" + CNPJ + "'";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    academia.idAcademia = Convert.ToInt32(reader[0]);
                    academia.nomeFantasia = reader[1].ToString();
                    academia.CNPJ = reader[2].ToString();
                    academia.razaoSocial = reader[3].ToString();



                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Academia, AcademiaDTO>();
                    });
                    var mapper = configuration.CreateMapper();
                    academiaDTO = mapper.Map<AcademiaDTO>(academia);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }

            return academiaDTO;
        }

        public int deletaAcademia(String CNPJ)
        {
            String retorno = "";
            string sql = "delete from dbo.Academia where CNPJ = " + "'" + CNPJ + "'";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            int i = cmd.ExecuteNonQuery();
            return i;

        }

        public int insereAcademia(AcademiaDTO academiaDTO)
        {

            String retorno = "";
            string sql = "INSERT INTO dbo.Academia (nome_fantasia, CNPJ,razao_social ) VALUES (" + "'" + academiaDTO.nomeFantasia + "'" + "," + "'" + academiaDTO.CNPJ + "'" + "," + "'" + academiaDTO.razaoSocial + "'" + ")";
            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            int i = cmd.ExecuteNonQuery();

            return i;
        }


        public int alteraDadosPessoais(AcademiaDTO academiaDTO)
        {

            String retorno = "";
            string sql = "UPDATE dbo.Academia SET  nome_fantasia=" + "'" + academiaDTO.nomeFantasia + "'" + "," + "razao_social=" + "'" + academiaDTO.razaoSocial + "'" +  "   where CNPJ=" + "'" + academiaDTO.CNPJ + "'";
            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            int i = cmd.ExecuteNonQuery();

            return i;
        }
    }
}
