function toUpperString(string){
    let result = string
        .toUpperCase()
        .match(/\w+/g)
        .join(', ');

    console.log(result);
}
