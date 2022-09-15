function sortArray(array){
    array.sort((x, y) => stringCompare(x, y));

    console.log(array.join('\n'));


    function stringCompare(string1, string2){
        if(string1.length > string2.length){
            return 1;
        }else if(string1.length == string2.length){
            return string1.localeCompare(string2);
        }else{
            return -1;
        }
    }
}

sortArray(
['test', 
'Deny', 
'omen', 
'Default']);