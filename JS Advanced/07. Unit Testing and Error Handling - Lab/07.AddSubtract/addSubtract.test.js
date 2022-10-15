const { expect } = require('chai');
const createCalculator = require('./addSubtract');

let calculator = createCalculator();

describe('addSubtract', () => {
    it('calculator is object', () => {
        expect(typeof calculator).to.equal('object');
    }),
    it('calculator has metod add', () => {
        expect(calculator.add).to.not.be.undefined;
    }),
    it('calculator has metod subtract', () => {
        expect(calculator.subtract).to.not.be.undefined;
    }),
    it('calculator has metod get', () => {
        expect(calculator.get).to.not.be.undefined;
    }),
    it('calculator sum cant be modified', () => {
        expect(calculator.value).to.be.undefined;
    }),
    it('add method works correctly', () => {
        let calculator1 = createCalculator();

        calculator1.add('2');

        expect(calculator1.get()).to.equal(2);
    }),
    it('subtract method works correctly', () => {
        let calculator1 = createCalculator();

        calculator1.add('2');
        calculator1.subtract('1');

        expect(calculator1.get()).to.equal(1);
    })
});