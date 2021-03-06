﻿using BlogWeb1.Infra;
using BlogWeb1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void Remove(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                contexto.Posts.Remove(post);
                contexto.SaveChanges();
            }
        }

        public Post BuscaPorId(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                return post;
            }
        }

        public void Atualiza(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Entry(post).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Publica(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;
                contexto.SaveChanges();
            }
        }

        public IList<string> ListaCategoriaQueContemTermo(string termoDigitado)
        {
            using (var contexto = new BlogContext())
            {
                return contexto.Posts.
                    Where(p => p.Categoria.Contains(termoDigitado)).
                    Select(p => p.Categoria).
                    Distinct().
                    ToList();

            }
        }
    }
}
