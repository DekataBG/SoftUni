function solve() {
    let string = document.getElementById('text').value;
    let namingConvention = document.getElementById('naming-convention').value;
    let resultElement = document.getElementById('result');
    let result;

    string = string.toLowerCase().split(' ');
    string = string.map(w => w[0].toUpperCase() + w.substring(1));
    string = string.join('');

    if(namingConvention == 'Camel Case'){
      result = string[0].toLowerCase() + string.substring(1);
    }else if(namingConvention == 'Pascal Case'){
      result = string;
    }else{
        result = 'Error!';
    }

    resultElement.textContent += result;
} 