$(function () {



    $("#moreInfo").click(function() {

        var title = $("#title").text();
        
        var url = "http://localhost:63998/api/quiz/randommovie/moreinfo/" + $.trim(title);

        $.getJSON(url, function(result) {
            $.each(result, function (k, v) {
                $('#result').append('<tr><td><b>' + k + '</td><td>' + v + '</td></tr>');
            });
        });

    });

    $("#options").click(function () {

        var title = $("#title").text();

        var url = "http://localhost:63998/api/quiz/randommovie/yearoption/" + $.trim(title);

        $('#result').html("");
        $.getJSON(url, function (result) {
            $.each(result, function (k, v) {
                $('#result').append('<tr><td><b>' + k + '</td><td>' + v + '</td></tr>');
            });
        });

    });
});