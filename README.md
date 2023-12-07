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

# How to run the project

To build the project with dotnet cli, use the command :

```bash
dotnet build
```

or use this command to build the project in a specific directory :

```bash
dotnet build --output ./build_output
```

## Usage

By default, the translator will translate text from the standard input and translate to the selected language.

Here are all the supported languages :

    BG - Bulgarian
    CS - Czech
    DA - Danish
    DE - German
    EL - Greek
    EN - English (unspecified variant for backward compatibility; please select EN-GB or EN-US instead)
    EN-GB - English (British)
    EN-US - English (American)
    ES - Spanish
    ET - Estonian
    FI - Finnish
    FR - French
    HU - Hungarian
    ID - Indonesian
    IT - Italian
    JA - Japanese
    KO - Korean
    LT - Lithuanian
    LV - Latvian
    NB - Norwegian (Bokmål)
    NL - Dutch
    PL - Polish
    PT - Portuguese (unspecified variant for backward compatibility; please select PT-BR or PT-PT instead)
    PT-BR - Portuguese (Brazilian)
    PT-PT - Portuguese (all Portuguese varieties excluding Brazilian Portuguese)
    RO - Romanian
    RU - Russian
    SK - Slovak
    SL - Slovenian
    SV - Swedish
    TR - Turkish
    UK - Ukrainian
    ZH - Chinese (simplified)

Here is how to translate a text to french :

```bash
dotnet run FR
```
```text
Target language set to : FR
Hello world !

Bonjour le monde !
```

You can also translate a document with the -d option

The supported files are : docx, pptx, pdf, html, htm, txt and xlf.

```bash
dotnet run FR -d inputDocument.pdf outputDocument.pdf
```
