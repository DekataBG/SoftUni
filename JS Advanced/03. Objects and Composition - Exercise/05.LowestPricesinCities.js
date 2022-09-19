function findTownsWithLowestPrice(array){
    let products = {};

    for(info of array){
        let [town, product, price] = info.split(' | ');
        price = Number(price);

        if(!products[product]){
            products[product] = {town, price};
        }else{
            if(price < products[product].price){
                products[product].town = town;
                products[product].price = price;
            }
        }
    }

    for(product in products){
        console.log(`${product} -> ${products[product].price} (${products[product].town})`);
    }
}

findTownsWithLowestPrice(['Sofia City | Audi | 100000',
'Sofia City | BMW | 100000',
'Sofia City | Mitsubishi | 10000',
'Sofia City | Mercedes | 10000',
'Sofia City | NoOffenseToCarLovers | 0',
'Mexico City | Audi | 1000',
'Mexico City | BMW | 99999',
'Mexico City | Mitsubishi | 10000',
'New York City | Mitsubishi | 1000',
'Washington City | Mercedes | 1000']);