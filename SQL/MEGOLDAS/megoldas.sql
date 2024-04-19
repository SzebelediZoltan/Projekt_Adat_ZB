--1:
SELECT Név, Fizetés
FROM Alkalmazott;

--2:
SELECT Név, Település
FROM Gyár;

--3:
SELECT Név, Ár
FROM Szett
WHERE Forgalomban = TRUE;

--4:
SELECT *
FROM Alkalmazott
WHERE Fizetés > 2000;

--5:
SELECT Név, Téma
FROM Szett
WHERE Ár BETWEEN 10000 AND 20000;

--6:
SELECT *
FROM Alkalmazott
WHERE SzületésiDátum > '2000-01-01';

--7:
SELECT Név
FROM Gyár
WHERE Bevétel / 12 > 5000000;

--8:
SELECT *
FROM Alkalmazott INNER JOIN Beosztás ON Alkalmazott.TAJ_szam = Beosztás.TAJ
WHERE Gyár_név IN (SELECT Név FROM Gyár WHERE Település = 'Budapest');

--9:
SELECT *
FROM Szett
WHERE DB > 1000;

--10:
SELECT *
FROM Gyártási_Sor
WHERE Gyár_név = 'LEGO' AND GyártásiÁr < 5000;

--11:
SELECT Alkalmazott.Név, Gyár.Név AS Gyár_neve
FROM Alkalmazott
INNER JOIN Beosztás ON Alkalmazott.TAJ_szám = Beosztás.TAJ
INNER JOIN Gyár ON Beosztás.Gyár_név = Gyár.Név
WHERE Alkalmazott.Fizetés > (Gyár.Bevétel / 12);

--12:
SELECT * 
FROM Gyártási_Sor 
WHERE Szériaszám IN (SELECT Szériaszám FROM Szett WHERE Forgalomban = FALSE);

--13:
SELECT Gyár.Név AS Gyár_neve, Szett.Név AS Szett_neve
FROM Gyár
INNER JOIN Gyártási_Sor ON Gyár.Név = Gyártási_Sor.Gyár_név
INNER JOIN Szett ON Gyártási_Sor.Szériaszám = Szett.Szériaszám
WHERE Szett.Kor < 10;

--14:
SELECT Gyár.Név AS Gyár_neve, AVG(GyártásiÁr) AS Átlagos_gyártási_ár
FROM Gyár
INNER JOIN Gyártási_Sor ON Gyár.Név = Gyártási_Sor.Gyár_név
GROUP BY Gyár.Név
HAVING AVG(GyártásiÁr) > (SELECT AVG(Ár) FROM Szett);

--15:
SELECT *
FROM Alkalmazott
WHERE TAJ_szám NOT IN (SELECT TAJ FROM Beosztás);