function setYear() {
	document.getElementById("currentYear").innerHTML = new Date().getFullYear();
}

window.onload = setYear();