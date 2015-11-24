$(function () {



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

    $("#options").click(function () {
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