--2.
SELECT *
FROM Gyár
WHERE ÉpítésiÉv = 2012;
-- üres halmaz

--4.
DELETE
FROM Alkalmazott
WHERE YEAR(SzületésiDátum) < 1960;
-- Fk hiba

--6.
DELETE
FROM Gyártási_Sor
WHERE GyártásiÁr > 12000 AND ÁHE < 10;
-- üres halmaz

--8.
UPDATE
SET Fizetés = Fizetés + 10000
WHERE YEAR(CURDATE() - SzületésiDátum) > 18;
-- hiba

--10.
SELECT Név, Fizetés
FROM Alkalmazott A INNER JOIN Beosztás B ON A.TAJ_Szám = B.TAJ
WHERE B.Gyár_Név LIKE "Debrecen%";
-- jó

--12.
