function changeMatrix(matrix){
    matrix = transformMatrix();

    let diagonal1 = calculateDiagonalOne();
    let diagonal2 = calculateDiagonalTwo();

    if(diagonal1 == diagonal2){
        for(let i = 0; i < matrix.length; i++){
            for(let j = 0; j < matrix.length; j++){
                if(i != j && i != matrix.length - 1 - j){
                    matrix[i][j] = diagonal1;
                }
            }
        }
    }

    initialiseMatrix();


    function transformMatrix(){
        for(let i = 0; i < matrix.length; i++){
            matrix[i] = matrix[i].split(' ').map(n => Number(n));
        }

        return matrix;
    }
    
    function calculateDiagonalOne(){
        let sum = 0;
        
        for(let i = 0; i < matrix.length; i++){
            sum += matrix[i][i];
        }

        return sum;
    }

    function calculateDiagonalTwo(){
        let sum = 0;
        
        for(let i = 0; i < matrix.length; i++){
            sum += matrix[i][matrix.length - 1 - i];
        }

        return sum;
    }

    function initialiseMatrix(){
        for(let i = 0; i < matrix.length; i++){
            console.log(matrix[i].join(' '));
        }
    }
}

let matrix = 
['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1'];

changeMatrix(matrix);

