function solve() {
    let sentences =  document.getElementById('input').value
        .split(".")
        .filter(x => x.length >= 1)
        .map(x => x.trim());

    let result = '';
    for (let i = 0; i < sentences.length; i += 3) {
      let arr = [];

      for (let y = 0; y < 3; y++) {
          if (sentences[i + y]) {
              arr.push(sentences[i + y]);
          }
      }
      
      let paragraph = arr.join('. ') + '.';
      result += `<p>${paragraph}</p>`;
  }

    document.getElementById('output').innerHTML = result;
}