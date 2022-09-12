function solve(n, m){
    let num1 = Number(n);
    let num2 = Number(m);

    let max, min;
    let sum = 0;

    if(num1 <= num2){
        min = num1;
        max = num2;
    }
    else{
        max = num1;
        min = num2;
    }

    for(let i = num1; i<= num2; i++){
        sum += i;
    }

    console.log(sum);
}
