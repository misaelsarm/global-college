AOS.init({
    duration: 1200
});

document.getElementById('menu').addEventListener('click', () => {
    document.getElementById('nav-grid').classList.toggle('nav-hidden')
})

document.getElementById('currentYear').textContent = new Date().getFullYear()

const links = document.getElementById('nav-grid')
Array.from(links.children).forEach(a => {
    a.addEventListener('click', () => {
        document.getElementById('nav-grid').classList.toggle('nav-hidden')
    })
})


const slide = document.querySelector('.slide')
const sliderImages = document.querySelectorAll('.slide .slide-img')
const prev = document.querySelector('#prev')
const next = document.querySelector('#next')

let counter = 1;
const size = sliderImages[0].clientWidth;
slide.style.transform = `translateX(${-size * counter}px)`

const moveNext = () => {
    if (counter >= sliderImages.length - 1) {
        return
    }
    slide.style.transition = 'transform 0.4s'
    counter++
    slide.style.transform = `translateX(${-size * counter}px)`
}

const movePrev = () => {
    if (counter <= 0) {
        return
    }
    slide.style.transition = 'transform 0.4s'
    counter--;
    slide.style.transform = `translateX(${-size * counter}px)`
}

next.addEventListener('click', moveNext)

prev.addEventListener('click', movePrev)


setInterval(() => {
    moveNext()
}, 5000);

slide.addEventListener('transitionend', () => {
    if (sliderImages[counter].id === 'lastClone') {
        slide.style.transition = 'none';
        counter = sliderImages.length - 2
        slide.style.transform = `translateX(${-size * counter}px)`
    }
    if (sliderImages[counter].id === 'firstClone') {
        slide.style.transition = 'none';
        counter = sliderImages.length - counter
        slide.style.transform = `translateX(${-size * counter}px)`
    }
})
