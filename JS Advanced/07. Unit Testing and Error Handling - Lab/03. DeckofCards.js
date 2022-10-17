const createCard = require('./02.PlayingCards');

function printDeckOfCards(cards) {
    try {
        return cards.map(c => createCard(c.substring(0, c.length - 1), c[c.length - 1]).toString()).join(' ');
    } catch(ex) {
        return ex.message; 
    }
}


console.log(printDeckOfCards(['AS', '10D', 'KH', '1C']));