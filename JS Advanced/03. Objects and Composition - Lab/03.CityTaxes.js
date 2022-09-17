function cityTaxes(name, population, treasury){
    let city = {name, population, treasury, taxRate: 10, collectTaxes, applyGrowth, applyRecession};

    return city;

    function collectTaxes(){
        this.treasury += Math.round(this.population * this.taxRate);
    }

    function applyGrowth(percentage){
        this.population += Math.round(this.population * percentage / 100);
    }

    function applyRecession(percentage){
        this.treasury -= Math.round(this.treasury * percentage / 100);
    }
}

const city =
  cityTaxes('Tortuga',
  7000,
  15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);