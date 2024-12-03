// See https://aka.ms/new-console-template for more information
using AdventOfCode2024;

var dayOne = new DayOne();

//var dist = await dayOne.CalcDistnaceAsync();

var dist = await dayOne.CalcSimilarityScoreAsync();

Console.WriteLine("Dist: " + dist);
