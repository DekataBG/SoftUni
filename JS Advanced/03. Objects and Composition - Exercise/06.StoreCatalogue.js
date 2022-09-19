function orderProduct(array){
    let food = {};
    let products = [];

    for(item of array){
        let [product, price] = item.split(' : ');

        food[product] = price;
        products.push(product);
    }

    products.sort((a, b) => a.localeCompare(b));

    let firstLetter = products[0][0];
    console.log(firstLetter);

    for(product of products){
        if(product[0] != firstLetter){
            firstLetter = product[0];
            console.log(firstLetter);
        }

        console.log(`${product}: ${food[product]}`);
    }
}

orderProduct(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);