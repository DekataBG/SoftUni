function printNewArray(array){
    let newArray = [];
    
    for(let i = 0; i < array.length; i++){
        if(array[i] == 'add'){
            newArray.push(i + 1);
        }else{
            newArray.pop();
        }
    }

    if(newArray.length == 0){
        console.log('Empty')
    }else{
        console.log(newArray.join('\n'));
    }
}

printNewArray(
    ['remove', 
    'remove', 
    'remove']
);
