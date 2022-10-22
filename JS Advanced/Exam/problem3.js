describe('test', () => {
    describe('choosingType', () => {
        it('small years should throw error', () => {
            //Arrange
            let type = "type";
            let color = "red";
            let year = 1800;

            //Act
        

            //Assert
            expect(() => chooseYourCar.choosingType(type, color, year)).to.throw("Invalid Year!");

        }),
        it('big years should throw error', () => {
            //Arrange
            let type = "type";
            let color = "red";
            let year = 3000;

            //Act
        

            //Assert
            expect(() => chooseYourCar.choosingType(type, color, year)).to.throw("Invalid Year!");

        }),
        it('wrong type should throw error', () => {
            //Arrange
            let type = "notSedan";
            let color = "red";
            let year = 2011;

            //Act
        

            //Assert
            expect(() => chooseYourCar.choosingType(type, color, year)).to.throw("This type of car is not what you are looking for.");

        }),
        it('valid car 2010', () => {
            //Arrange
            let type = "Sedan";
            let color = "red";
            let year = 2010;

            //Act
            let output = chooseYourCar.choosingType(type, color, year);

            //Assert
            expect(output).to.be.equal(`This ${color} ${type} meets the requirements, that you have.`);

        }),
        it('valid car > 2010', () => {
            //Arrange
            let type = "Sedan";
            let color = "red";
            let year = 2020;

            //Act
            let output = chooseYourCar.choosingType(type, color, year);

            //Assert
            expect(output).to.be.equal(`This ${color} ${type} meets the requirements, that you have.`);

        }),
        it('invalid car < 2010', () => {
            //Arrange
            let type = "Sedan";
            let color = "red";
            let year = 2001;

            //Act
            let output = chooseYourCar.choosingType(type, color, year);

            //Assert
            expect(output).to.be.equal(`This ${type} is too old for you, especially with that ${color} color.`);

        })
    }),
    describe('brandName', () => {
        it('not an array throws error', () => {
            //Arrange
            let brands = "BMW";
            let brandIndex = 1;

            //Act

            //Assert
            expect(() => chooseYourCar.brandName(brands, brandIndex)).to.throw("Invalid Information!");
            
        }),
        it('not a number throws error', () => {
            //Arrange
            let brands = ["BMW", "Toyota", "Peugeot"];
            let brandIndex = '1';

            //Act

            //Assert
            expect(() => chooseYourCar.brandName(brands, brandIndex)).to.throw("Invalid Information!");
            
        }),
        it('small index throws error', () => {
            //Arrange
            let brands = ["BMW", "Toyota", "Peugeot"];
            let brandIndex = -8;

            //Act

            //Assert
            expect(() => chooseYourCar.brandName(brands, brandIndex)).to.throw("Invalid Information!");
            
        }),
        it('big index throws error', () => {
            //Arrange
            let brands = ["BMW", "Toyota", "Peugeot"];
            let brandIndex = 8;

            //Act

            //Assert
            expect(() => chooseYourCar.brandName(brands, brandIndex)).to.throw("Invalid Information!");
            
        }),
        it('removing works correctly', () => {
            //Arrange
            let brands = ["BMW", "Toyota", "Peugeot"];
            let brandIndex = 1;

            //Act
            let output = chooseYourCar.brandName(brands, brandIndex)

            //Assert
            expect(output).to.equal("BMW, Peugeot");
            
        })
    }),
    describe('carFuelConsumption', () => {
        it('Invalid distance type throws error', () => {
            //Arrange
            let distance = '200';
            let consumed = 10;

            //Act


            //Assert
            expect(() => chooseYourCar.carFuelConsumption(distance, consumed)).to.throw("Invalid Information!");
            
        }),
        it('Invalid distance throws error', () => {
            //Arrange
            let distance = -200;
            let consumed = 10;

            //Act


            //Assert
            expect(() => chooseYourCar.carFuelConsumption(distance, consumed)).to.throw("Invalid Information!");
            
        }),
        it('Invalid consumption type throws error', () => {
            //Arrange
            let distance = 200;
            let consumed = '10';

            //Act


            //Assert
            expect(() => chooseYourCar.carFuelConsumption(distance, consumed)).to.throw("Invalid Information!");
            
        }),
        it('Invalid consumption throws error', () => {
            //Arrange
            let distance = 200;
            let consumed = -10;

            //Act


            //Assert
            expect(() => chooseYourCar.carFuelConsumption(distance, consumed)).to.throw("Invalid Information!");
            
        }),
        it('the car is efficient', () => {
            //Arrange
            let distance = 200;
            let consumed = 10;
            let litersPerHundredKm =((consumed / distance)* 100).toFixed(2);
            
            //Act
            let result = chooseYourCar.carFuelConsumption(distance, consumed);

            //Assert
            expect(result).to.equal(`The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`);
            
        }),
        it('the car is efficient', () => {
            //Arrange
            let distance = 100;
            let consumed = 7;
            let litersPerHundredKm =((consumed / distance)* 100).toFixed(2);
            
            //Act
            let result = chooseYourCar.carFuelConsumption(distance, consumed);

            //Assert
            expect(result).to.equal(`The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`);
            
        }),
        it('the car burns too much fuel', () => {
            //Arrange
            let distance = 200;
            let consumed = 40;
            let litersPerHundredKm =((consumed / distance)* 100).toFixed(2);
            
            //Act
            let result = chooseYourCar.carFuelConsumption(distance, consumed);

            //Assert
            expect(result).to.equal(`The car burns too much fuel - ${litersPerHundredKm} liters!`);
            
        })
    })
})