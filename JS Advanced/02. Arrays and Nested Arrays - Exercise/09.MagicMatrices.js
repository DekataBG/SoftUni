function isMagical(array){
    let sum = calculateRow(array, 0);
    
    for(let i = 1; i < array.length; i++){
        if(sum != calculateRow(array, i) || sum != calculateColumn(array, i)){
            return false;
        }
    }

    return true;

    
    function calculateRow(array, row){
        let sum = array[row].reduce((sum, currentValue) => sum + currentValue, 0);

        return sum;
    }

    function calculateColumn(array, column){
        let sum = 0;

        for(let i = 0; i < array.length;i++){
            sum += array[i][column];
        }

        return sum;
    }
}

console.log(isMagical(
    [[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]));