function solve() {
    addOptions();

    document.querySelector('button').addEventListener('click', onClick);

    function onClick(){ 
        let numericalSystem = document.getElementById('selectMenuTo').value;
        let number = Number(document.getElementById('input').value);

        let result;

        if(numericalSystem == 'binary') {
            result = convertToBinary(number);
        } else if(numericalSystem == 'hexadecimal') {
            result = convertToHexadecimal(number);
        }

        document.getElementById('result').value = result;

        
        function convertToBinary(number){
            let result = [];

            while(number != 0) {
                let previousNumber = number;
                number = Math.floor(number / 2);

                let remainder = previousNumber - number * 2;
                result.unshift(remainder);
            }

            return result.join('');
        }

        function convertToHexadecimal(number){
            let result = [];
            
            while(number != 0) {
                let previousNumber = number;
                number = Math.floor(number / 16);

                let remainder = previousNumber - number * 16;
                switch(remainder) {
                    case 10: 
                        remainder = 'A';
                        break;
                    case 11: 
                        remainder = 'B';
                        break;
                    case 12: 
                        remainder = 'C';
                        break;
                    case 13: 
                        remainder = 'D';
                        break;
                    case 14: 
                        remainder = 'E';
                        break;
                    case 15: 
                        remainder = 'F'; 
                        break;
                }

                result.unshift(remainder);
            }

            return result.join('');
        }
    }

    function addOptions(){
        let select = document.getElementById('selectMenuTo');

        var option1 = document.createElement('option');
        option1.value = "binary";
        option1.innerHTML = "Binary";
        
        var option2 = document.createElement('option');
        option2.value = "hexadecimal";
        option2.innerHTML = "Hexadecimal";
    
        select.appendChild(option1);
        select.appendChild(option2);    
    }
}