function sumTable() {
    let rows = document.querySelectorAll('td:nth-of-type(2n)');
    let sumInput = document.getElementById('sum');
    let sum= 0;

    for(let i = 0; i < rows.length - 1; i++){
        sum += Number(rows[i].innerText);
    }

    sumInput.innerText = sum;
}