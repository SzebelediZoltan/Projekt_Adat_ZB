CREATE DATABASE Lego_Gyar;
USE Lego_Gyar;

CREATE TABLE Alkalmazott (
    TAJ_szam INT PRIMARY KEY,
    Név VARCHAR(30),
    Email VARCHAR(70),
    Fizetés INT,
    SzületésiDátum DATE,
    Telefonszám VARCHAR(50)
);

CREATE TABLE Gyár(
    Név varchar(50) PRIMARY KEY,
    ÁHM int,
    ÉpítésiÉV int,
    Település varchar(25),
    Bevétel int
);

CREATE TABLE Szett(
    Szériaszám int PRIMARY KEY,
    KiadásiÉv int,
    Név varchar(50),
    Ár int,
    Forgalomban boolean,
    DB int,
    Téma varchar(50),
    Kor int
);

CREATE TABLE Beosztás (
    TAJ int,
    Gyár_név VARCHAR(50),
    CONSTRAINT FK_Beosztás_alkalmazott FOREIGN KEY (TAJ) REFERENCES Alkalmazott (TAJ_szam),
    CONSTRAINT FK_Beosztás_gyár FOREIGN KEY (Gyár_név) REFERENCES Gyár (Név)
);

CREATE TABLE Gyártási_Sor (
    Gyár_név VARCHAR(50),
    Szériaszám INT,
    GyártásiÁr INT,
    ÁHE INT,
    CONSTRAINT FK_Beosztás_gyár2 FOREIGN KEY (Gyár_név) REFERENCES Gyár (Név),
    CONSTRAINT FK_Beosztás_szett FOREIGN KEY (Szériaszám) REFERENCES Szett (Szériaszám)
);

