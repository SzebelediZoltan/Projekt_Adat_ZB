SELECT *
FROM Alkalmazott
WHERE Fizetés > 510000;
-- jó

SELECT *
FROM Szett
WHERE Forgalomban = "True"
ORDER BY Név;
-- nincs szett

SELECT Név
FROM Gyár
WHERE ÁHM > 3000000;
-- jó

--------------------------------

DELETE
FROM Gyártási_Sor INNER JOIN Gyár ON Gyártási_Sor.Gyár_név = Gyár.Név
WHERE GyártásiÁr > 12000 AND ÁHM < 10;
-- hiba?!

SELECT *
FROM Szett INNER JOIN Gyártási_Sor ON Szett.Szériaszám = Gyártási_Sor.Szériaszám
WHERE Ár < 12000 AND Gyár_név LIKE "Győr%";
-- nincs szett

---------------------------------

SELECT Alkalmazott.Email
FROM Alkalmazott INNER JOIN Beosztás ON Alkalmazott.TAJ_szám = Beosztás.Taj
WHERE Gyár_név LIKE "Nyíregyház%" AND Telefonszám LIKE "__70%";
-- Nincs is 70es szám

SELECT DISTINCT Szett.nev
FROM Szett INNER JOIN Gyártási_Sor ON Szett.Szériaszám = Gyártási_Sor.Szériaszám
WHERE Kor > 12 AND ÁHE > 500;
-- nincsenek szettek

SELECT Gyár_név
FROM Beosztás INNER JOIN Alkalmazott ON Beosztás.Taj = Alkalmazott.TAJ_szám 
ORDER BY COUNT(Alkalmazott.Kor > 50) DESC
LIMIT 1;
-- hiba