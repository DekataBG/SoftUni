function solution(n){
    let newFunction = addNumbers.bind(null, n);

    return newFunction;

    
    function addNumbers(a, b) {
        return a + b;
    }
}


let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));