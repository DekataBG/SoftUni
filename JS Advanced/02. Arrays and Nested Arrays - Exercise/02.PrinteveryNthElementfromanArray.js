function getNewArray(array, n){
    let newArray = [];

    for(let i = 0; i < array.length; i+=n)
    {
        newArray.push(array[i]);    
    }

    return newArray;
}

console.log(getNewArray(['dsa',
'asd', 
'test', 
'tset'], 
2
));