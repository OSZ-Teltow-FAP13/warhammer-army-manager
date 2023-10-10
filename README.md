<div align="center">
  <a href="https://github.com/OSZ-Teltow-FAP13/warhammer-army-manager">
    <img src="https://media.maximilian-mewes.de/project/wam/warhammer-army-manager.png" alt="Logo" height="180">
  </a>

  <h3 align="center"> Project - WAM </h3>

  <p align="center">
    Manage your troops. Create Army lists. Attack!
    <br />
    <br />
    <a href="https://www.games-workshop.com"> Website </a>
    ·
    <a href="https://github.com/OSZ-Teltow-FAP13/warhammer-army-manager/issues">Report Bug</a>
    ·
    <a href="https://github.com/OSZ-Teltow-FAP13/warhammer-army-manager/issues">Request Feature</a>
    <br />
    <br />
    von
    <br />
    Marc B. &nbsp;&nbsp; Marian B. &nbsp;&nbsp; Maximilian M.
  </p>
</div>

---

## naming conventions

```txt
ProjectTag => WAM [W]arhammer [A]rmy [M]anager
```

### feature branches 🌴

```txt
#ProjectTag-IssueNo_IssueTitle
Examples:
- #WAM-4_Mockups_erstellen
- #WAM-69_Finale_testungen_mit_unit
```

---

# Projektantrag

## Titel der Projektarbeit
   
Erstellung einer App zum Verwalten von Warhammer Armee Listen (Warhammer Army Manager)

## Detalierte Projektbeschreibung

**Ausgangssituation:**

Um eine Armeeliste zu schreiben müssen mit Hilfe des Armeebuches die Punktkosten genau auf Papier geschrieben werden und auch sämtliche Regelungen für das Spielsystem eingehalten werden, damit Punktkosten nicht überschritten werden oder Spieleinheiten nicht doppelt verwendet werden können.

**Auftraggeber/Kunde:**

Pascal Bonneß

**Produkt:**

Software (Desktop Anwendung mit GUI) zur Erstellung und Speicherung von Warhammer Armeelisten und Validierung für offizielle Turniere.

**Projektziele:**

Die App soll in der Lage sein, verschieden viele Listen zu speichern zu allen Völkern die es gibt sowie eine Bildliche Darstellung der Modelle bieten und die erstellte Liste als Ein Turniergültiges PDF Dokument zusammenzufassen.

**Nutzen:**

Die schnelle und übersichtliche Darstellung der einzelnen Armeen soll dem Nutzer ermöglichen, seine Liste schneller und effizienter zu erstellen, so das keine Fehlerhaften / nicht legalen Listen mehr zustande kommen.
Eigene Leistungen:

| Mitglied   	|       Aufgabe Nr. 1      	|         Aufgabe Nr. 2        	|
|------------	|:------------------------:	|:----------------------------:	|
| Marc       	| Erstellung der Datenbank 	| Erstellung von Foto Material 	|
| Marian     	| Frontend / Ui+Ux         	| Benutzerschnittstelle        	|
| Maximilian 	| Backend / Logik          	| Erstellung der PDF Dateien   	|


**Schnittstellenbeschreibung:**

C#/Programm – Datenbank; C#/Programm – GUI
Verwendete Hardware: PC mit CPU Ryzen 5 3500 / 3,4 GHz, Arbeitsspeicher 16 GB
Verwendete Software: Betriebssystem Windows 10  64 / Bit; Datenbanksystem (MySQL), C# IDE (Visual Studio)

## Projektumfeld

Es handelt sich um einen Kundenauftrag. Nutzer der zu entwickelnden Anwendung sind Warhammer Hobby Spieler. 

## Projektphasen

#### 1. Analyse: (5 Stunden)
 - Erfassung und Modellierung des Istzustandes
 - Aufdecken von Schwachstellen
 - Erfassung und Analyse der Anforderungen
 - Vorgehensmodell bestimmen und Ablaufplan erstellen
 - Design: statische Sachverhalt im Anwendungsfalldiagramm, dynamischer Sachverhalt im Ereignisgesteuerten Prozesskettendiagramm

#### 2. Festlegung der Programmspezifikation: (2 Stunden)
  - MUSS-Kriterien (Übersicht über alle Modelle aus Armeebüchern, Armeeliste erfassen, speichern und zur Verfügung stellen, Konvertierung in zulässiges Format) 
  - KANN-Kriterien (Zusätzlich zu der schriftlichen Übersicht der Modelle kann auch eine 3D Grafik gezeigt werden) 

#### 3. Modellierung des Programmentwurfs: (5 Stunden)
 - Klassendiagramm
 - ERD, Normalisierter Tabellenentwurf
 - MockUp Modellierung

#### 4. Implementierung (25 Stunden)
 - Programmierung des Programms und der Datenbank
 - Erstellung der Benutzeroberfläche

#### 5. Programmtest (3 Stunden)
 - funktionales Testverfahren

#### 6. IT-Sicherheit (2 Stunden)
 - Umsetzung der MUSS Basisanforderung im IT-Grundschutzkompendium APP.4.3.A9 Relationale Datenbanken – Datensicherung eines Datenbanksystems,
 - Umsetzung der MUSS Basisanforderungen im IT-Grundschutzkompendium APP.7.A3 Entwicklung von Individualsoftware – Festlegung der Sicherheitsfunktionen zur System-Integration

#### 7. Softwarequalität (3 Stunden)
- Vorrangig Umsetzung der Qualitätseigenschaften Korrektheit und Benutzerfreundlichkeit

#### 9. Erstellung der Projektdokumentation (5 Stunden)
- Dokumentation zur Projektarbeit
-	Projektbericht,
-	Quellcode (Auszug),
-	Testprotokoll,
-	Aufbau der Benutzeroberfläche,
-	Anwenderdokumentation

##### Gesamt Stunden: 50 Stunden
