function add(n) {
    let sum = 0;

    function newAdd(x) {
        sum += x;

        return newAdd;
    }

    newAdd.toString = () => sum;

    return newAdd(n);
}


console.log(add(4)(3).toString());