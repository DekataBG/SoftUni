function validate() {
    let input = document.getElementById("email");

    input.addEventListener("change", validateElement);


    function validateElement(e){

        e.target.className = isElementValid() ? "" : "error";

        function isElementValid() {
            let regex = new RegExp('^[a-z]+[@][a-z]+.[a-z]+');
    
            return regex.test(e.target.value);
        }
    }
}