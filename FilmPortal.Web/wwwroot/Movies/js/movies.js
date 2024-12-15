// Slider otomatik geçiş
const carousel = document.querySelector("#imdbCarousel");
new bootstrap.Carousel(carousel, { interval: 2000 });

// Scroll functions
function TurnLeft(btn) {
    const slider = btn.parentElement.querySelector(".film-slider");
    slider.scrollLeft -= 300;
}

function TurnRight(btn) {
    const slider = btn.parentElement.querySelector(".film-slider");
    slider.scrollLeft += 300;
}

// Film detayına yönlendirme
function navigateToFilmDetail(filmId) {
    window.location.href = `film-detay.html?id=${filmId}`;
}

// Search bar
const searchInput = document.getElementById("searchInput");
const searchResults = document.getElementById("searchResults");

searchInput.addEventListener("input", () => {
    const query = searchInput.value.toLowerCase();
    searchResults.innerHTML = "";

    if (query) {
        const fakeMovies = [
            { id: 1, title: "Film 1", imdb: "9.5" },
            { id: 2, title: "Film 2", imdb: "9.2" },
        ];

        fakeMovies.forEach((movie) => {
            if (movie.title.toLowerCase().includes(query)) {
                const result = document.createElement("div");
                result.className = "result";
                result.innerHTML = `<a href="film-detay.html?id=${movie.id}" style="color: white; text-decoration: none;">${movie.title} - IMDB: ${movie.imdb}</a>`;
                searchResults.appendChild(result);
            }
        });
    }
});