$(document).ready(function () {

    $(".autocomplete").autocomplete({
        
        source: function (request, response) {
            
            $.ajax({
                url: "/Home/AutoComplete",
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.Description, value: item.Description };
                    }))
                }
            })
        }
    });

});