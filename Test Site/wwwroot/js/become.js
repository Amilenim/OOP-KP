function calculateEarnings() {
    var rate = document.getElementById('rate').value;
    var sessions = document.getElementById('sessions').value;
    var earnings = rate * sessions;
    document.getElementById('earnings').innerText = earnings;
}