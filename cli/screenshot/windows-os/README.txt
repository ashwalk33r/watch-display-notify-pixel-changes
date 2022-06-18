Download and install
To start building .NET apps, download and install the .NET SDK (Software Development Kit).
https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/install

Check everything installed correctly
Once you've installed, open a new command prompt and run the following command:

Command prompt:
dotnet

-

PS

Add-Type -AssemblyName System.Windows.Forms
[System.Windows.Forms.SystemInformation]::VirtualScreen

-

To run:
cd MyApp
dotnet run

-

using System.Windows.Forms; // requires a reference to this assembly

-

using
https://developer.microsoft.com/pl-pl/windows/downloads/windows-sdk/


-

nuget source, add:
https://api.nuget.org/v3/index.json

in nuget console, run:
Install-Package System.Drawing.Common -Version 4.5.0-preview2-26406-04

-

release:
dotnet build
