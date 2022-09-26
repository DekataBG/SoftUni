function focused() {
    let sections = Array.from(document.querySelectorAll("input[type='text']"));

    sections.forEach(s => s.addEventListener("focus", (e) => e.target.parentNode.className = "focused"));
    sections.forEach(s => s.addEventListener("blur", (e) => e.target.parentNode.classList.remove("focused")));

}