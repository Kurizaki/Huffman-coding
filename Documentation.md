# Projekt-Dokumentation

Salma Tanner & Keanu Koelewijn

| Datum      | Version | Zusammenfassung                                                                     |
| ---------- | ------- | ----------------------------------------------------------------------------------- |
| 01.03.2024 | 0.0.1   | Erstellen des Projektes, Projektdokumentation, Informieren/Planen                   |
| 08.03.2024 | 0.0.2   | Fertigstellen der Planung, Aufteilen des Projektes, wichtige Entscheidungen treffen |
| 15.03.2024 | 0.0.3   | Beginn mit Realisieren des Projektes                                                |
| 22.03.2024 | 0.0.4   | Realisieren fortsetzen                                                              |
| 05.04.2024 | 0.0.5   | Realisieren abschliessen                                                            |
| 26.04.2024 | 0.0.6   | Portfolioeintrag erstellen / Projekt abschliessen                                   |

## 1 Informieren

### 1.1 Ihr Projekt

In diesem Projekt erstellen wir eine Klassenbibliothek in der Dateien mittels der Huffman-Codierungs prinzip komprimiert und dekomprimiert, Diese Bibliothek verwenden wir in einer WPF Applikation um zu demonstrieren wie die Bibliothek funktioniert.

### 1.2 User Stories

| US-№ | Verbindlichkeit | Typ        | Beschreibung                                                                                                                                                                                                         |
| ---- | --------------- | ---------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1    | Muss            | Funktional | Als ein Entwickler möchte ich erfolgreich ein C# Visual Studio Projekt erstellen, mit einer Library und einer WPF Applikation und dieses auf Github verlinken, damit alle Entwickler parallel daran arbeiten können. |
| 2    | Muss            | Funktional | Als ein Entwickler möchte ich in meiner Library eine Klasse zur Komprimierung codieren, damit der Benutzer Daten komprimieren kann.                                                                                  |
| 3    | Muss            | Funktional | Als Entwickler möchte ich in meiner Library eine Klasse zur Dekomprimierung codieren, damit der Benutzer Daten dekomprimieren kann.                                                                                  |
| 4    | Muss            | Funktional | Als ein Entwickler möchte ich die Huffmann-Tabelle für die De- und Komprimierung erstellen, damit die Baumstruktur erfolgreich erstellt werden kann.                                                                 |
| 5    | Muss            | Funktional | Als Entwickler möchte ich aus den erhaltenen Daten eine Huffman-Baumstruktur codieren, damit die De- und Komprimierung erfolgreich durchgeführt werden kann.                                                         |
| 6    | Muss            | Funktional | Als Enwtickler möchte ich die Library in meiner WPF Applikation erfolgreich einbinden können, damit ich das De- und Komprimierung Verfahren benutzerfreundlich darstellen kann.                                      |
| 7    | Muss            | Funktional | Als ein Benutzer möchte ich in der Applikation auswählen, ob ich De- oder Komprimieren möchte, damit ich meine Daten verarbeiten kann.                                                                               |
| 8    | Muss            | Funktional | Als ein Benutzer möchte ich eine .txt Datei auswählen oder Zeichenabfolge (Buchstaben) eingeben können, damit diese dann de/komprimiert werden kann.                                                                 |
| 9    | Muss            | Funktional | Als Entwickler möchte ich dem Benutzer am Ende die verarbeiteten Daten als .txt File ausgeben, damit dies dann gespeichert werden kann.                                                                              |



### 1.3 Testfälle

| TC-№ | Beschreibung                                                                                                                                             | Vorgehen                                                                                                                                                                    | Erwartetes Ergebnis                                                                               |
| ---- | -------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| 1.1  | Überprüft, ob eine WPF-Applikation mit einer Library erfolgreich ertsellt wurde und ob diese im Github Repository verlinkt wurde.                        | -Projekt in Visual Studio öffnen<br/>-Im Projektmappenexplorer überprüfen, ob Library vorhanden ist<br/>-Github Repository öffnen und überprüfen, ob Projekt verlinkt wurde | Projekt+Repository wurden erstellt und für alle Mitglieder im Repository erfolgreich verlinkt.    |
| 2.1  | Überprüft, ob in der Library eine Klasse zur Komprimierung codiert wurde.                                                                                | -Projekt in Visual Studio öffnen<br/>-Library aufrufen<br/>-Klasse aufrufen<br/>-Code Logik überprüfen                                                                      | Klasse zur Komprimierung wurde erfolgreich erstellt und Logik implementiert.                      |
| 3.1  | Überprüft, ob in der Library eine Klasse zur Dekomprimierung codiert wurde.                                                                              | -Projekt in Visual Studio öffnen<br/>-Library aufrufen<br/>-Klasse aufrufen<br/>-Code Logik überprüfen                                                                      | Klasse zur Dekomprimierung wurde erfolgreich erstellt und Logik implementiert.                    |
| 4.1  | Überprüft, ob in der Library erfolgreich eine Tabelle mit den gegebenen Daten erstellt wurde, damit die Huffmann-Baumstruktur implementiert werden kann. | -Projekt in Visual Studio öffnen<br/>-Library aufrufen<br/>-Methode zur Tabellenerstellung finden<br/>-Code Logik überprüfen                                                | Tabelle zur Huffmann-Baumstruktur wird erfolgreich erstellt beim eingeben von Daten.              |
| 5.1  | Überprüft, ob erfolgreich eine Huffmann-Baumstruktur implementiert wurde.                                                                                | -Projekt in Visual Studio öffnen<br/>                                                                                                                                       | Huffmann-Baumstruktur wird erfolgreich erstellt, sobald Daten eingegeben werden.                  |
| 6.1  | Überprüft, ob die Library erfolgreich in der WPF-Applikation eingebunden werden konnte.                                                                  | -Projekt in Visual Studio öffnen<br/>                                                                                                                                       | Library wurde erfolgreich und funktionsfähig in die Applikation eingebunden.                      |
| 7.1  | Überprüft, ob dem Benutzer in der Applikation die Möglichkeit zur Auswahl zwischen De-/Komprimierung gegeben wird.                                       |                                                                                                                                                                             | Benutzer hat bei Benutzen der Applikation die Möglichkeit, zwischen De-/Komprimieren auszuwählen. |
| 8.1  | Überprüft, ob der Benutzer die Möglichkeit hat, eine .txt Datei oder Zeichenabfolge eingeben kann, um diese dann de-/komplimieren zu lassen.             |                                                                                                                                                                             | Benutzer kann als verarbeitbare Daten Zeichenabfolgen/.txt Dateien einreichen.                    |
| 9.1  | Überprüft, ob der Benutzer die Daten am Ende verarbeitet als .txt File zurückbekommt, um sie zu speichern.                                               |                                                                                                                                                 | Applikation gibt am Ende ein .txt FIle aus, welches abgespeichert werden kann.                    |



