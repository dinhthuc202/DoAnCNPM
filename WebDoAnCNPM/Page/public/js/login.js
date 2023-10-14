$(document).ready(function () {
    var a1 = new Account();
});

class Account {
    constructor() {
        this.initEvents();
    }
    initEvents() {
        $('#submit').click(this.btnsubmitOnClick.bind(this));
    }

    btnsubmitOnClick() {
        var username = document.getElementById('username').value;
        var password = document.getElementById('password').value;
        if (username && password) {

            localStorage.removeItem('token');
            localStorage.removeItem('user_name');

            fetch('https://localhost:5001/api/Login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    UserName: username,
                    Password: password
                })
            })
                .then(response => response.json())
                .then(data => {
                    if (data.token) {
                        // Lưu token và user_name vào Local Storage
                        localStorage.setItem('token', data.token);
                        localStorage.setItem('user_name', data.user_name);

                        // Chuyển hướng đến home.html nếu đăng nhập thành công
                        window.location.href = 'home.html';
                    } else {
                        // Hiển thị thông báo lỗi khi đăng nhập không thành công
                        console.log('Đăng nhập không thành công. Vui lòng kiểm tra tài khoản và mật khẩu.');
                    }
                })
                .catch(error => {
                    console.error('Sai tài khoản hoạc mật khẩu.');
                });
        } else {
            // Hiển thị thông báo lỗi nếu các ô input không được nhập
            console.log('Vui lòng nhập tên người dùng và mật khẩu.');
        }

    }

}
