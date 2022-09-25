function addItem() {
    let list = document.getElementById("items");
    let item = document.getElementById("newItemText").value;

    let newItem = document.createElement("li");
    newItem.textContent = item;

    list.appendChild(newItem);

    document.getElementById("newItemText").value = '';
}