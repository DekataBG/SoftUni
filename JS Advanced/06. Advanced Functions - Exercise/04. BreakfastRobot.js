function solution() {
    let microelements = {
        protein: 0, 
        carbohydrate: 0, 
        fat: 0, 
        flavour: 0
    };
    
    function manage(input) {
        let [command, item, quantity] = input.split(" ");
        quantity = Number(quantity);

        let keys = Array.from(Object.keys(microelements));

        const manager = {
            restock: function restock() {
                microelements[item] += quantity;
                return "Success";
            },
            prepare: function prepare() {
                const foodManager = {
                    apple: [0, 1, 0, 2],
                    lemonade: [0, 10, 0, 20],
                    burger: [0, 5, 7, 3],
                    eggs: [5, 0, 1, 1],
                    turkey: [10, 10, 10, 10]   
                };

                let [protein, carbohydrate, fat, flavour] = foodManager[item];
                
                let neccessary = {
                    protein: quantity * protein, 
                    carbohydrate: quantity * carbohydrate, 
                    fat: quantity * fat, 
                    flavour: quantity * flavour
                };

                for(k of keys) {
                    if(microelements[k] - neccessary[k] < 0) {
                        return `Error: not enough ${k} in stock`;
                    }
                }

                keys.forEach(k => {
                    microelements[k] -= neccessary[k];
                });

                return "Success";

            }, 
            report: function report() {
                return keys
                    .map(k => `${k}=${microelements[k]}`)
                    .join(' ')
            }
        }

        return manager[command]();
    }

    return manage;
}


let manager = solution (); 
console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
console.log (manager ("restock carbohydrate 10"));
console.log (manager ("restock flavour 10"));
console.log (manager ("prepare apple 1"));
console.log (manager ("restock fat 10"));
console.log (manager ("prepare burger 1"));
console.log (manager ("report"));

// restock flavour 50 
// prepare lemonade 4 
// restock carbohydrate 10
// restock flavour 10
// prepare apple 1
// restock fat 10
// prepare burger 1
// report
