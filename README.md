# Готово
В приложении есть все требуемые по ТЗ вьюшки.
![](README%20src/Manager2Clients-View.png)
Вьюшки реализованы в виде списков в отдельных вкладках.

Есть скрипт `CreateSTPDatabase.sql`, который создает базу данных и нужные таблицы:
```
USE master
GO
IF NOT EXISTS (
	SELECT name
	FROM sys.databases
	WHERE name = N'STPDatabase'
	)
	CREATE DATABASE [STPDatabase]
GO

USE STPDatabase
GO
IF NOT EXISTS (
	SELECT name
	FROM sys.tables
	WHERE name = 'Managers'
	)
	CREATE TABLE Managers (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		FullName VARCHAR(128) NOT NULL,
	)
GO
IF NOT EXISTS (
	SELECT name
	FROM sys.tables
	WHERE name = 'Clients'
	)
	CREATE TABLE Clients (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		FullName VARCHAR(128) NOT NULL,
		Status INT NOT NULL,
	)
GO
IF NOT EXISTS (
	SELECT name
	FROM sys.tables
	WHERE name = 'Products'
	)
	CREATE TABLE Products (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		FullName VARCHAR(128) NOT NULL,
		Price INT NOT NULL,
		Type INT NOT NULL,
		ExpirationDate DATE NOT NULL,
	)
GO
```

Подключена БД на локальном сервере MSSQL, для которой можно создавать менеджеров, клиентов и продукты.
Эти элементы можно удалять.

Взаимодействие с БД реализовано через интерфейс, что позволяет использовать любую реализацию:
``` csharp
public partial class App : Application
{
    private readonly IDataBase _dataBase;

    // ...

    public App()
    {
        _dataBase = new SqlDataBase();

        // ...
    }

    // App logic
    // ...
}
```

Есть вьюшки для редактирования отдельных элементов БД.

# Нужно доделать
- Нет возможности выводить списки-отношения. Необходимо дополнить поля в моделях менеджеров, клиентов и продуктов и написать SQL-запросы для формирования таблиц.
- Нет возможности редактировать существующие элементы в БД. Есть заскриптованная импровизированная БД в коде, в которой реализован функионал редактирования, т.е. необходимые вьюшки есть.
- В моделях Manager, Client, Product есть сеттеры, которые нарушают принципы паттерна MVVM, но в начале были удобны, чтобы не создавать много лишнего кода. При полном переходе на работу с MSSQL нужно убрать эти сеттеры.
- Скрипт для создания БД и таблиц нужно доработать, так как сейчас там не хватает полей, например, в клиенте ссылки на своего менеджера.
- В БД не записываются слова на кириллице, нужно исправить.

Модульные тесты реализованы в отдельном решении ProjectMateAppTests:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0-windows</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.6.0" />
    <PackageReference Include="MSTest.TestAdapter" Version="3.0.4" />
    <PackageReference Include="MSTest.TestFramework" Version="3.0.4" />
    <PackageReference Include="coverlet.collector" Version="6.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\ProjectMateApp\ProjectMateApp.csproj" />
  </ItemGroup>

</Project>
```

Пример модульных тестов для одного из компонентов проекта:
``` csharp
[TestClass()]
    public class NameValidatorTests
    {
        [TestMethod()]
        [DataRow("John Kavalzky")]
        [DataRow("Michael Sera")]
        [DataRow("Robert Downey Jr.")]
        [DataRow("Robert Downey-junior")]
        [DataRow("Александр Пушкин Сергеевич")]
        [DataRow("Иван Васильевич")]
        [DataRow("Иван Васильевич-Грозный")]
        public void Validate_GoodName(string name)
        {
            NameValidator.Validate(name);
        }

        [TestMethod()]
        [DataRow("1John Kavalzky")]
        [DataRow("123John Kavalzky")]
        [DataRow("John5 Kavalzky")]
        [DataRow("John 8 Kavalzky")]
        [DataRow("John 9Kavalzky")]
        [DataRow("John Kavalzky0")]
        [DataRow("1Александр Пушкин Сергеевич")]
        [DataRow("123Александр Пушкин Сергеевич")]
        [DataRow("Александр 0 Пушкин 6 Сергеевич")]
        [DataRow("Александр1 3Пушкин6 Сергеевич")]
        [DataRow("Александр Пу556шкин Сергеевич")]
        public void Validate_NumbersName(string name)
        {
            Assert.ThrowsException<NameContainsNumbersException>(() =>
            {
                NameValidator.Validate(name);
            });
        }
    }
```

- У модульных тестов низкий охват, нужно реализовать тесты для большего числа классов и методов проекта.
- Объективно неудобная структура директорий. В каждой папке должны быть папки по назначению скриптов и xaml. Рефактор требует большого вклада сил, т.к. xaml файлы авторефактором не меняют свои неймспейсы.