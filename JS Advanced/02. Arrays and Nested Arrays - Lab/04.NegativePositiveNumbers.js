function makeNewArray(array){
    let newArray = [];

    for(let i = 0; i < array.length; i++){
        let element = array[i];

        if(element < 0){
            newArray.unshift(element);
        }else{
            newArray.push(element);
        }
    }

    console.log(newArray.join('\n'));
}
