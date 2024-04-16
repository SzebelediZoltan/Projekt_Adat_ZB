--2.
SELECT *
FROM Gyar
WHERE EpitesiEv = 2012

--4.
DELETE *
FROM Alkalmazottak
WHERE YEAR(SzuletesiDatum) < 1960

--6.
DELETE
FROM GyartasiSor
WHERE GyartasiAr > 12000 AND AHE < 10

--8.
UPDATE
SET Fizetes = Fizetes + 10000
WHERE YEAR(CURDATE() - SzuletesiDatum) > 18

--10.
SELECT Nev, Fizetes
FROM Alkalmazottak A INNER JOIN Beosztas B ON A.TAJ_Szám = B.TAJ_Szám
WHERE B.Gyár_Név LIKE "Debrecen%"

--12.
