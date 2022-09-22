function extractText() {
    let element = document.getElementById('items');

    let list = Array.from(element.children);
    list = list.map(e => e.textContent);

    let text = list.join('\n');

    document.getElementById('result').textContent = text;
}

extractText();