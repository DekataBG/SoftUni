function solve() {
  let right = 0;
  let wrong = 0;

  let paragraphs = Array.from(document.querySelectorAll("p"));
  paragraphs.forEach(p => p.addEventListener("click", goToNextPage));
  let sections = document.querySelectorAll("section");
  let result = document.querySelector("#results .results-inner h1");

  function goToNextPage() {
    if(this.textContent == "onclick" || this.textContent == "JSON.stringify()" || this.textContent == "A programming API for HTML and XML documents") {
      right++;
    } else {
      wrong++;
    }

    sections[right + wrong - 1].style.display = "none";

    if(right + wrong < 3){
      sections[right + wrong].style.display = "block";          
    } else {
      document.getElementById("results").style.display = "block";

      if(right == 3){
        result.textContent = "You are recognized as top JavaScript fan!";
      } else {
        result.textContent = `You have ${right} right answers`;
      }
    }
  }
}