### 1.4 Diagramme

✍️ Hier können Sie PAPs, Use Case- und Gantt-Diagramme oder Ähnliches einfügen.

## 2 Planen

| AP-№ | Frist      | Zuständig | Beschreibung                                                                                          | geplante Zeit |
| ---- | ---------- | --------- | ----------------------------------------------------------------------------------------------------- | ------------- |
| 1.A  | 15.03.2024 |           | Erstellen eines C# Projektes in Visual Studio, Library erstellen, erfolgreiches verlinken aus Github. | 45min         |
|      | 15.03.2024 |           | Implementieren der Huffmann-Methode für die Komprimierung.                                            | 2h 30min      |
|      | 15.03.2024 |           |                                                                                                       |               |
|      | 15.03.2024 |           |                                                                                                       |               |
|      |            |           |                                                                                                       |               |
|      |            |           |                                                                                                       |               |
|      |            |           |                                                                                                       |               |
|      |            |           |                                                                                                       |               |
|      |            |           |                                                                                                       |               |



Total: 

✍️ Die Nummer hat das Format `N.m`, wobei `N` die Nummer der User Story ist, auf die sich das Arbeitspaket bezieht, und `m` von `A` an nach oben buchstabiert. Beispiel: Das dritte Arbeitspaket, das die zweite User Story betrifft, hat also die Nummer `2.C`.

✍️ Ein Arbeitspaket sollte etwa 45' für eine Person in Anspruch nehmen. Die totale Anzahl Arbeitspakete sollte etwa Folgendem entsprechen: `Anzahl R-Sitzungen` ╳ `Anzahl Gruppenmitglieder` ╳ `4`. Wenn Sie also zu dritt an einem Projekt arbeiten, für welches zwei R-Sitzungen geplant sind, sollten Sie auf `2` ╳ `3` ╳`4` = `24` Arbeitspakete kommen. Sollten Sie merken, dass Sie hier nicht genügend Arbeitspakte haben, denken Sie sich weitere "Kann"-User Stories für Kapitel 1.2 aus.

## 3 Entscheiden

✍️ Dokumentieren Sie hier Ihre Entscheidungen und Annahmen, die Sie im Bezug auf Ihre User Stories und die Implementierung getroffen haben.

## 4 Realisieren

| AP-№ | Datum | Zuständig | geplante Zeit | tatsächliche Zeit |
| ---- | ----- | --------- | ------------- | ----------------- |
| 1.A  |       |           |               |                   |
| ...  |       |           |               |                   |

✍️ Tragen Sie jedes Mal, wenn Sie ein Arbeitspaket abschließen, hier ein, wie lang Sie effektiv dafür hatten.

## 5 Kontrollieren

### 5.1 Testprotokoll

| TC-№ | Datum | Resultat | Tester |
| ---- | ----- | -------- | ------ |
| 1.1  |       |          |        |
| ...  |       |          |        |

✍️ Vergessen Sie nicht, ein Fazit hinzuzufügen, welches das Test-Ergebnis einordnet.

### 5.2 Exploratives Testen

| BR-№ | Ausgangslage | Eingabe | Erwartete Ausgabe | Tatsächliche Ausgabe |
| ---- | ------------ | ------- | ----------------- | -------------------- |
| I    |              |         |                   |                      |
| ...  |              |         |                   |                      |

✍️ Verwenden Sie römische Ziffern für Ihre Bug Reports, also I, II, III, IV etc.

## 6 Auswerten

✍️ Fügen Sie hier eine Verknüpfung zu Ihrem Lern-Bericht ein.
