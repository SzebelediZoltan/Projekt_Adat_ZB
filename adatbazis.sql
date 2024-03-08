--Zoli

--Bogi

--Gyár
CREATE TABLE Gyar(
    Név varchar(50) PRIMARY KEY,
    ÁHM int,
    ÉpítésiÉV int,
    Település varchar(25),
    Bevétel int
);

-- Szett
CREATE TABLE Szett(
    Szériaszám int PRIMARY KEY,
    KiadásiÉv int,
    Név varchar(50),
    Ár int,
    Forgalomban bool,
    DB int,
    Téma varchar(50),
    Kor int
);