function solve() {
    let sections = document.querySelectorAll("section"); 

    let input1 = document.getElementById("task");
    let input2 = document.getElementById("description");
    let input3 = document.getElementById("date");

    document.querySelectorAll("button")[0].addEventListener("click", addTask);

    
    function addTask() {
        this.type = "button";

        if(input1.value == "" || input2.value == "" || input3.value == "") {
            return;
        }

        let h3 = document.createElement("h3");
        h3.textContent = input1.value;

        let p1 = document.createElement("p");
        p1.textContent = "Description: " + input2.value;

        let p2 = document.createElement("p");
        p2.textContent = "Due Date: " + input3.value;

        let div = document.createElement("div");
        div.setAttribute("class", "flex");

        let btn1 = document.createElement("button");
        btn1.setAttribute("class", "green")
        btn1.textContent = "Start";
        btn1.addEventListener("click", startTask);

        let btn2 = document.createElement("button");
        btn2.setAttribute("class", "red")
        btn2.textContent = "Delete";
        btn2.addEventListener("click", deleteTask);

        div.appendChild(btn1);
        div.appendChild(btn2);

        let article = document.createElement("article");
        article.appendChild(h3);
        article.appendChild(p1);
        article.appendChild(p2);
        article.appendChild(div);

        sections[1].children[1].appendChild(article);


        input1.value = "";
        input2.value = "";
        input3.value = "";
    }

    function startTask() {
        let article = this.parentNode.parentNode;
        let div = article.querySelector("div");
        
        div.firstChild.remove();
        div.firstChild.remove();

        sections[2].children[1].appendChild(article);

        let btn1 = document.createElement("button");
        btn1.setAttribute("class", "red")
        btn1.textContent = "Delete";
        btn1.addEventListener("click", deleteTask);

        let btn2 = document.createElement("button");
        btn2.setAttribute("class", "orange")
        btn2.textContent = "Finish";
        btn2.addEventListener("click", completeTask);

        div.appendChild(btn1);
        div.appendChild(btn2);
    }

    function deleteTask() {
        this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);
    }

    function completeTask() {
        let article = this.parentNode.parentNode;

        this.parentNode.remove();

        sections[3].children[1].appendChild(article);
    }
}