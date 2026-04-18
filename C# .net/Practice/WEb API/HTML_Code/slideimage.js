let slideIndex = 0;
showSlides();

function showSlides() {
    let carousels = document.querySelectorAll(".carousel");
    carousels.forEach(carousel => {
        let slides = carousel.getElementsByClassName("carousel-slide");
        for (let i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        slideIndex++;
        if (slideIndex > slides.length) { slideIndex = 1 }

        slides[slideIndex - 1].style.display = "block";
        slides[slideIndex - 1].style.animation = "slideLeft .2s ease-in-out";
    });

    setTimeout(showSlides, 3000);
}
