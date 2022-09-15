function makeNewArray(array){
    let newArray = [];
    
    for(let i = array.length - 1; i  >= 0; i--){
        if(i % 2 == 1){
            newArray.push(2 * array[i]);
        }
    }

    console.log(newArray.join(' '));
}

makeNewArray([3, 0, 10, 4, 7, 3]);