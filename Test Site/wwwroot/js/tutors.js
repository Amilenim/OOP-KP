document.addEventListener("DOMContentLoaded", function () {
    var modal = document.getElementById("contactModal");
    var span = document.getElementsByClassName("close")[0];

    document.querySelectorAll(".contact-button").forEach(button => {
        button.addEventListener("click", function () {
            var tutorInfo = this.getAttribute("data-info");
            document.getElementById("tutorInfo").innerText = tutorInfo;
            modal.style.display = "block";
        });
    });

    span.onclick = function () {
        modal.style.display = "none";
    }

    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
});