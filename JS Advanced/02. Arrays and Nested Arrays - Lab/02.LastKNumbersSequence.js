function generateSequence(n, k){
    let sequence = [1];

    while(sequence.length < n){
        let currentIndex = sequence.length;
        let nextElement = 0;

        for(let i = currentIndex - 1; i > currentIndex - 1 - k; i--){
            if(i >= 0){
                nextElement += sequence[i];
            }
        }

        sequence[currentIndex] = nextElement;
    }

    return sequence;
}
