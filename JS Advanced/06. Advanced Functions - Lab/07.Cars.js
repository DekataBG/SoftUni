function createCars(commands) {
    let list = {};

    let processor = {
        create: (name, keyword, otherName) => {
            list[name] = {parent: list[otherName]};
        }, 
        set: (name, property, value) => {
            list[name][property] = value;   
        },
        print: (name) => {
            let currentCar = list[name];
            let properties = [];

            while(currentCar) {
                Array.from(Object.keys(currentCar))
                    .filter(k => k != "parent")
                    .forEach(k => properties.push(`${k}:${currentCar[k]}`));

                currentCar = currentCar.parent;
            }

            console.log(properties.join(','));
        }
    };

    commands = commands
        .map(c => c.split(' '))
        .map(c => processor[c[0]](c[1], c[2], c[3]));
}


createCars(['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2']
);