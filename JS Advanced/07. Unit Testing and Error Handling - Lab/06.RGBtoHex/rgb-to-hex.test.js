let { expect } = require('chai');
let rgbToHexColor = require('./rgb-to-hex');

describe('rgbToHexColor', () => {
    it('not integer red returns undefined', () => {
        let red = 'red';
        let green = 1;
        let blue = 4;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('negative red returns undefined', () => {
        let red = -4;
        let green = 1;
        let blue = 4;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('big red returns undefined', () => {
        let red = 3453;
        let green = 1;
        let blue = 4;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('not integer red returns undefined', () => {
        let red = '6';
        let green = 1;
        let blue = 4;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('not integer green returns undefined', () => {
        let red = 4;
        let green = 'green';
        let blue = 4;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('negative green returns undefined', () => {
        let red = 4;
        let green = -41;
        let blue = 4;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('big green returns undefined', () => {
        let red = 14;
        let green = 1;
        let blue = 3143;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('not integer green returns undefined', () => {
        let red = 4;
        let green = '1';
        let blue = 4;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('not integer blue returns undefined', () => {
        let red = 17;
        let green = 1;
        let blue = '4';

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('negative blue returns undefined', () => {
        let red = 4;
        let green = 1;
        let blue = -4;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('big blue returns undefined', () => {
        let red = 3453;
        let green = 1;
        let blue = 43443;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('not integer blue returns undefined', () => {
        let red = 16;
        let green = 1;
        let blue = '6';

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.be.undefined;
    }),
    it('returns the same color if all the conditions are matched', () => {
        let red = 255;
        let green = 153;
        let blue = 153;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal('#FF9999');
    }),
    it('returns wrong color if all the conditions are matched', () => {
        let red = 255;
        let green = 153;
        let blue = 153;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.not.equal('#FF9990');
    }),
    it(`more than 3 parameters returns undefined`, () => {
        expect(rgbToHexColor(0, 0, 0, 0)).to.equals('#000000')
    })
});