<h1 align = "center">
<strong>List Picker</strong>
</h1>

## Description
This package provides an easy way to randomly remove and return elements from an IEnumerable<T> implementation, such as a List<T> object.

## Languages & Technologies

* [C# & .NET Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)

* [Visual Studio 2019 - Community Edition](https://visualstudio.microsoft.com/)

## Usage

* Instantiate a class of type  ```ListPicker```
* Access the method ``` PickElements ``` from the instatiated class
* Pass, as parameters, an instance of any implementation of ``` IEnumerable <T>``` such as a ``` List<T> ```, pass the number of elements you want pick from the list and, optionally, pass a ``` Func<T, bool> ``` that represents a condition to pick an element.

See the [Samples Project](https://github.com/Igor03/list-picker/tree/main/src/JIgor.Projects.ListPicker.Samples) in the repository files for examples.

## Test Coverage

In the folder [TestResults](https://github.com/Igor03/list-picker/tree/main/TestResults) we have a detailed report with the unit tests' code coverage

## Nuget
This package can also be accessed through Nuget Package Manager by the nome of [JIgor.Projects.ListPicker](https://www.nuget.org/packages/JIgor.Projects.ListPicker/1.0.0).

Through CLI

 ``` Install-Package JIgor.Projects.ListPicker -Version 1.0.0```
