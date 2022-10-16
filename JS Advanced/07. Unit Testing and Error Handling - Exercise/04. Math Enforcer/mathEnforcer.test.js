let { expect } = require("chai");
let mathEnforcer = require("./mathEnforcer");

describe("mathEnforcer", () => {
  it("addFive with invalid parameter should return undefined", () => {
    let number = "s";

    let result = mathEnforcer.addFive(number);

    expect(result).to.be.undefined;
  }),
    it("addFive with valid positive parameter should return the number + 5", () => {
      let number = 3;

      let result = mathEnforcer.addFive(number);

      expect(result).to.equal(8);
    }),
    it("addFive with valid negative parameter should return the number + 5", () => {
      let number = -11;

      let result = mathEnforcer.addFive(number);

      expect(result).to.equal(-6);
    }),
    it("addFive with valid floating parameter should return the number + 5", () => {
      let number = 0.2;

      let result = mathEnforcer.addFive(number);

      expect(result).to.be.closeTo(5.2, 0.01);
    }),
    it("subtractTen with invalid parameter should return undefined", () => {
      let number = "3";

      let result = mathEnforcer.subtractTen(number);

      expect(result).to.be.undefined;
    }),
    it("subtractTen with valid positive parameter should return the number - 10", () => {
      let number = 18;

      let result = mathEnforcer.subtractTen(number);

      expect(result).to.equal(8);
    }),
    it("subtractTen with valid negative parameter should return the number - 10", () => {
      let number = -4;

      let result = mathEnforcer.subtractTen(number);

      expect(result).to.equal(-14);
    }),
    it("subtractTen with valid floating parameter should return the number - 10", () => {
      let number = 10.5;

      let result = mathEnforcer.subtractTen(number);

      expect(result).to.be.closeTo(0.5, 0.01);
    }),
    it("sum with invalid parameter1 should return undefined", () => {
      let number1 = "3";
      let number2 = 7;

      let result = mathEnforcer.sum(number1, number2);

      expect(result).to.be.undefined;
    }),
    it("sum with invalid parameter2 should return undefined", () => {
      let number1 = 3;
      let number2 = "6";

      let result = mathEnforcer.sum(number1, number2);

      expect(result).to.be.undefined;
    }),
    it("sum with valid positive parameters should return their sum", () => {
      let number1 = 3;
      let number2 = 5;

      let result = mathEnforcer.sum(number1, number2);

      expect(result).to.equal(8);
    }),
    it("sum with valid negative parameters should return their sum", () => {
      let number1 = -3;
      let number2 = -5;

      let result = mathEnforcer.sum(number1, number2);

      expect(result).to.equal(-8);
    }),
    it("sum with valid floating parameters should return their sum", () => {
      let number1 = 3.8;
      let number2 = 2.1;

      let result = mathEnforcer.sum(number1, number2);

      expect(result).to.be.closeTo(5.9, 0.01);
    });
});
