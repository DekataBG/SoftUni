function characterCount(word1, word2, word3){
    let len1 = word1.toString().length;
    let len2 = word2.toString().length;
    let len3 = word3.toString().length;

    let sum = len1 + len2 + len3;
    
    console.log(sum);
    console.log(Math.floor(sum / 3));
}

characterCount("chocolate", "ice cream", "cake");