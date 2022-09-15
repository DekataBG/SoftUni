function findDiagonalsSum(matrix){
    let length = matrix[0].length;
    let firstDiagonal = 0, secondDiagonal = 0;

    for(let i = 0; i < length; i++){
        firstDiagonal += matrix[i][i];
        secondDiagonal += matrix[length - i - 1][i];
    }

    console.log(firstDiagonal + ' ' + secondDiagonal);
}

findDiagonalsSum(
    [[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
    );