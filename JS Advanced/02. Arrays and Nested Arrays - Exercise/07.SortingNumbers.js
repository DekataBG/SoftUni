function sortArray(array){
    let newArray = [];
    let ctr = 0;

    array.sort((a, b) => a - b);

    while(array.length > 0){
        let element;
        if(ctr % 2 == 0){
            element = array.shift();
        }else {
            element = array.pop();
        }

        ctr++;

        newArray.push(element);
    }
    
    return newArray;
}

console.log(sortArray([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));