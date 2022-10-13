function calculator() {
    let object = {
        init:  function init(selector1, selector2, resultSelector) {
            this.element1 = document.querySelector(selector1);
            this.element2 = document.querySelector(selector2);
            this.element3 = document.querySelector(resultSelector); 
        },
        add: function add() {
            this.element3.value = Number(this.element1.value) + Number(this.element2.value);
        }, 
        subtract: function subtract() {
            this.element3.value = Number(this.element1.value) - Number(this.element2.value);
        }
    };

    return object;
}

const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result'); 

