function setYear() {
	document.getElementById("currentYear").innerHTML = new Date().getFullYear();
}

function onWindowLoad() {
	setYear();
}

window.onload = onWindowLoad();