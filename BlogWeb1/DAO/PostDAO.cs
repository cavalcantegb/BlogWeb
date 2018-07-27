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
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.ToList();
                return lista;
            }
        }

        public void Adiciona(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Posts.Add(post);
                contexto.SaveChanges();
            }
        }

        public IList<Post> FiltraPorCategoria(string categoria)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();
                return lista;
            }
        }
    }
}