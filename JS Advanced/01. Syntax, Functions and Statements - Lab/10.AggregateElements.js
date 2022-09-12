function solve(arr){
    let sum = 0, invSum = 0;
    let string = '';

    for(let i = 0;i < arr.length;i++){
        sum += arr[i];
        invSum += 1 / arr[i];
        string += arr[i];
    }

    console.log(sum);
    console.log(invSum);
    console.log(string);
}

solve([1,2,3]);