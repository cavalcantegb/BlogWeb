using BlogWeb1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb1.Controllers
{
    public class PostController : Controller
    {
        private IList<Post> lista;

        public PostController()
        {
            this.lista = new List<Post>()
            {
                new Post() {Titulo="Harry Potter", Resumo="Pedra Filosofal", Categoria="Filme, Livro"},
                new Post() {Titulo="Casino Royale", Resumo="007", Categoria="Filme"},
                new Post() {Titulo="Monge e o executivo", Resumo="Romance sobre liderança", Categoria="Livro"},
                new Post() {Titulo="New York, New York", Resumo="Sucesso de Frank Sinatra", Categoria="Música"}
            };
        }

        // GET: Post
        public ActionResult Index()
        {
            return View(lista);
        }

        public ActionResult Novo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Post post)
        {
            lista.Add(post);
            return View("Index", lista);
        }
    }
}