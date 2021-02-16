const html = document.querySelector('html');
const checkbox = document.querySelector('input[name=theme]')

const getStyle = (element, style) =>
    window
        .getComputedStyle(element)
        .getPropertyValue(style)

//siyah yapan ksıım
const initialColors = {
    bg: getStyle(html, '--bg'),
    backBoards: getStyle(html, '--back-boards'),
    colorText: getStyle(html, '--color-text'),
    bd: getStyle(html, '--border'),
    title: getStyle(html, '--title'),
    card: getStyle(html, '--card'),

    hl: getStyle(html, '--hightlight'),
    leave: getStyle(html, '--leave'),
}

// --bg: #FCFCFC;
// --bg-panel: #EBEBEB;
// --color-headings: #0077FF;
// --color-text: #333333;

//beyazlatan kısım
const darkMode = {
    bg: '#808080',
    backBoards: 'white',
    colorText: 'White',
    bd: 'black',
    title: 'black',
    card: '#5e0505',

    hl: '#FF00FF',
    leave: 'grey',

}

const transformKey = key =>
    "--" + key.replace(/([A-Z])/, "-$1").toLowerCase()

const changeColors = (colors) => {
    Object.keys(colors).map(key => {
        html.style.setProperty(transformKey(key), colors[key])
    })
}


checkbox.addEventListener('change', ({ target }) => {
    target.checked ? changeColors(darkMode) : changeColors(initialColors)
})


// Help
function log(message) {
    console.log('>' + message)
}

// App
const cards = document.querySelectorAll('.card');
const dropzones = document.querySelectorAll('.dropzone');

cards.forEach(card => {
    card.addEventListener('dragstart', dragStart)
    card.addEventListener('drag', drag)
    card.addEventListener('dragend', dragEnd)
})

// Pegar
function dragStart() {
    dropzones.forEach(dropzone => dropzone.classList.add('hightlight'))

    this.classList.add('is-dragging')
}

// Movimentar
function drag() {

}

// Soltar
function dragEnd() {
    dropzones.forEach(dropzone => dropzone.classList.remove('hightlight'))
    this.classList.remove('is-dragging')
}

// Local onde vou soltar os cards
dropzones.forEach(dropzone => {
    dropzone.addEventListener('dragenter', dragEnter)
    dropzone.addEventListener('dragover', dragOver)
    dropzone.addEventListener('dragleave', dragLeave)
    dropzone.addEventListener('drop', drop)
})

function dragEnter() {
}

function dragOver() {
    this.classList.add('over')
    //get draggind card
    const cardBeingDragged = document.querySelector('.is-dragging')

    this.appendChild(cardBeingDragged)
}

function dragLeave() {
    this.classList.remove('over')
}

function drop() {
}


