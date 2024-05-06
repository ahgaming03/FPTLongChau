function SaveCart(cart) {
    localStorage.setItem("shoppingCart", JSON.stringify(cart));
}

function LoadCart() {
    cart = localStorage.getItem("shoppingCart");
    return cart ? JSON.parse(cart) : [];
}

// Add item to cart
function AddItemToCart(id, quantity = 1) {
    var cart = LoadCart();
    var found = cart.find(p => p.id === id);
    if (found === undefined) {
        cart.push({ id: id, quantity: quantity }); // Add new item to cart
    } else {
        found.quantity += quantity; // Increase quantity if item exists
    }
    SaveCart(cart);
    LoadCartItems();
}

// Descrease item quantity
function DecreaseItemQuantity(id) {
    var cart = LoadCart();
    var found = cart.find(p => p.id === id);
    if (found !== undefined) {
        found.quantity -= 1; // Decrease quantity
        if (found.quantity <= 0) {
            RemoveItemFromCart(id);
            return;
        }
    }
    SaveCart(cart);
    LoadCartItems();
}

// Remove item from cart
function RemoveItemFromCart(id) {
    var cart = LoadCart();
    var index = cart.findIndex(p => p.id === id);
    if(index !== -1) {
        cart.splice(index, 1); // Remove item from cart
    }
    SaveCart(cart);
    LoadCartItems();
}

function UpdateItemQuantity(id, quantity) {
    var cart = LoadCart();
    var found = cart.find(p => p.id === id);
    if (found !== undefined) {
        found.quantity = quantity; // Update quantity
    }
    SaveCart(cart);
}

async function LoadCartItems() {
    let cart = LoadCart();


    $.ajax({
        url: `/Carts/ViewCart/`,
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify(cart),
        success: function (result) {
            $("#cartList").html(result);
        },
        error: function (error) {
            console.log("Error in sending data to server: ", error)
        }
    })
    TotalCartPrice();
}

async function TotalCartPrice() {
    let cart = LoadCart();

    $.ajax({
        url: `/Carts/TotalCartPrice/`,
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify(cart),
        success: function (result) {
            $("#totalPrice").html(result);
        },
        error: function (error) {
            console.log("Error in sending data to server: ", error)
        }
    })
}

async function ClearCart() {
    localStorage.removeItem("shoppingCart");
    LoadCartItems();
}

document.addEventListener('DOMContentLoaded', function () {
    LoadCartItems();
    TotalCartPrice();
});

