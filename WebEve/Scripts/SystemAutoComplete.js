$(function () {
    $("#SystemSearch").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/SolarSystem/Search",
                dataType: "json",
                data: 'startswith=' + request.term,
                error: function () {
                    console.log('error');
                },
                success: function (data) {
                    response($.map(data, function (system) {
                        return {
                            label: system.solarSystemName + "---" + system.solarSystemID,
                            value: system.solarSystemName
                        }
                    }));
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            $("#systemId").val(ui.item.label.split("---")[1]);
        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }
    });
});

function AddSystem() {
    $.ajax({
        type: 'POST',
        url: '/SolarSystem/AjaxCreate',
        dataType: 'json',
        data: 'ApiId=' + $("#systemId").val(),
        success: function (data) {
            var html = "<tr> <td> " + data.ApiId + " </td> <td> " + data.Name + "</td> <td> <a href='/SolarSystem/Edit/" + data.Id + "'> Edit </a> | <a href='/SolarSystem/Delete/" + data.Id + "'> Edit </a> </td> </tr>";
            $("#SystemList").append(html);
            $("#systemId").val('');
            $("#SystemSearch").val('');
        }
    });
}