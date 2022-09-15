function extractSubset(array){
    let newArray = [array[0]];

    for(let i = 1; i < array.length; i++){
        if(array[i] >= newArray[newArray.length - 1]){
            newArray.push(array[i]);
        }
    }

    return newArray;
}

console.log(
    [20, 
    3, 
    2, 
    15,
    6, 
    1]);