function findTwoSmallestNumbers(array){
    function findSmallestNumber(array){
        let smallest = array[0];
        let indexOfSmallest = 0;

        for(let i = 1; i < array.length; i++){
            if(array[i] < smallest){
                smallest = array[i];
                indexOfSmallest = i;
            }
        }

        return indexOfSmallest;
    }

    let index1 = findSmallestNumber(array);
    let firstElement = array[index1];
    array.splice(index1, 1);

    let index2 = findSmallestNumber(array);
    let secondElement = array[index2];

    console.log(firstElement + ' ' + secondElement);
}

