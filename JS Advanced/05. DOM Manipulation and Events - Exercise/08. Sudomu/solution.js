function solve() {
    let [checkButton, clearButton] = document.querySelectorAll("button");
    checkButton.addEventListener("click", onClick);
    clearButton.addEventListener("click", clear);

    function onClick() {
        let table = document.querySelector("table");
        let output = document.getElementById("check").children[0];
        let isSolved = solved();

        table.style.border = isSolved ? "2px solid green" : "2px solid red";
        output.textContent = isSolved ? "You solve it! Congratulations!" : "NOP! You are not done yet...";
        output.style.color = isSolved ? "green" : "red";
        

        function solved() {
            if(Array.from(document.querySelectorAll("input[type='number']"))
                .some(n => n.value == "")){
                    return false;
            }

            let numbers = Array.from(document.querySelectorAll("input[type='number']"))
                .map(n => Number(n.value));

            let matrix = [[numbers[0], numbers[1], numbers[2]], 
            [numbers[3], numbers[4], numbers[5]], 
            [numbers[6], numbers[7], numbers[8]]];

            let sum = matrix[0][0] + matrix[0][1] + matrix[0][2];

            for(let i = 0; i < 3; i++) {
                let currentSum = 0; 
                for(let j = 0; j < 3; j++) {
                    currentSum += matrix[i][j];
                }

                if(currentSum != sum) {
                    return false;
                }
            }

            for(let i = 0; i < 3; i++) {
                let currentSum = 0; 
                for(let j = 0; j < 3; j++) {
                    currentSum += matrix[j][i];
                }

                if(currentSum != sum) {
                    return false;
                }
            }

            return true;
        }
    }

    function clear() {
        let table = document.querySelector("table");        
        let output = document.getElementById("check").children[0];

        table.style.border = "";
        output.textContent = "";

        Array.from(document.querySelectorAll("input[type='number']"))
            .forEach(n => n.value = "");
    }
}