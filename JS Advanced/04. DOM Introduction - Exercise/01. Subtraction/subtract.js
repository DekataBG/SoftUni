function subtract() {
    let number1 = Number(document.getElementById('firstNumber').value);
    let number2 = Number(document.getElementById('secondNumber').value);

    let result = number1 - number2;

    let resultElement = document.querySelector('div #result');
    resultElement.textContent += result;
}