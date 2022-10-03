function getFibonator() {
    let previous = 0;
    let current = 0;

    function calculateNext() {
        if(current == 0) {
            current = 1;
            return 1;
        }

        let result = previous + current;
        
        previous = current;
        current = result;

        return result;
    }
    
    return calculateNext;
}


let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
