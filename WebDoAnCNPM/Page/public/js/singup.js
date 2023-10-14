$(document).ready(function () {
    var a1 = new Account();
});
class Account {
    constructor() {
        this.initEvents();
    }
    initEvents() {
        $('#btnSingUp').click(this.btnSingUpOnClick.bind(this));
    }

    btnSingUpOnClick() {
        debugger
        const ipHoVaTen = document.getElementById('ipHoVaTen').value;
        const ipUserName = document.getElementById('ipUserName').value;
        const ipEmail = document.getElementById('ipEmail').value;
        const password1 = document.getElementById('ipPassWord').value;
        const password2 = document.getElementById('ipPassWord2').value;

        if (ipHoVaTen == null && ipUserName == null && ipEmail == null && password1 == null && password2 == null) {
            alert('Vui lòng điền đầy đủ thông tin.');
            event.preventDefault();
        } else if (password1 != password2) {
            alert('Mật khẩu không trùng khớp.');
            event.preventDefault();
        } else {
            fetch('https://localhost:5001/api/Register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    HoVaTen: ipHoVaTen,
                    UserName: ipUserName,
                    Email: ipEmail,
                    Password: password1
                })
            })
                .then(response => response.json())
                .then(data => {
                    if (data === 1) {
                        alert('UserName đã tồn tại.');
                    } else if (data === 0) {
                        alert('Đăng ký thành công.');
                        window.location.href = 'login.html';
                    }
                })
                .catch(error => {
                    console.error('Đã xảy ra lỗi:', error);
                });
        }
    }
}
