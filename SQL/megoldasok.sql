SELECT *
FROM Alkalmazott
WHERE Fizetés > 510000;

SELECT *
FROM Szett
WHERE Forgalomban = "True"
ORDER BY Név;

SELECT Név
FROM Gyár
WHERE ÁHM > 3000000;

--------------------------------

DELETE
FROM Gyártási_Sor
WHERE GyártásiÁr > 12000 AND ÁHM < 10;

SELECT *
FROM Szett INNER JOIN Gyártási_Sor ON Szett.Szériaszám = Gyártási_Sor.Szériaszám
WHERE Ár < 12000 AND Gyár_név LIKE "Győr%";

---------------------------------

SELECT Alkalmazott.Email
FROM Alkalmazott INNER JOIN Beosztás ON Alkalmazott.TAJ_szám = Beosztás.Taj
WHERE Gyár_név LIKE "Nyíregyház%" AND Telefonszám LIKE "__70%";

SELECT DISTINCT Szett.nev
FROM Szett INNER JOIN Gyártási_Sor ON Szett.Szériaszám = Gyártási_Sor.Szériaszám
WHERE Kor > 12 AND ÁHE > 500;

SELECT Gyár_név
FROM Beosztás INNER JOIN Alkalmazott ON Beosztás.Taj = Alkalmazott.TAJ_szám 
ORDER BY COUNT(Alkalmazott.Kor > 50) DESC
LIMIT 1;