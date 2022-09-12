function getNumberOfDays(month, year){
    let date1 = new Date(year, month - 1, 1);
    let date2 = new Date(year, month, 1);

    let ms = date2.getTime() - date1.getTime();
    let result = ms / (1000 * 3600 * 24);

    console.log(result);
}

getNumberOfDays(2, 2000)