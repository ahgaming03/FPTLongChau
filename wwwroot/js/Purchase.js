async function LoadReceipt() {
    const cart = LoadCart();

    $.ajax({
        url: `/Carts/ViewReceipt/`,
        method: "POST",
        contentType: 'application/json',
        data: JSON.stringify(cart),
        success: function (response) {
            $("#receipt").html(response);
        },
        error: function (error) {
            console.log("Error in sending data to server: ", error);
        }
    });
}

document.addEventListener('DOMContentLoaded', function () {
    LoadReceipt();
});

document.addEventListener('DOMContentLoaded', function () {
    var form = document.getElementById('checkout');
    form.addEventListener('submit', function () {
        var cart = localStorage.getItem('shoppingCart'); // Retrieve data from localStorage
        document.getElementById('shoppingCart').value = cart; // Set the value of the hidden field
    });
});
