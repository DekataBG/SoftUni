function findEqualNeighbors(matrix){
    let ctr = 0;
    
    let length = matrix.length;
    
    for(let i = 0; i < length; i++){
        for(let j = 0; j < length; j++){            
            if(i != length - 1 && matrix[i][j] == matrix[i + 1][j]){
                ctr ++ 
            }
            if(j != length - 1 && matrix[i][j] == matrix[i][j + 1]){
                ctr++;
            }
        }
    }

    console.log(ctr);
}

findEqualNeighbors(
[['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]);