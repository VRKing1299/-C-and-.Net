    // Function to open the login overlay
    function openLogin() {
        document.getElementById('loginOverlay').classList.add('active'); // Show the login overlay
        document.getElementById('overlayBg').style.display = 'block'; // Show the background overlay
    }

    // Function to close the login overlay
    function closeLogin() {
        document.getElementById('loginOverlay').classList.remove('active'); // Hide the login overlay
        document.getElementById('overlayBg').style.display = 'none'; // Hide the background overlay
    }