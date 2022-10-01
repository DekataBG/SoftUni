function filterEmployee(data, criteria) {
    let employees = JSON.parse(data);

    criteria = criteria.split('-');

    return employees
        .filter(e => e[criteria[0]] == criteria[1])
        .map((e, i) => `${i}. ${e.first_name} ${e.last_name} - ${e.email}`)
        .join('\n');
}


filterEmployee(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`, 
'all');