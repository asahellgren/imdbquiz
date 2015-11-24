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

        var url = "https://microsoft-apiapp831da86c936d4c65a4e1573348daaaaa.azurewebsites.net/api/quiz/randommovie";
        $.getJSON(url, function (result) {
            $('#poster').append('<img src="' + result.PosterUrl + '" />');
            $('#title').append(result.Title);
            $('#imdbRating').append(result.ImdbRating);
            $('#tomatoRating').append(result.TomatoRating);
            $('#nextMovie').hide();
            $("#yearOptions").hide();
            $('#answer').show();
            $('#answer').empty();
            $('#submitAnswer').show();
            $('#nextMovie').hide();
            $('#clues').show();
            $('#rightOrWrongGuess').html('');
            $('#rightOrWrongGuess').hide();
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
        $("#yearOptions").show();
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

        $('#rightOrWrongGuess').show();
        var answer = $('#answer').val();
        console.log(answer);
        var title = $("#title").text();
        var url = "https://microsoft-apiapp831da86c936d4c65a4e1573348daaaaa.azurewebsites.net/api/quiz/randommovie/" + $.trim(title) + '/' + answer;
        console.log(url);
        $.getJSON(url, function (result) {
            console.log(result);
            if (result == "True") {
                $('#rightOrWrongGuess').append('<p>' + 'Correct!' + '</p>').css({ 'color': 'green', 'font-size': '150%' });
                if (moreInfoClicked) {
                    if (yearOptionClicked) {
                        pointsCounter++;
                    }
                    else {
                        pointsCounter += 8;
                    }
                } else {
                    pointsCounter += 10;
                }
            }
            else {
                var difference = parseInt(result, 10) - parseInt(answer, 10);
                if (difference <= 5 && difference >= -5 && !yearOptionClicked) {
                    $('#rightOrWrongGuess').append('<p>' + 'Close guess! The year is ' + result + '</p>').css({ 'color': 'green', 'font-size': '150%' });
                    if (moreInfoClicked) {
                        pointsCounter += 3;
                    } else {
                        pointsCounter += 5;
                    }
                } else {
                    $('#rightOrWrongGuess').append('<p>' + 'Wrong answer. The year is ' + result + '</p>').css({ 'color': 'red', 'font-size': '150%' });
                }
            }
            $('#score').text(pointsCounter);
            quizCounter++;
        });

        $('#answer').val("");
        $('#year').html("");
        $('#result').html("");
        $('#clues').hide();
        $('#answer').hide();
        $('#submitAnswer').hide();
        $('#nextMovie').show();
    });


});

