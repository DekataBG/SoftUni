function solve() {
  let [buttonGenerate, buttonBuy] = document.querySelectorAll("button");
  let [input, output] = document.querySelectorAll("textarea");
  let tbody = document.querySelector("tbody");

  buttonGenerate.addEventListener("click", generate);
  buttonBuy.addEventListener("click", buy);


  function generate() {
    let furnitures = JSON.parse(input.value);

    for(let furniture of furnitures){
      let tr = document.createElement("tr");

      let tdImg = document.createElement("td");
      let img = document.createElement("img");
      img.src = furniture.img;
      tdImg.appendChild(img);
      tr.appendChild(tdImg);

      let tdName = document.createElement("td");
      let name = document.createElement("p");
      name.textContent = furniture.name;
      tdName.appendChild(name);
      tr.appendChild(tdName);

      let tdPrice = document.createElement("td");
      let price = document.createElement("p");
      price.textContent = furniture.price;
      tdPrice.appendChild(price);
      tr.appendChild(tdPrice);

      let tdDecoration = document.createElement("td");
      let decoration = document.createElement("p");
      decoration.textContent = furniture.decFactor;
      tdDecoration.appendChild(decoration);
      tr.appendChild(tdDecoration);
      
      let tdCheckBox = document.createElement("td");
      let checkBox = document.createElement("input");
      checkBox.type = "checkbox";
      tdCheckBox.appendChild(checkBox);
      tr.appendChild(tdCheckBox);

      tbody.appendChild(tr);
    }
  }

  function buy() {
    let checkBoxes = Array.from(document.querySelectorAll("input[type='checkbox']"))
      .filter(ch => ch.checked);

    let names = [], prices = [], decFactors = [];

    for(let checkBox of checkBoxes) {
      let row = checkBox.parentNode.parentNode;

      names.push(row.children[1].children[0].textContent);
      prices.push(row.children[2].children[0].textContent);
      decFactors.push(row.children[3].children[0].textContent);
    }

    let products = names.join(', ');
    let sum = prices.reduce((sum, current) => {
      return sum + Number(current);
    }, 0);
    let averageDefFactor = decFactors.reduce((sum, current) => {
      return sum + Number(current);
    }, 0) / decFactors.length;

    output.textContent += `Bought furniture: ${products}\n`;
    output.textContent += `Total price: ${sum.toFixed(2)}\n`;
    output.textContent += `Average decoration factor: ${averageDefFactor}`;
  }
}