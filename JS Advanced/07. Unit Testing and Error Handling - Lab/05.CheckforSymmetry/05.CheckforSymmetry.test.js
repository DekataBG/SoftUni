const { expect } = require('chai');
const isSymmetric = require('./checkForSymmetry');

describe('isSymmetric', ()  => {
    it('argument which isnt array should return false', () => {
        //Act
        let argument = {};

        //Arrange
        let result = isSymmetric(argument);

        //Assert
        expect(result).to.equal(false);
    }),
    it('argument which isnt array should return false', () => {
        //Act
        let argument = 5;

        //Arrange
        let result = isSymmetric(argument);

        //Assert
        expect(result).to.equal(false);
    }),
    it('argument which isnt array should return false', () => {
        //Act
        let argument = "abc";

        //Arrange
        let result = isSymmetric(argument);

        //Assert
        expect(result).to.equal(false);
    }),
    it('non-symmetrc array should return false', () => {
        //Act
        let argument = [1, 2, 3];

        //Arrange
        let result = isSymmetric(argument);

        //Assert
        expect(result).to.equal(false);
    }),
    it('symmetric array should return true', () => {
        //Act
        let argument = [1, 2, 3, 2, 1];

        //Arrange
        let result = isSymmetric(argument);

        //Assert
        expect(result).to.equal(true);
    }),
    it('symmetric array should return true', () => {
        //Act
        let argument = [1, 2, 2, 1];

        //Arrange
        let result = isSymmetric(argument);

        //Assert
        expect(result).to.equal(true);
    }),
    it('empty array should return true', () => {
        //Act
        let argument = [];

        //Arrange
        let result = isSymmetric(argument);

        //Assert
        expect(result).to.equal(true);
    }),
    it('array with different type elements should return false', () => {
        //Act
        let argument = [1, '1'];

        //Arrange
        let result = isSymmetric(argument);

        //Assert
        expect(result).to.equal(false);
    })
});