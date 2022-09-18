function makeHeroRegister(array){
    let heroes = [];

    for(hero of array){
        let [name, level, items] = hero.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];

        heroes.push({name, level, items});
    }

    console.log(JSON.stringify(heroes));
}

makeHeroRegister(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']);