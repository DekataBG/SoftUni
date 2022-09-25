function attachGradientEvents() {
    let gradient = document.getElementById("gradient");
    let result = document.getElementById("result");
        
    gradient.addEventListener("mousemove", gradientMove);
    gradient.addEventListener("mouseout", gradientOut);


    function gradientMove(event) {
        let percent = 100 * event.offsetX / (event.target.clientWidth - 1);

        result.textContent = Math.trunc(percent) + "%";
    }

    function gradientOut(event) {
        result.textContent = "";
    }
}