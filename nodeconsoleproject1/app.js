'use strict';

let arr = ["a", "b", "c"];
let merged = arr.reduce(function (a, b) {
    a.concat(b);
}); // Noncompliant: No return statement, will result in TypeError

console.log('Hello world');

let color = "red";
let count = 3;
let message = `I have ${color ? `${count} ${color}` : count} apples`; // Noncompliant; nested template strings not easy to read