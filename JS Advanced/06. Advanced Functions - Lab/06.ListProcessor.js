function processList(commands) {
    let list = [];

    let processor = {
        add: (item) => list.push(item), 
        remove: (item) => list = list.filter(i => i != item), 
        print: () => console.log(list.join(','))
    };

    commands = commands
        .map(c => c.split(' '))
        .map(c => processor[c[0]](c[1]));
}


processList(['add hello', 'add again', 'remove hello', 'add again', 'print']);