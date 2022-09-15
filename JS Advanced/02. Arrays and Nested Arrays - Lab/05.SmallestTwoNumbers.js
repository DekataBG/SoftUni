function findTwoSmallestNumbers(array){
    array.sort((a, b) => a - b);

    let first = array[0];
    let second = array[1];

    console.log(first + ' ' + second);
}

findTwoSmallestNumbers([2,3,1,6,5,-6]);
