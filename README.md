# Electronic Color Code Calculator

Note:  changed return type of IOhmValueCalculator.CalculateOhmValue to nullable decimal to allow:
1) null when unable to calculate (i.e bad input or missing input)
2) decimal values for decimal multipliers
3) values larger than int.MaxValue

Prerequisites:
1) Windows 7 or Windows 10
2) .Net Core 2.0
3) Visual Studio 2017 with latest updates

To run:
1) Download or clone project -- master branch
2) Open ElectronicColorCodeCalculator.sln in Visual Studio 2017
3) Restore NuGet packages for solution
4) Clean & rebuild Solution
5) Set Startup Project to ElectronicColorCodeCalculator.Mvc
6) Run & Test
