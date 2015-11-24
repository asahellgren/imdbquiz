$(document).ready(function () {

    var quizCounter = 0;
    var pointsCounter = 0;
    var moreInfoClicked = false;
    var yearOptionClicked = false;

    $(window).load(function () {
        getNewMovie();
    });

    $('#nextMovie').click(function () {
        $('#poster').html("");
        $('#title').html("");
        $('#imdbRating').html("");
        $('#tomatoRating').html("");

        getNewMovie();
    });

    function getNewMovie() {

        var posterUrl;
        var url = "https://microsoft-apiapp831da86c936d4c65a4e1573348daaaaa.azurewebsites.net/api/quiz/randommovie";
        $.getJSON(url, function (result) {
            $('#poster').append('<img src="' + result.PosterUrl + '" />');
            $('#title').append(result.Title);
            $('#imdbRating').append(result.ImdbRating);
            $('#tomatoRating').append(result.TomatoRating);
        });

    };


    $("#moreInfo").click(function () {
        moreInfoClicked = true;
        $('#result').html("");
        var title = $("#title").text();

        var url = "https://microsoft-apiapp831da86c936d4c65a4e1573348daaaaa.azurewebsites.net/api/quiz/randommovie/moreinfo/" + $.trim(title);

        $.getJSON(url, function (result) {
            $.each(result, function (k, v) {
                $('#result').append('<tr><td><b>' + k + '</td><td>' + v + '</td></tr>');
            });
        });

    });

    $("#yearOptions").click(function () {
        yearOptionClicked = true;
        $('#year').html("");
        var title = $("#title").text();

        var url = "https://microsoft-apiapp831da86c936d4c65a4e1573348daaaaa.azurewebsites.net/api/quiz/randommovie/yearoption/" + $.trim(title);


        $.getJSON(url, function (result) {
            $.each(result, function (key, value) {
                $('#year').append('<td>' + value + '</td>');
            });
        });

    });

    $('#submitAnswer').click(function () {

        var answer = $('#answer').val();
        console.log(answer);
        var title = $("#title").text();
        var url = "https://microsoft-apiapp831da86c936d4c65a4e1573348daaaaa.azurewebsites.net/api/quiz/randommovie/" + $.trim(title) + '/' + answer;
        console.log(url);
        $.getJSON(url, function (result) {
            console.log(result);
            if (result == "True") {
                if (moreInfoClicked) {
                    if (yearOptionClicked)
                        pointsCounter += 5;
                    else {
                        pointsCounter += 8;
                    }
                } else {
                    pointsCounter += 10;
                }
            }
            else {
                //Fel result.value är rätt år...

            }

            $('#score').text(pointsCounter);

        });

    });

});