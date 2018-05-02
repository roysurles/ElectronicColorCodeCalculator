# Electronic Color Code Calculator

Note:  changed return type of IOhmValueCalculator.CalculateOhmValue to nullable decimal to allow:
1) null when unable to calculate (i.e bad input)
2) decimal values for decimal multipliers
3) values larger than int.MaxValue

Pre-Reqs.:
1) .net core 2.0
2) Visual Studio 2017 with latest updates

To run:
1) Download or clone project
2) Open ElectronicColorCodeCalculator.sln
3) Restore NuGet packages for solution
4) Clean & rebuild Solution
5) Set Startup Project to ElectronicColorCodeCalculator.Mvc
6) Run & Test
