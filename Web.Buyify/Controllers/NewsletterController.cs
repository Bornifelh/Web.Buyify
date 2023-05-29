using Microsoft.AspNetCore.Mvc;

namespace Web.Buyify.Controllers
{
    public class NewsletterController : Controller
    {
        [HttpGet]
        public IActionResult Popup()
        {
            return PartialView("_NewsletterPopup");
        }

        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            // Traitez l'adresse e-mail ici (par exemple, enregistrez-la dans une base de données)
            // et renvoyez une réponse appropriée à l'utilisateur (par exemple, une vue de confirmation).
            // Notez que vous devez ajouter la validation appropriée des données et des mesures de sécurité.

            // Exemple simple :
            return Content("Merci de vous être inscrit à notre newsletter !");
        }
    }
}
