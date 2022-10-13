function solve() {
    let sections = document.querySelectorAll("section");

    let buttons = document.querySelectorAll("button");
    buttons[0].type = "button";
    
    buttons[0].addEventListener("click", onScreen);
    buttons[1].addEventListener("click", clear);

    let [input1, input2, input3] = document.querySelectorAll("input")

    function onScreen() {
        if(input1.value == "" || input2.value == "" || input3.value == "" || isNaN(Number(input3.value))) {
            return;
        }

        let li = document.createElement("li");

        let span = document.createElement("span");
        span.textContent = input1.value;

        let strong = document.createElement("strong");
        strong.textContent = "Hall: " +  input2.value;

        let div = document.createElement("div");

        let divStrong = document.createElement("strong");
        divStrong.textContent = Number(input3.value).toFixed(2);

        let divInput = document.createElement("input");
        divInput.setAttribute("placeholder", "Tickets Sold");

        let divButton = document.createElement("button");
        divButton.textContent = "Archive";
        divButton.addEventListener("click", archive);

        div.appendChild(divStrong);
        div.appendChild(divInput);
        div.appendChild(divButton);

        li.appendChild(span);
        li.appendChild(strong);
        li.appendChild(div);

        sections[0].children[1].appendChild(li);
        

        input1.value = "";
        input2.value = "";
        input3.value = "";
    }

    function archive() {
        let input = this.parentNode.children[1];

        if(input.value == "" || isNaN(input.value)) {
            return;
        }

        let li = this.parentNode.parentNode;
        let span = li.querySelector("span");
        let strong = li.querySelector("strong");

        let total = Number(li.querySelector("div > strong").textContent) * Number(li.querySelector("div > input").value);
        strong.textContent = "Total amount: " + total.toFixed(2);

        let button = document.createElement("button");
        button.textContent = "Delete";
        button.addEventListener("click", remove);

        let newLi = document.createElement("li");
        newLi.appendChild(span);
        newLi.appendChild(strong);
        newLi.appendChild(button);

        sections[1].children[1].appendChild(newLi);

        li.remove();
    }

    function remove() {
        this.parentNode.remove();
    }

    function clear() {
        let ul = sections[1].children[1];

        while(ul.childElementCount > 0) {
            ul.firstChild.remove();
        }
    }
}