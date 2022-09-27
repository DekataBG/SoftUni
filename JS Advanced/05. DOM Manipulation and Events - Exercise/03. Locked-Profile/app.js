function lockedProfile() {
    let buttons = Array.from(document.querySelectorAll("button"));
    buttons.forEach(b => b.addEventListener("click", onClick));


    function onClick(e) {
        let div = e.target.parentNode;
        //let hiddenFields = div.children[9];
        let hiddenFields = div.querySelector("div[id$='HiddenFields']")
        //let radioButtonLock = div.children[2];
        let radioButtonLock = div.querySelector("input[value='lock']");
        //let button = div.children[10];
        let button = div.querySelector("button");

        if(radioButtonLock.checked) {
            return;
        }

        if(hiddenFields.style.display == "block") {
            hiddenFields.style.display = "none";
            button.textContent = "Show more";
        } else {
            hiddenFields.style.display = "block";
            button.textContent = "Hide it";
        }
    }
}