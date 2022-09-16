function orbit(command) {
    let dim1 = command[0];
    let dim2 = command[1];

    let coord1 = command[2];
    let coord2 = command[3];

    let matrix = [];

    for(let i = 0; i < dim1; i++){
        matrix.push([]);
    }

    matrix[coord1][coord2] = 1;

    let len1 = coord1;
    let len2 = dim1 - 1 - len1;
    let len3 = coord2;
    let len4 = dim2 - 1 - len3;

    let max = findMaxDistance(len1, len2, len3, len4);

    for(let i = 1; i <= max; i++){
        fillLayer(i);
    }

    showMatrix();

    function findMaxDistance(d1, d2, d3, d4){
        if(d1 >= d2 && d1 >= d3 && d1 >= d4){
            return d1;
        }else if(d2 >= d1 && d2 >= d3 && d2 >= d4){
            return d2;
        }else if(d3 >= d1 && d3 >= d2 && d3 >= d4){
            return d3;
        }else{
            return d4;
        }
    }

    function fillLayer(layer){
        let lowerCorner = coord1  - layer;
        let upperCorner = coord1 + layer;
        let leftCorner = coord2 - layer;
        let rightCorner = coord2 + layer;

        for(let i = leftCorner; i <= rightCorner && i < dim2; i++){
            if(i >= 0){
                if(upperCorner < dim1){
                    matrix[upperCorner][i] = layer + 1;
                }

                if(lowerCorner >= 0){
                    matrix[lowerCorner][i] = layer + 1;
                }
            }
        }

        for(let i = lowerCorner; i <= upperCorner && i < dim1; i++){
            if(i >= 0){
                if(rightCorner < dim2){
                    matrix[i][rightCorner] = layer + 1;
                }

                if(leftCorner >= 0){
                    matrix[i][leftCorner] = layer + 1;
                }
            }
        }

        return matrix;
    }

    function showMatrix(){
        for(let i = 0; i < matrix.length; i++){
            console.log(matrix[i].join(' '));
        }
    }
}

orbit([3, 3, 2, 2]);