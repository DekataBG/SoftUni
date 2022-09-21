function editElement(element, stringToReplace, newString) {
    let text = element.innerHTML;
    
    while(text.includes(stringToReplace)){
        text = text.replace(stringToReplace, newString);
    }

    element.innerHTML = text;
}