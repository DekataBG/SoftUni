function solution() {
    let string = {content: '', append, removeStart, removeEnd, print};

    return string;

    function append(str) {
        this.content += str;
    }

    function removeStart(n) {
        this.content = this.content.substring(n);
    }

    function removeEnd(n) {
        this.content = this.content.substring(0, this.content.length - n);
    }

    function print() {
        console.log(this.content);
    }
}


let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();