function solve() {
   let addButtons = Array.from(document.querySelectorAll('.add-product'));
   let checkoutButton = document.querySelector('.checkout');
   let output = document.querySelector('textarea');
   let list = {};

   addButtons.forEach(b => b.addEventListener("click", addItem));
   checkoutButton.addEventListener("click", checkout);

   function addItem(e) {
      let product = e.target.parentNode.parentNode;
      let details = product.children[1];

      let name = details.children[0].textContent;
      let price = Number(product.children[3].textContent).toFixed(2);

      list[name] = list[name] ?Number(Number(list[name]) * 2) : price;

      output.textContent += `Added ${name} for ${price} to the cart.\n`;
   }

   function checkout() {
      let items = Object.keys(list).join(', ');

      let totalPrice = Object.values(list)
         .map(n => Number(n))
         .reduce((sum, current) => {
            return sum + current;
         }, 0).toFixed(2);

      output.textContent += `You bought ${items} for ${totalPrice}.`;

      addButtons.forEach(b => b.disabled = "true");
      checkoutButton.disabled = "true";
   }
}