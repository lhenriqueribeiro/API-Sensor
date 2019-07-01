$(document).ready(function() {
    $('#dataTable').DataTable();
    getData();
});

function getData() {
    $.ajax({
        type: "GET",
        url: "api/sensor",
        cache: false,
        success: function (data) {
            const tBody = $("#sensor");

            $(tBody).empty();

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.timestamp))
                    .append($("<td></td>").text(item.tag))
                    .append($("<td></td>").text(item.valor));

                tr.appendTo(tBody);
            });

            sensor = data;
        }
    });
}