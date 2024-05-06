const toastTrigger = document.getElementById('liveToastBtn')
const toastLive = document.getElementById('liveToast')

if (toastTrigger) {
    const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLive)
    toastTrigger.addEventListener('click', () => {
        toastBootstrap.show()
    })
}