# Calculator 2023 Belba Jurgen 

Una semplice calcolatrice che supporta i calcoli di base come addizione, sottrazione, divisione e moltiplicazione
Successivamente verranno aggiunge funzioni più complesse in modo da renderla una copia praticamente uguale alla calcolatrice integrata di Windows 10/11

# Funzionalità di Base
Addizione: Per sommare due numeri, inserisci il primo numero, premi "+", quindi inserisci il secondo numero e premi "=".
Sottrazione: Per sottrarre un numero da un altro, inserisci il primo numero, premi "-", quindi inserisci il secondo numero e premi "=".
Moltiplicazione: Per moltiplicare due numeri, inserisci il primo numero, premi "*", quindi inserisci il secondo numero e premi "=".
Divisione: Per dividere un numero per un altro, inserisci il dividendo, premi "/", quindi inserisci il divisore e premi "=".

# Descrizione del Codice

Il codice è scritto in C# utilizzando Windows Forms. La calcolatrice ha un'interfaccia utente con pulsanti per i numeri, operatori e funzioni speciali. 
Alcune caratteristiche chiave del codice includono:
BtnStruct: Una struttura che rappresenta ciascun pulsante con il suo contenuto, tipo e stile.
buttons: Una matrice che definisce il layout dei pulsanti sulla calcolatrice.
lastOperator: Memorizza l'ultimo operatore selezionato.
operand1, operand2, result: Variabili per memorizzare gli operandi e il risultato delle operazioni.
MakeButtons(): Metodo per creare i pulsanti sulla calcolatrice.
Button_Click(): Gestisce le azioni quando un pulsante viene premuto.
ClearAll(): Resetta tutti i valori e l'espressione.
ManageSpecialOperator(): Gestisce le funzioni speciali come percentuale, reciproco, quadrato e radice quadrata.
ManageOperator(): Gestisce le operazioni di base come addizione, sottrazione, moltiplicazione e divisione.
WriteExpression(): Scrive l'espressione corrente nella parte superiore della calcolatrice.
lblResult_TextChanged(): Gestisce la formattazione del risultato visualizzato.
