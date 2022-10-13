function getArticleGenerator(articles) {    
    return () => {
        if(articles.length > 0) {
            let content = document.getElementById("content");
            let node = document.createElement("article");
            node.textContent = articles.shift();

            content.appendChild(node);
        }
    }
}
