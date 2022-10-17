const { expect } = require('chai');
const lookupChar = require('./charLookUp');

describe('lookupChar', () => {
    it('first parameter is not a string should return undefined', () => {
        let string = 13;
        let index = 8;

        let char = lookupChar(string, index);

        expect(char).to.be.undefined;
    }), 
    it('second parameter is string should return undefined', () => {
        let string = "asd";
        let index = 'b';

        let char = lookupChar(string, index);

        expect(char).to.be.undefined;
    }),
    it('second parameter is not an integer should return undefined', () => {
        let string = "asd";
        let index = 13.6;

        let char = lookupChar(string, index);

        expect(char).to.be.undefined;
    }),
    it('negative index should return incorrect index', () => {
        let string = "asd";
        let index = -6;

        let char = lookupChar(string, index);

        expect(char).to.equal("Incorrect index");
    }),
    it('too big index should return incorrect index', () => {
        let string = "asd";
        let index = 176;

        let char = lookupChar(string, index);

        expect(char).to.equal("Incorrect index");
    }),
    it('correct index should return correct char', () => {
        let string = "asd";
        let index = 1;

        let char = lookupChar(string, index);

        expect(char).to.equal("s");
    })
});
