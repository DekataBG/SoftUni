function checkIfInteger(x1, y1, x2, y2){
    distance1 = Math.sqrt(x1 * x1 + y1 * y1);
    distance2 = Math.sqrt(x2 * x2 + y2 * y2);
    distance3 = Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

    if(Math.floor(distance1) == distance1){
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }
    else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if(Math.floor(distance2) == distance2){
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    }
    else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if(Math.floor(distance3) == distance3){
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    }
    else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

checkIfInteger(2, 1, 1, 1);