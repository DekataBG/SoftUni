function sort(array, logic) {
    return logic == 'asc' ? array.sort((a, b) => a - b) : array.sort((a, b) => b - a);
}

console.log(sort([14, 7, 17, 6, 8], 'asc'));