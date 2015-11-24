$(function() {

    var quizCounter = 0;
    var pointsCounter = 0;
    var moreInfoClicked = false;
    var yearOptionClicked = false;


    //get function for random movie

    $('#startGame').click(function() {
        getNewMovie();
    });

    $('#nextMovie').click(function() {
        getNewMovie();
    });

    function getNewMovie() {

        var posterUrl;
        var url = "http://localhost:63998/api/quiz/randommovie";
        $.getJSON(url, function(result) {
            $('#poster').append('<img src=')(result.PosterUrl);
        });

    };


    $("#moreInfo").click(function() {
        $('#result').html("");
        var title = $("#title").text();
        
        var url = "http://localhost:63998/api/quiz/randommovie/moreinfo/" + $.trim(title);

        $.getJSON(url, function(result) {
            $.each(result, function (k, v) {
                $('#result').append('<tr><td><b>' + k + '</td><td>' + v + '</td></tr>');
            });
        });

    });

    $("#yearOptions").click(function () {
        $('#year').html("");
        var title = $("#title").text();

        var url = "http://localhost:63998/api/quiz/randommovie/yearoption/" + $.trim(title);

        
        $.getJSON(url, function (result) {
            $.each(result, function (key, value) {
                $('#year').append('<td>' + value + '</td>');
            });
        });

    });
});