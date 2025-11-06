// tooltips
const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

function setYear() {
	document.getElementById("currentYear").innerHTML = new Date().getFullYear();
}

function onWindowLoad() {
	setYear();
}

window.onload = onWindowLoad();