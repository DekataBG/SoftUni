function addItem() {
    let input = document.getElementById("newItemText").value;
    let items = document.getElementById("items");

    let item = document.createElement("li");
    item.textContent = input;
    
    let link = document.createElement("a");
    link.href = "#";
    link.textContent = "[Delete]";
    link.addEventListener("click", (e) => {
        e.currentTarget.parentNode.remove();
    });

    item.appendChild(link);
    items.appendChild(item);

    document.getElementById("newItemText").value = "";
}