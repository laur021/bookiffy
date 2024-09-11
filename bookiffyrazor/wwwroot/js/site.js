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