function extract(content) {
    let element = document.getElementById(content);
    let text = element.innerText;

    let result = [];
    while(text.includes('(')){
        let firstIndex = text.indexOf('(');
        let secondIndex = text.indexOf(')');

        let word = '(' + text.substring(firstIndex + 1, secondIndex) + ')';
        result.push(word.substring(1, word.length - 1));

        text = text.replace(word, '');
    }

    return result.join('; ');
}