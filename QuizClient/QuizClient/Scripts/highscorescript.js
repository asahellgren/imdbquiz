$(document).ready(function () {

    $(window).load(function () {
        var url = "https://microsoft-apiapp831da86c936d4c65a4e1573348daaaaa.azurewebsites.net/api/quiz/randommovie/gethighscore";
       
        $.getJSON(url, function (result) {
        
            $.each(result, function (key, value) {
                $('#highscorelist').append('<li>' + value.Name + ' - ' + value.Score1 + ' points</li>');
            });
         

        });
       

    });

});