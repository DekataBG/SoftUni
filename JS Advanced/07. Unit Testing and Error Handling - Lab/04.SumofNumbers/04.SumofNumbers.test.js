const { expect } = require('chai');
const sum = require('./sumNumbers');

describe ('sum', () => {
    it('should calculate sum correctly', () => {
        //Arrange
        let array = [1, 2, 3, 4];

        //Act
        let result = sum(array);

        //Assert
        expect(result).to.be.equal(10);
    }),
    it('should return NaN', () => {
        //Arrange
        let array = [1, 2, 'f', 4];

        //Act
        let result = sum(array);

        //Assert
        expect(result).to.be.NaN;
    }),
    it('should calculate one number array', () => {
        //Arrange
        let array = [3];

        //Act
        let result = sum(array);

        //Assert
        expect(result).to.equal(3);
    }),
    it('should calculate 0 numbers array', () => {
        //Arrange
        let array = [];

        //Act
        let result = sum(array);

        //Assert
        expect(result).to.equal(0);
    })
});