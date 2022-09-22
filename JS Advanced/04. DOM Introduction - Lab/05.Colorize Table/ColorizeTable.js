function colorize() {
    let rows = document.querySelectorAll('tr:nth-of-type(2n)');

    for(row of rows){
        row.style.background = 'Teal';
    }
}