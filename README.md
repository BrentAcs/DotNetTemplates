DotNetTemplates

DISCLAIMER: This is very much a Work In Progress.

This Repo is intented to store code and project templates for .Net Core 3.1 and later.

Using ConsoleHosted for example.

Install a Project as a template:
1. In a terminal, navigate to .\DotNetTemplates\Templates\Projects\ConsoleHosted
2. execute: dotnet new --install ./

Create a new Project from template:
1. Navigate to the directory you want your new project in, ex: .\DotNetTemplates\Test
2. dotnet new consolehosted
3. dotnet build
4. dotnet run

3 and 4 are optional.

Uninstall a Project
1. In a terminal, navigate to .\DotNetTemplates\Templates\Projects\ConsoleHosted
2. execute: dotnet new --uninstall ./

To see all install templates:
dotnet new --list

Reference(s):
https://docs.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-item-template