function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchField = document.getElementById('searchField');
      let phrase = searchField.value;

      let rows = Array.from(document.querySelectorAll('tbody tr'));

      rows.forEach(r => {
         if(r.textContent.includes(phrase)) {
            r.className = "select";
         } else {
            r.className = "";
         }
      });

      searchField.value = "";
   }
}