function sortTickets(tickets, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let array = [];
    tickets.forEach(t => {
        let [destination, price, status] = t.split('|');
        price = Number(price);

        array.push(new Ticket(destination, price, status));
    });
    

    array.sort((a, b) => {
        if(criteria != 'price') {
            return a[criteria].localeCompare(b[criteria])
        } else {
            return a - b;
        }
    });

    return array;
}


console.log(sortTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));