const positionsDiv = document.querySelector('.positions');


const ALPH = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".split('');
const ROTOR_I = {
    array: "AJDKSIRUXBLHWTMCQGZNPYFVOE".split(''),
    notch: 1
};
const ROTOR_II = {
    array: "BDFHJLCPRTXVZNYEIWGAKMUSQO".split(''),
    notch: 2
};
const ROTOR_III = {
    array: "VZBRGITYUPSDNHLXAWMJQOFECK".split(''),
    notch: 2
};
//const REFLECTOR = "YRUHQSLDPXNGOKMIEBFZCWVJAT".split('');
const REFLECTOR = {
    "A": "F",
    "F": "A",
    "B": "V",
    "V": "B",
    "C": "P",
    "P": "C",
    "D": "J",
    "J": "D",
    "E": "I",
    "I": "E",
    "G": "O",
    "O": "G",
    "H": "Y",
    "Y": "H",
    "K": "R",
    "R": "K",
    "L": "Z",
    "Z": "L",
    "M": "X",
    "X": "M",
    "N": "W",
    "W": "N",
    "T": "Q",
    "Q": "T",
    "S": "U",
    "U": "S"
};


// Определяем действующие роторы
var rotors = {
    rotor0: {
        array: ROTOR_I.array,
        position: 0,
        notch: ROTOR_I.notch
    },
    rotor1: {
        array: ROTOR_II.array,
        position: 0,
        notch: ROTOR_II.notch
    },
    rotor2: {
        array: ROTOR_III.array,
        position: 0,
        notch: ROTOR_III.notch
    }
};

positionsDiv.innerHTML = '<p> Positions: ' + ALPH[rotors.rotor0.position] + ' ' + ALPH[rotors.rotor1.position] + ' ' + ALPH[rotors.rotor2.position] + '</p>';


// Define a function that simply increments the rotor, and rotates when it hits 25
function cycle(rotor) {
    let currentPos = rotor.position;
    let newPos = 0;
    if (currentPos == 25) {
        newPos = 0;
    } else {
        newPos = currentPos + 1;
    }
    return newPos;
}

function rotate(rotors) {
    let newRotors = rotors;
    newRotors.rotor2.position = cycle(newRotors.rotor2);
    if (newRotors.rotor2.position == newRotors.rotor2.notch) {
        newRotors.rotor1.position = cycle(newRotors.rotor1);
        if (newRotors.rotor1.position == newRotors.rotor1.notch) {
            newRotors.rotor0.position = cycle(newRotors.rotor0);
        }
    }
    return newRotors;
}

function rotorForward(letter, rotor) {
    let index = ALPH.indexOf(letter);
    index = ((index + rotor.position) % ALPH.length);
    let newLetter = rotor.array[index];
    let newIndex = ALPH.indexOf(newLetter);
    newIndex = (newIndex - rotor.position + ALPH.length) % ALPH.length;
    return ALPH[newIndex];
}

function rotorBack(letter, rotor) {
    let index = ALPH.indexOf(letter);
    index = ((index + rotor.position) % ALPH.length);
    let newIndex = rotor.array.indexOf(ALPH[index]);
    newIndex = (newIndex - rotor.position + ALPH.length) % ALPH.length;
    return ALPH[newIndex];
}

function reflect(letter) {
    return REFLECTOR[letter];
}

function getEncryptKey(key) {
    rotors = rotate(rotors);
    let newLetter = rotorForward(key, rotors.rotor2);
    newLetter = rotorForward(newLetter, rotors.rotor1);
    newLetter = rotorForward(newLetter, rotors.rotor0);
    newLetter = reflect(newLetter);
    newLetter = rotorBack(newLetter, rotors.rotor0);
    newLetter = rotorBack(newLetter, rotors.rotor1);
    newLetter = rotorBack(newLetter, rotors.rotor2);
    document.querySelector('.output-text').value += newLetter;
    positionsDiv.innerHTML = '<p> Positions: ' + ALPH[rotors.rotor0.position] + ' ' + ALPH[rotors.rotor1.position] + ' ' + ALPH[rotors.rotor2.position] + '</p>';
}


document.querySelector('.input-text').addEventListener('keydown', (event) => {
    event.preventDefault();
    var keyName = event.key.toUpperCase();
    if (ALPH.includes(keyName)) {
        document.querySelector('.input-text').value += keyName;
        getEncryptKey(keyName);
    }
});