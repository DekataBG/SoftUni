function makeSmallerArray(array){
    array.sort((a, b)=> a - b);

    array.splice(0, Math.floor(array.length / 2));

    return array;
}

console.log(makeSmallerArray([4, 7, 2, 5]));