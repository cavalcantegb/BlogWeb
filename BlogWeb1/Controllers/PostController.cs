using BlogWeb1.DAO;
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

        public object PostDao { get; private set; }

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
            PostDAO dao = new PostDAO();
            IList<Post> lista = dao.Lista();
            return View(lista);
        }

        public ActionResult Novo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Post post)
        {
            if (ModelState.IsValid)
            {
                PostDAO dao = new PostDAO();
                dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Novo");
            }
            
        }

        public ActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            PostDAO dao = new PostDAO();
            IList<Post> lista = dao.FiltraPorCategoria(categoria);
            return View("Index", lista);
        }

        public ActionResult Remove(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            PostDAO dao = new PostDAO();
            Post post = dao.BuscaPorId(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edita(Post post)
        {
            if(ModelState.IsValid)
            {
                PostDAO dao = new PostDAO();
                dao.Atualiza(post);
                return RedirectToAction("Index");
            } else
            {
                return View("Visualiza", post);
            }
        }

        public ActionResult Publica(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Publica(id);
            return RedirectToAction("Index");
        }
    }
}