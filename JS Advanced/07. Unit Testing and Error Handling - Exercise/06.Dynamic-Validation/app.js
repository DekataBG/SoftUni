function validate() {
  let input = document.getElementById("email");

  input.addEventListener("change", () => {
    let email = input.value;

    if (/^[a-z]+@[a-z]+\.[a-z]+/g.test(email)) {
      input.className = "";
    } else {
      input.setAttribute("class", "error");
    }
  });
}
