using EcommerceCCO2023.Models;
using EcommerceCCO2023.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCCO2023.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Cliente cliente)
        {
            ClienteData clienteData = new ClienteData();
            // Chama o método Login no ClienteData que tem como resposta um boolean indicando se o loin está correto
            //caso o email e senha esteja correto retorna true e caso esteja incorreto retorna false, sendo assim caso o
            //usuario digite o email e a senha e estejam corretos o usuario irá para a página principal e caso esteja incorreto
            //volta para a página de login
            if (clienteData.Login(cliente.Email, cliente.Senha))
                return RedirectToAction("Index", "Home");
            
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente clie)
        {
            if (clie.Nome != null)
            {
                ClienteData data = new ClienteData();
                data.Create(clie);
            }

            return RedirectToAction("IndexCliente");
        }
    }
}
