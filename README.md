# ShopsRUs
ShopsRUs is an existing retail outlet. They would like to provide discount to their customers on all their web/mobile platforms.
It is built with ASP.NET Core 5.0 (API).

Build (Development)
<br> &#8226; To run, you need .net5.0 sdk (or runtime) installed on your machine. In the project root folder, run the command dotnet run
<br>&#8226; This should restore all packages and install the necessary nuget packages. Browse the application via https://localhost:5001/

Troubleshooting
<br> &#8226; Depending on the current setup on your machine, you might run into some 'Microsoft PackageDependencyResolution.targets' errors. Typically, you require MSBuild 16.8 and NuGet version 5.8 (or above) to run .net5.0 applications. The quickest resolution route is simply to install Visual Studio 19 (Version 16.8) and all will be fine.

IIS Express via Visual Studio
<br> &#8226; If you are opening the project on visual studio and your launch profile is IIS Express. It is currently set to http://localhost:60028 and you can view the swagger page on http://localhost:60028/swagger for easy access to the endpoints.

Deploy (Production)
<br>&#8226; To publish and run this application in production, run the following command in your  project root folder dotnet publish -c Release.
<br>&#8226; Your deployed application(.exe) is available in the location: ~/bin/release/net5.0/publish folder. Run it and navigate to https://localhost:5001/.
