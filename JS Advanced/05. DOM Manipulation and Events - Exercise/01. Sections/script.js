function create(words) {
   let mainDiv = document.getElementById("content");

   for(let word of words) {
      let div = document.createElement("div");
      let paragraph = document.createElement("p");

      div.addEventListener("click", (e) => e.target.children[0].style.display = "block");

      paragraph.textContent  = word;
      paragraph.style.display = "none";

      div.appendChild(paragraph);
      mainDiv.appendChild(div);
   }
}