class List {
    constructor() {
        this._numbers = [];
        this.size = 0;
    }
    
    add(element) {
        this._numbers.push(element);
        this._numbers.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        if(index >= 0 && index < this.size) {
            this._numbers.splice(index, 1);
            this._numbers.sort((a, b) => a - b);
            this.size--;
        }
    };

    get(index) {
        if(index >= 0 && index < this.size) {
            return this._numbers[index];
        }
    };
}

let list = new List();
list.add(0);
list.add(1);
list.add(2);
list.add(3);
list.add(4);

console.log(list.get(0)); 
list.remove(0);
console.log(list.size);
