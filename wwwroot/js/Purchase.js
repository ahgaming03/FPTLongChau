async function LoadReceipt() {
    $.ajax({
        url: `/Carts/ViewReceipt/`,
        method: "GET",
        success: function (response) {
            $("#receipt").html(response);
        }
    });
}

document.addEventListener('DOMContentLoaded', function () {
    LoadReceipt();
});