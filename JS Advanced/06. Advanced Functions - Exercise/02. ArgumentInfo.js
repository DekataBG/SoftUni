function processParamaters(...arguments) {
    let types = {};

    Array.from(Object.values(arguments))
        .forEach(a =>{
            console.log(`${typeof a}: ${a}`);
            types[typeof a] = types[typeof a] ? types[typeof a] + 1 : 1;
        });

        Array.from(Object.keys(types))
            .sort((a, b) => types[b] - types[a])
            .forEach(t =>{
                console.log(`${t} = ${types[t]}`);
            });
}

processParamaters({ name: 'bob'}, 3.333, 9.999);