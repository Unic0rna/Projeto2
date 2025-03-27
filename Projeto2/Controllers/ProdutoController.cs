using Microsoft.AspNetCore.Mvc;
using Projeto2.Models;
using Projeto2.Repositorio;

namespace Projeto2.Controllers
{
    public class ProdutoController : Controller
    {
        public readonly ProdutoRepositorio _produtoRepositorio;

        public ProdutoController(ProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepositorio.AdicionarProduto(produto);
                return RedirectToAction("Login");
            }

            return View(produto);
        }
    }
}
