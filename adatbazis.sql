CREATE DATABASE Lego_Gyar
USE Lego_Gyar

--Zoli
CREATE TABLE Alalmazott (
    TAJ-szám INT PRIMARY KEY
    Név VARCHAR(30),
    Email VARCHAR(70),
    Fizetés INT,
    SzületésiDátum DATE,
    Telefonszám INT
)

CREATE TABLE Beosztás (
    TAJ int NOT NULL,
    Gyár_név VARCHAR(50) NOT NULL,
    CONSTRAINT FK_Beosztás_alkalmazott FOREIGN KEY (TAJ) REFERENCES Alkalmazott (TAJ-szám),
    CONSTRAINT FK_Beosztás_gyár FOREIGN KEY (Gyár_név) REFERENCES Gyár (Név)
)

CREATE TABLE Gyártási_Sor (
    Gyár_név VARCHAR(50) NOT NULL,
    Szériaszám INT NOT NULL,
    GyártásiÁr INT,
    ÁHE INT,
    CONSTRAINT FK_Beosztás_gyár FOREIGN KEY (Gyár_név) REFERENCES Gyár (Név),
    CONSTRAINT FK_Beosztás_szett FOREIGN KEY (Szériaszám) REFERENCES Szett (Szériaszám)
)

--Bogi