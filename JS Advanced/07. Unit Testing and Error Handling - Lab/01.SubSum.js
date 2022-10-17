function sum(array, start, end) {
    if(!Array.isArray(array)) {
        return NaN;
    }

    if(array.some(n => typeof n != typeof 2)) {
        return NaN;
    }

    start = start < 0 ? 0 : start;
    end = end >= array.length ? array.length - 1 : end;
    
    return array.map(n => Number(n))
                .filter(n => array.indexOf(n) >= start && array.indexOf(n) <= end)
                .reduce((n, sum) => sum + n, 0);
}

console.log(sum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));