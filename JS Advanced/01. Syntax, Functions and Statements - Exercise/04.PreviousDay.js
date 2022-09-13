function getPreviousDay(year, month, date){
    let calendarDate = new Date(year, month - 1, date);

    calendarDate.setDate(calendarDate.getDate() - 1);

    year = calendarDate.getFullYear();
    month = calendarDate.getMonth();
    date = calendarDate.getDate();

    console.log(`${year}-${month + 1}-${date}`);
}

getPreviousDay(2016, 10, 1);