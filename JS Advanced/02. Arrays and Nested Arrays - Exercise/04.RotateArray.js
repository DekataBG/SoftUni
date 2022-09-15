function rotateArray(array, n){
    for(let i = 0; i < n; i++){
        let last = array.pop();
        array.unshift(last);
    }

    console.log(array.join(' '));
}

rotateArray(['1', 
'2', 
'3', 
'4'], 
2);