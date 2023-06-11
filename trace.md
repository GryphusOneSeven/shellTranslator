# Explaining how I made this project and how it works

This command creates a template of a C# Console Application.
```bash
dotnet new console --framework net7.0
```

The following files are created
```text
Program.cs
*projectname*.csproj
```

Program.cs contains the main function.
The .csproj file is the project configuration file.
We can link dependencies to the project by adding them in this file.

DeepL offers official client libraries for his translator API.
I chose to use the dotnet client library.
With a DeepL API Free account you can translate up to 500,000 characters/month for free.

This command add the library to the project.
```bash
dotnet add package DeepL.net
```
Theses lines are added to the .csproj file
```xml
    <ItemGroup>
        <PackageReference Include="DeepL.net" Version="1.7.1" />
    </ItemGroup>
```
All entities in the DeepL .NET library are in the DeepL namespace
```C#
using DeepL;
```