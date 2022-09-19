function parseTownsToJSON(array){
    let towns = [];
    
    for(let i = 1; i < array.length; i++){
        let info = array[i].split(' | ');
        let town = info[0].substring(2);
        let latitude = Number(Number(info[1]).toFixed(2));
        let longitude = Number(Number(info[2].substring(0, info[2].length - 2)).toFixed(2));
        
        towns.push({
            Town: town, 
            Latitude: latitude, 
            Longitude: longitude
        });
    }

    console.log(JSON.stringify(towns));
}

parseTownsToJSON(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']);