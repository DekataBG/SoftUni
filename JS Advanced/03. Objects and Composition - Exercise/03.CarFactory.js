function modifyCar(car){
    let newCar = {}, engine = {}, carriage = {};

    if(car.power <= 90){
        engine.power = 90;
        engine.volume = 1800;
    }else if(car.power <= 120){
        engine.power = 120;
        engine.volume = 2400;
    }else if(car.power <= 200){
        engine.power = 200;
        engine.volume = 3500;
    }

    carriage.type = car.carriage;
    carriage.color = car.color;

    let wheel = car.wheelsize % 2 == 1 ? car.wheelsize : car.wheelsize - 1;

    newCar.model = car.model;
    newCar.engine  = engine;
    newCar.carriage = carriage;
    newCar.wheels = Array(4).fill(wheel); 
    return newCar;
}

console.log(modifyCar({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));