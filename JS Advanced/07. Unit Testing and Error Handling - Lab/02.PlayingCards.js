function createCard(face, suit) {
    let card = {
        toString: function toString() {
                return this.face + this.suit;
            }
    };

    if(face == '2' || face ==  '3' || face == '4' || face ==  '5' || face == '6' 
        || face == '7' || face == '8' || face == '9' || face ==  '10' || face == 'J' 
        || face == 'Q' || face == 'K' || face ==  'A') {
            card.face = face;
    } else {
        throw new Error(`Invalid card: ${face + suit}`);
    }

    switch (suit) {
        case "S": 
            card.suit = "\u2660";
            break;
        case "H":
            card.suit = "\u2665";
            break;
        case "D":
            card.suit = "\u2666";
            break;
        case "C":
            card.suit = "\u2663";
            break;
        default: 
            throw new Error(`Invalid card: ${face + suit}`);
    }
    
    return card;
}

module.exports = createCard;