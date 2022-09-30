function createCars(commands) {
    let list = {};
    let pairs = [];

    let processor = {
        create: (name, keyword, otherName) => {
            list[name] = {};

            if(keyword) {
                pairs.push([name, otherName]);
            }
        }, 
        set: (name, property, value) => list[name][property] = value, 
        print: (name) => console.log(list[name])
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
'print c2']);