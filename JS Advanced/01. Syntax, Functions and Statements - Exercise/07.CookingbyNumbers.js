function cook(number, op1, op2, op3, op4, op5){
    let operations = [number, op1, op2, op3, op4, op5];

    let num = Number(operations[0]);

    for(let i = 1; i < operations.length; i++){
        switch(operations[i]){
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num++;
                break;
            case 'bake':
                num *= 3;
                break;
            case 'fillet':
                num *= 0.8;
                break;
        }

        console.log(num);
    }
}
