setTimeout(function(){
    var alertElement = document.getElementById("notifAlert");
        if (alertElement) {
            // Add 'hide' class to trigger the slide-out animation
            alertElement.classList.add('hide');

            // Optionally, remove the alert from DOM after the slide-out animation completes
            setTimeout(function () {
                alertElement.remove();
            }, 1000); // Match the duration of the animation (1 second)
        }
}, 3000)

//Clear input fields in  modal upon closing of modal.
document.getElementById('newCategoryModal').addEventListener('hidden.bs.modal', function () {
    document.getElementById('newCategoryForm').reset();
});

//Set the displayorder input to blank if the value is zero.
document.getElementById('newCategoryModal').addEventListener('show.bs.modal', function () {
    const displayOrderInput = document.getElementById("displayOrder");
    if (displayOrderInput.value == 0) {
        displayOrderInput.value = '';
    }
});