function createObject(array){
    let foodBook = {};

    for(let i = 0; i < array.length; i += 2){
        foodBook[array[i]] = Number(array[i + 1]);
    }

    console.log(foodBook);
}

createObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);