function search() {
   let list = document.getElementById('towns');
   let phrase = document.getElementById('searchText').value;
   let result = document.getElementById('result');

   let ctr = 0;
   let children = Array.from(list.children);
   for(child of children){
      if(child.textContent.includes(phrase)){
         child.style.textDecoration = "underline";
         child.style.fontWeight = "bold";
         ctr++;
      }else{
         child.style.textDecoration = "none";
         child.style.fontWeight = "normal";
      }
   }

   result.textContent = `${ctr} matches found`
}
