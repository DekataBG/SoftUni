function generateReport() {
    let indexes = {};

    Array.from(document.querySelectorAll('input[type="checkbox"]'))
        .forEach((c, i) => {
            if(c.checked){
                indexes[i] = c.name;
            }
        });

    let keys = Object.keys(indexes)
        .map(i => Number(i));

    let employeeInfo = Array.from(document.querySelectorAll('tbody tr'))
        .map(e => Array.from(e.children)
            .filter((x, i) => {
                if(keys.includes(i)){
                    return x;
                }
            })
            .map((x, i) => { 
                let obj = {};
                let field = keys[i];
                obj[indexes[field]] = x.textContent;    

                return obj;
            }))
        .map(x => {
            let emp = {};
            x.forEach(y => emp[Object.keys(y)[0]] = Object.values(y)[0]);

            return emp;
        });

    document.getElementById('output').value = JSON.stringify(employeeInfo);
}