function calculateMoney(type, weight, pricePerKg){
    let money = weight * pricePerKg / 1000;
    weight /= 1000;

    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${type}.`);
}

calculateMoney('orange', 2500, 1.80);