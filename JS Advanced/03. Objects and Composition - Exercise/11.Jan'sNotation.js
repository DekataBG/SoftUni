function solveExpression(array){
    let manager = {
        add(a, b) { return a + b; },
        subtract(a, b) { return a - b; },
        multiply(a, b) { return a * b; },
        divide(a, b) { return a / b; }
    };

    let numbers = [];
    
    for(element of array){
        if(typeof element == 'number'){
            numbers.push(element);
        }else{
            if(numbers.length < 2){
                console.log("Error: not enough operands!");
                break;
            }else{
                let a = numbers.pop();
                let b = numbers.pop();

                let result;
                switch(element){
                    case '+': 
                        result = manager.add(b, a);
                        break;
                    case '-': 
                        result = manager.subtract(b, a);
                        break;
                    case '*': 
                        result = manager.multiply(b, a);
                        break;
                    case '/': 
                        result = manager.divide(b, a);
                        break;
                }

                numbers.push(result);
            }
        }
    }

    if(numbers.length > 1){
        console.log("Error: too many operands!");
    }else{
        console.log(numbers[0]);
    }
}

solveExpression([
 7,
 33,
 8,
 '-']);