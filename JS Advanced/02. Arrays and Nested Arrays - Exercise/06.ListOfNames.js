function sortArray(array){
    array.sort((x, y) => x.localeCompare(y));

    for(let i = 1; i <= array.length; i++){
        console.log(i + '.' + array[i- 1]);
    }
}

sortArray(["John", "Bob", "Christina", "Ema", "afi"]);