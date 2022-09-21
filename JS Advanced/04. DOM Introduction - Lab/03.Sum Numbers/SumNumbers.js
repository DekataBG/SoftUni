function calc() {
    let element1 = document.getElementById('num1');
    let element2 = document.getElementById('num2');
    let element3 = document.getElementById('sum');

    number1 = Number(element1.value);
    number2 = Number(element2.value);

    element3.value = number1 + number2;
}
