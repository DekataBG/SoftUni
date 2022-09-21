function extractText() {
    let list = document.getElementById('items');

    let text = '';

    for(let i = 0; i < list.children.length; i++){
        text += list.children[i].textContent +  '\n'
    }

    let result = document.getElementById('result');
    result.textContent = text.trimEnd();
}
