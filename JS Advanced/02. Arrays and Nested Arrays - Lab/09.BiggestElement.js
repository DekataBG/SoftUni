 function findBiggestElement(matrix){
    var array = matrix.flat();
    array.sort((a, b) => b - a)
    
    console.log(array[0]);
 }

 findBiggestElement([[20, 50, 10],
    [8, 33, 145]]);
