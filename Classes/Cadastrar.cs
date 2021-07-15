using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transferencia_bancaria1.Classes
{
    public class Cadastrar
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public String mensagem;

        public Cadastrar(int IdCliente, String Nome, Decimal Saldo, Decimal Credito)
        {
            cmd.CommandText = "insert into tlbCliente (IdCliente, Nome, Saldo, Credito) values(@IdCliente, @Nome, @Saldo, @Credito)";

            cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
              cmd.Parameters.AddWithValue("@Nome", Nome);
              cmd.Parameters.AddWithValue("@Saldo", Saldo);
              cmd.Parameters.AddWithValue("@Credito", Credito);

            try
            {
                cmd.Connection = conexao.conectar();

                cmd.ExecuteNonQuery();

                conexao.desconectar();

                this.mensagem = "Cadastro realizado com sucesso!";
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao se conectar com o banco de dados!";
            }
        }

    }
}