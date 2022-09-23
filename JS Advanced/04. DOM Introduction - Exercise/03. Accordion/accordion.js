function toggle() {
    let extra = document.getElementById('extra');
    let button = document.querySelector('span.button');

    if(button.textContent == 'More'){
        extra.style.display = 'block';
        button.textContent = 'Less';
    }else{
        extra.style.display = 'none';
        button.textContent = 'More';
    }
}