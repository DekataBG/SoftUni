
function solve() {
    let [firstName, lastName, age, storyTitle] = document.querySelectorAll("input");
    let genre = document.getElementById("genre");
    let story = document.getElementById("story");
    let previewList = document.getElementById("preview-list");
    let button = document.getElementById("form-btn");
    let mainDiv = document.getElementById("main");
  
    button.addEventListener("click", publish);
  
    function publish() {
      let firstNameValue = firstName.value;
      let lastNameValue = lastName.value;
      let ageValue = age.value;
      let storyTitleValue = storyTitle.value;
      let genreValue = genre.value;
      let storyValue = story.value;
  
  
      if(firstNameValue == "" || lastNameValue == "" || ageValue == "" || storyTitleValue == "" || storyValue == "") {
          return;
      } 
  
      let li = document.createElement("li");
      li.classList.add("story-info");
  
      
      let article = document.createElement("article");
  
      let h4 = document.createElement("h4");
      h4.textContent = `Name: ${firstNameValue} ${lastNameValue}`;
      article.appendChild(h4);
  
      let pAge = document.createElement("p");
      pAge.textContent = `Age: ${ageValue}`;
      article.appendChild(pAge);
  
      let pTitle = document.createElement("p");
      pTitle.textContent = `Title: ${storyTitleValue}`;
      article.appendChild(pTitle);
  
      let pGenre = document.createElement("p");
      pGenre.textContent = `Genre: ${genreValue}`;
      article.appendChild(pGenre);
  
      let pStory = document.createElement("p");
      pStory.textContent = storyValue;
      article.appendChild(pStory);
  
  
      li.appendChild(article);
  
      let btnSave = document.createElement("button");
      btnSave.classList.add("save-btn");
      btnSave.textContent = "Save Story";
      btnSave.addEventListener("click", save);
      li.appendChild(btnSave);
  
      let btnEdit = document.createElement("button");
      btnEdit.classList.add("edit-btn");
      btnEdit.textContent = "Edit Story";
      btnEdit.addEventListener("click", edit);
      li.appendChild(btnEdit);
  
      let btnDelete = document.createElement("button");
      btnDelete.classList.add("delete-btn");
      btnDelete.textContent = "Delete Story";
      btnDelete.addEventListener("click", remove);
      li.appendChild(btnDelete);
  
      previewList.appendChild(li);
  
  
      button.disabled = true;
  
  
      firstName.value = "";
      lastName.value = "";
      age.value = "";
      storyTitle.value = "";
      story.value = "";
    }
  
    function save() {
      while (mainDiv.firstChild) {
        mainDiv.lastChild.remove();
      }
  
      let h1 = document.createElement("h1");
      h1.textContent = "Your scary story is saved!";
      mainDiv.appendChild(h1);
    }
  
    function edit(e) {
      let [nameField, ageField,  titleField, genreField, storyField] = e.target.parentNode.children;
  
      firstName.value = nameField.textContent.split(" ")[1];
      lastName.value = nameField.textContent.split(" ")[2];
      age.value = ageField.textContent.split(" ")[1];
      storyTitle.value = titleField.textContent.substring(titleField.indexOf(" "));
      genre.value = genreField.textContent.split(" ")[1];
      story.value = storyField.textContent;
      
  
      e.target.parentNode.remove();
  
      button.disabled = false;
    }
  
    function remove(e) {
      button.disabled = false;
      e.target.parentNode.remove();
    }
  }
  