function calculateTime(steps, length, speed){
    let distanceInM = steps  * length;
    let breakTimeInS  = Math.floor(distanceInM / 500) * 60;

    let speedInMS = speed / 3.6;

    let timeInS = Math.round(distanceInM / speedInMS) + breakTimeInS;

    let seconds = timeInS % 60;
    let minutes = Math.floor(timeInS / 60);
    let hours = Math.floor(timeInS / 3600);

    if(seconds.toString().length ==  1){
        seconds = `0${seconds}`;
    }

    if(minutes.toString().length ==  1){
        minutes = `0${minutes}`;
    }

    if(hours.toString().length ==  1){
        hours = `0${hours}`;
    }

    console.log(`${hours}:${minutes}:${seconds}`);
}
