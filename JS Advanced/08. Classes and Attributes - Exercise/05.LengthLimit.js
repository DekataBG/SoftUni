class Stringer {    
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength -= length;
        this.innerLength = this.innerLength <= 0 ? 0 : this.innerLength;
    }

    toString() {
        let newWord = '';

        for(let i = 0; i < this.innerLength && i < this.innerString.length; i++) {
            newWord += this.innerString[i];
        }

        return this.innerString == newWord ? this.innerString : newWord + "...";
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
