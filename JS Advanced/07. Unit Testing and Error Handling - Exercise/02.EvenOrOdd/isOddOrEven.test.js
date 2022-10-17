const { expect } = require('chai');
const isOddOrEven = require('./isOddOrEven');

describe('isOddOrEven', () => {
    it('input is not a string returns undifined', () => {
        let string = 213;
        
        let result = isOddOrEven(string);

        expect(result).to.be.undefined;
    }),
    it('even length string returns even', () => {
        let string = '123456';

        let result = isOddOrEven(string);

        expect(result).to.equal('even');
    }),
    it('even length string returns odd', () => {
        let string = '12345';

        let result = isOddOrEven(string);

        expect(result).to.equal('odd');
    })
});