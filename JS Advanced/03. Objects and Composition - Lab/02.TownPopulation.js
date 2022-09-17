function addCityWithPopulation(array){
    let cities = {};

    for(let i = 0; i < array.length; i++){
        cityPopulation = array[i].split(' <-> ');
        let cityName = cityPopulation[0];
        let population = Number(cityPopulation[1]);

        if(cities[cityName] != undefined){
            cities[cityName] += population;
        }else{
            cities[cityName] = population;
        }
    }

    Object.keys(cities).forEach(k => console.log(`${k} : ${cities[k]}`));
}

addCityWithPopulation(
['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']);