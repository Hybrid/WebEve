$(function () {
    console.log('Test');
    $("#ItemSearch").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Item/Search",
                dataType: "json",
                data: 'startswith=' + request.term,
                error: function () {
                    console.log('error');
                },
                success: function (data) {
                    console.log(data);
                    response($.map(data, function (item) {
                        return {
                            label: item.typeName + "---" + item.typeID,
                            value: item.typeName
                        }
                    }));
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            $("#itemId").val(ui.item.label.split("---")[1]);
            /*$ajax({
            type: 'POST',
            url: '/Item/AjaxCreate',
            dataType: 'json',
            data: 'ApiId=' + ui.item.label.split("---")[1],
            success: function (data) {
            var html = "<tr> <td> " + data.ApiId + " </td> <td> " + data.Name + "</td> <td> <a href='/Item/Edit/" + data.Id + "'> Edit </a> | <a href='/Item/Delete/" + data.Id + "'> Edit </a> </td> </tr>";
            $("#ItemList").append(html);
            }
            });*/
        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }
    });
});

function AddItem() {
    $.ajax({
        type: 'POST',
        url: '/Item/AjaxCreate',
        dataType: 'json',
        data: 'ApiId=' + $("#itemId").val(),
        success: function (data) {
            var html = "<tr> <td> " + data.ApiId + " </td> <td> " + data.Name + "</td> <td> <a href='/Item/Edit/" + data.Id + "'> Edit </a> | <a href='/Item/Delete/" + data.Id + "'> Edit </a> </td> </tr>";
            $("#ItemList").append(html);
            $("#itemId").val('');
            $("#ItemSearch").val('');
        }
    });
}