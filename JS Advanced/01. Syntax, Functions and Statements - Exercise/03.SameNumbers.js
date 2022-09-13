function sumOfDigits(number){
    number = number.toString();
    let digit = number[0];
    let same = true;
    let sum = 0;

    for(let  i = 0;i < number.length; i++){
        if(digit != number[i]){
            same = false;
        }

        sum += Number(number[i]);
    }

    console.log(same);
    console.log(sum);
}

sumOfDigits(22222);