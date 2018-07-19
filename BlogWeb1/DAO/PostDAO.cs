using BlogWeb1.Infra;
using BlogWeb1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogWeb1.DAO
{
    public class PostDAO
    {
        public IList<Post> Lista()
        {
            List<Post> lista = new List<Post>();
            using (SqlConnection conexao = ConnectionFactory.CriaConexaoAberta())
            {
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from Posts";
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Post post = new Post()
                    {
                        Id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"])
                    };
                    lista.Add(post);
                }
            }

            return lista;
        }
    }
}