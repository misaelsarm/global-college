document.getElementById('menu').addEventListener('click', () => {
    console.log('click')
    document.getElementById('nav-grid').classList.toggle('nav-hidden')
})

const links = document.getElementById('nav-grid')
console.log(links.children)
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
console.log(size)


next.addEventListener('click', () => {
    if (counter >= sliderImages.length - 1) {
        return
    }
    slide.style.transition = 'transform 0.4s'
    counter++
    slide.style.transform = `translateX(${-size * counter}px)`
})

prev.addEventListener('click', () => {
    if (counter <= 0) {
        return
    }
    slide.style.transition = 'transform 0.4s'
    counter--;
    slide.style.transform = `translateX(${-size * counter}px)`
})

slide.addEventListener('transitionend', () => {
    console.log('fired')
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
