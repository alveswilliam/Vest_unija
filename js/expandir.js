function divexpandeDetalhes(divname, tipo) {
    var div = document.getElementById(divname);

    if (div.style.display == "none") {
        div.style.display = "block";
    } else {
        div.style.display = "none";
    }
}