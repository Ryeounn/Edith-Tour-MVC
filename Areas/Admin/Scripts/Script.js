const body = document.querySelector("body"),
    sidebar = body.querySelector(".sidebar"),
    toggle = body.querySelector(".toggle"),
    searchBtn = body.querySelector(".search-box"),
    modeSwitch = body.querySelector(".toggle-switch"),
    modeText = body.querySelector(".mode-text");

toggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
});

searchBtn.addEventListener("click", () => {
    sidebar.classList.remove("close");
});

//      modeSwitch.addEventListener("click", ()=>{
//         body.classList.toggle("dark"); 
//         
//         if(body.classList.contains("dark")){
//             modeText.innerText = "Light Mode"
//         }else{
//             modeText.innerText = "Dark Mode"
//         }
//      });

let mode = localStorage.getItem('darkmode');
if (mode == 'true') {
    body.classList.add("dark");
    modeText.innerText = "Light Mode";
} else { }
modeSwitch.addEventListener('click', () => {
    if (body.classList.contains("dark")) {
        modeText.innerText = "Dark Mode"
    } else {
        modeText.innerText = "Light Mode"
    }
    let mode = body.classList.toggle('dark');
    // save mode
    localStorage.setItem('darkmode', mode);
});
        $('#input').keypress(function (event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                const input = document.getElementById('input').value;
                if (input === 'dashboard' || input === 'Dashboard' || input === 'DASHBOARD') {
                    window.location = 'homeadmin.php';
                } else if (input === 'product' || input === 'Product' || input === 'PRODUCT') {
                    window.location = 'productadmin.php';
                } else if (input === 'user' || input === 'User' || input === 'USER') {
                    window.location = 'useradmin.php';
                } else if (input === 'order' || input === 'Order' || input === 'ORDER') {
                    window.location = 'orderadmin.php';
                } else if (input === 'revenue' || input === 'Revenue' || input === 'REVENUE') {
                    window.location = 'revenue.php';
                } else if (input === 'logout' || input === 'Logout' || input === 'LOGOUT') {
                    window.location = 'logoutadmin.php';
                } else if (input === 'information' || input === 'Information' || input === 'INFORMATION') {
                    window.location = 'information.php';
                } else {
                    alert('No Result');
                }
            }
        });

        function chooseFile(fileInput) {
            if (fileInput.files && fileInput.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#image').attr('src', e.target.result);
                    $('#images').attr('src', e.target.result);
                    $('#imageFiles').attr('src', e.target.result);
                    $('#imager').attr('src', e.target.result);
                }
                reader.readAsDataURL(fileInput.files[0]);
            }
};