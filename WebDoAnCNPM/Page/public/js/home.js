$(document).ready(function () {
    var a1 = new Home();
});

class Home {
    constructor() {
        this.loadData();
        this.initEvents();
        console.log('hello');
    }

    initEvents() {
        $('#logoutBtn').click(this.btnLogOutOnClick.bind(this));
    }

    loadData() {
        debugger
        let token = localStorage.getItem('token');
        var user_name = localStorage.getItem('user_name');
        if (token == null) {
            window.location.href = 'login.html';
        }

        fetch('https://localhost:5001/api/CheckLogin', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            },
            body: JSON.stringify({
                UserName: user_name
            })
        })
            .then(response => response.json())
            .then(data => {
                if (data.hoVaTen) {
                    localStorage.setItem('hoVaTen', data.hoVaTen);

                    //In ra hoVaTen
                    var usernameElement = document.getElementById('HoVaTen');
                    usernameElement.textContent = 'Xin chào ' + data.hoVaTen + ', id của bạn là ' + user_name;
                } else {
                    //Chuyen huong ve login.html
                    window.location.href = 'login.html';
                }
            })
            .catch(error => {
                console.error();
            });
    }

    btnLogOutOnClick() {
        localStorage.removeItem('token');
        localStorage.removeItem('user_name');
        window.location.href = 'login.html';
    }
}
