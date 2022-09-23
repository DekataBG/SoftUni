function solve(){
    let hero = {mage, fighter};

    function mage(name){
        let mage = {
            name, 
            health: 100,
            mana: 100,
            cast
        }

        function cast(spell){
            this.mana--;
            console.log(`${this.name} cast ${spell}`);
        }

        return mage;
    }

    function fighter(name){
        let fighter = {
            name, 
            health: 100, 
            stamina: 100, 
            fight
        }

        function fight(){
            this.stamina--;
            console.log(`${this.name} slashes at the foe!`);
        }

        return fighter;
    }

    return hero;
}


let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);