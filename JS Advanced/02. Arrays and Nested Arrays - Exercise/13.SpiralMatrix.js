function makeSpiralArray(width, height){
    let matrix = [];

    for(let i = 0; i < height; i++){
        matrix.push([]);
    }

    let min;
    let current = 1;

    if(width <= height){
        min = width;
    }else{
        min = height;
    }

    for(let i = 0; i < Math.ceil(min / 2); i++){
        fillFirstRow(i);
        fillRightColumn(i);
        fillLastRow(i);
        fillLeftColumn(i);
    }

    showMatrix();


    function fillFirstRow(start){
        for(let i = start; i < width - start; i++){
            matrix[start][i] = current;
            current++;
        }
    }

    function fillRightColumn(start){
        for(let i = start + 1; i < height - start; i++){
            matrix[i][width - start - 1] = current;
            current++;
        }
    }

    function fillLastRow(start){
        for(let i = width - start - 2; i >= start; i--){
            matrix[height - start - 1][i] = current;
            current++;
        }
    }

    function fillLeftColumn(start){
        for(let i = height - start - 2; i > start; i--){
            matrix[i][start] = current;
            current++;
        }
    }

    function showMatrix(){
        for(let i = 0; i < matrix.length; i++){
            console.log(matrix[i].join(' '));
        }
    }
}

makeSpiralArray(5, 5);