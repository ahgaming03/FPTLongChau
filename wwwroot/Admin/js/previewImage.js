
document.getElementById('imageInput').addEventListener('change', function (event) {
    var reader = new FileReader();
    var file = event.target.files[0];

    if (file) {
        // File is selected, read and preview it
        reader.onload = function (e) {
            var output = document.getElementById('imagePreview');
            output.src = e.target.result;
        };
        reader.readAsDataURL(file);
    } else {
        // No file is selected (canceled), set to default image
        document.getElementById('imagePreview').src = '/img/default_image.jpg';
    }
});