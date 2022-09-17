function createAssemblyLine(){
    let assemblyLine = {hasClima, hasAudio, hasParktronic};

    return assemblyLine;

    function hasClima(obj){
        obj.temp = 21,
        obj.tempSettings = 21,
        obj.adjustTemp = function(){
            if(obj.temp < obj.tempSettings){
                obj.temp++;
            }else if(obj.temp > obj.tempSettings){
                obj.temp--;
            }
        }
    }

    function hasAudio(obj){
        obj.currentTrack = {
            name: null, 
            artist: null
        };

        obj.nowPlaying = function(){
            if(obj.currentTrack != null){
                console.log(`Now playing '${obj.currentTrack.name}' by ${obj.currentTrack.artist}`);
            }
        }
    }

    function hasParktronic(obj){
        obj.checkDistance = function(distance){
            if(distance < 0.1){
                console.log("Beep! Beep! Beep!");
            }else if(distance < 0.25){
                console.log("Beep! Beep!");
            }else if(distance < 0.5){
                console.log("Beep!");
            }else{
                console.log();
            }
        }
    }
}


const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

console.log(myCar);