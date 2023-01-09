# ASP.NET-Core-MVC-Entity-Framework

<img src="https://github.com/ilkersatur/ASP.NET-Core-MVC-Entity-Framework/blob/main/ef-core-6.0.12.PNG?raw=true">

<img src="https://github.com/ilkersatur/ASP.NET-Core-MVC-Entity-Framework/blob/main/ef-sql.PNG?raw=true">


"Server=DESKTOP-DH0LVGV\MSSQLSERVER2014;Database=Hastane;User Id= sa; Password=1230;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

CREATE TABLE Tani(
					TaniID int IDENTITY PRIMARY KEY,
					TaniAdi varchar(50)
					)
CREATE TABLE Tedavi(
					TedaviID int IDENTITY PRIMARY KEY,
					TedaviAdi varchar(50)
					)
CREATE TABLE UzmanlikAlani(
					UzmanlikAlaniID int IDENTITY PRIMARY KEY,
					UzmanlikAlanAdi varchar(50)
					)
CREATE TABLE Laborant(
					LaborantID int IDENTITY PRIMARY KEY
					)
CREATE TABLE Hasta(
					HastaID int IDENTITY PRIMARY KEY
					)

CREATE TABLE Doktor(
		DoktorID int PRIMARY KEY IDENTITY,
		UzmanlikAlaniID int REFERENCES UzmanlikAlani(UzmanlikAlaniID)
		)
CREATE TABLE Rapor(
		RaporID int PRIMARY KEY IDENTITY,
		HastaID int REFERENCES Hasta(HastaID),
		DoktorID int REFERENCES Doktor(DoktorID),
		TaniID int REFERENCES Tani(TaniID),
		TedaviID int REFERENCES Tedavi(TedaviID),
		Rapor varchar(50)
		)

CREATE TABLE KanTest(
		KanTestID int PRIMARY KEY IDENTITY,
		LaborantID int REFERENCES Laborant(LaborantID),
		HastaID int REFERENCES Hasta(HastaID)
		)
