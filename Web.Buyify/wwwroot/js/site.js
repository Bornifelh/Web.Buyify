// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    // Affichez le pop-up lorsque la page est chargée
    $('#newsletter-popup').show();

    // Masquez le pop-up lorsqu'un utilisateur clique sur le bouton de fermeture
    $('#newsletter-popup .close-button').click(function () {
        $('#newsletter-popup').hide();
    });

    // Soumettez le formulaire du pop-up
    $('#newsletter-form').submit(function (e) {
        e.preventDefault(); // Empêche la soumission du formulaire par défaut

        // Effectuez une requête AJAX pour soumettre les données du formulaire au serveur
        $.post($(this).attr('action'), $(this).serialize(), function (response) {
            // Affichez la réponse du serveur dans une zone appropriée (par exemple, une div de confirmation)
            $('#newsletter-popup').html(response);
        });
    });
});